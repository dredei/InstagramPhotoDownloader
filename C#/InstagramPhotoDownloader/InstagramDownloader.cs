#region Using

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using ExtensionMethods;
using HtmlAgilityPack;

#endregion

namespace InstagramPhotoDownloader
{

    #region Additional classes

    public class ProgressC
    {
        public int CurrentProgress { get; set; }
        public int MaxProgress { get; set; }
        public int Page { get; set; }
        public int Downloaded { get; set; }
        public ProgressType Type { get; set; }
    }

    public enum ProgressType
    {
        GettingImages,
        GettingImagesLinks,
        DownloadingImages
    }

    #endregion

    public sealed class InstagramDownloader : IDisposable
    {
        public ProgressC Progress;
        public List<string> ErrorsLinks;

        private WebClient _webClient;
        private const string StagramLink = "http://web.stagram.com";
        private bool _disposed;

        public InstagramDownloader()
        {
            this._webClient = new WebClient();
            this.Progress = new ProgressC();
            this.ErrorsLinks = new List<string>();
        }

        private string GetHTML( string url )
        {
            bool exception = false;
            string html = string.Empty;
            do
            {
                try
                {
                    this._webClient.Headers[ HttpRequestHeader.UserAgent ] =
                        "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                    html = this._webClient.DownloadString( url );
                    exception = false;
                }
                catch ( Exception ex )
                {
                    if ( ex.Message.IndexOf( "404" ) == 0 )
                    {
                        exception = true;
                        Thread.Sleep( 3000 );
                    }
                }
            }
            while ( exception );
            return html;
        }

        private void DownloadFile( string fileUrl, string savePath, int index )
        {
            string fileName = savePath + "\\" + index + Path.GetExtension( fileUrl );
            try
            {
                this._webClient.DownloadFile( fileUrl, fileName );
            }
            catch
            {
                this.ErrorsLinks.Add( fileUrl );
                return;
            }
            this.Progress.Downloaded++;
        }

        private IEnumerable<string> GetPhotoPages( HtmlAgilityPack.HtmlDocument document )
        {
            List<string> photoPages = new List<string>();
            var photosElements =
                document.DocumentNode.SelectNodes( "//div[@class='photobox']//a[@class='mainimg small']" );
            if ( photosElements != null )
            {
                foreach ( HtmlNode photo in photosElements )
                {
                    string href = photo.GetAttributeValue( "href", "" );
                    if ( !href.IsNullOrEmpty() && !photo.InnerHtml.Contains( "playvideo grid" ) )
                    {
                        photoPages.Add( href );
                    }
                }
            }
            return photoPages;
        }

        private string GetPhotoLink( string photoPage )
        {
            string html = this.GetHTML( StagramLink + photoPage );
            var h = new HtmlAgilityPack.HtmlDocument();
            h.LoadHtml( html );
            var photoDiv = h.DocumentNode.SelectSingleNode( "//div[@class='photobox single']" );
            if ( photoDiv != null )
            {
                var img = photoDiv.SelectNodes( ".//img" );
                if ( img == null )
                {
                    return "";
                }
                return img[ 1 ].GetAttributeValue( "src", "" );
            }
            return "";
        }

        public void DownloadPhotos( string nickname, string savePath )
        {
            this.ErrorsLinks.Clear();
            string nextLink = StagramLink + "/n/" + nickname + "/?vm=grid";
            List<string> photoPages = new List<string>();
            int page = 0;
            this.Progress.Type = ProgressType.GettingImages;
            do
            {
                page++;
                this.Progress.Page = page;
                string html = this.GetHTML( nextLink );
                var h = new HtmlAgilityPack.HtmlDocument();
                h.LoadHtml( html );
                photoPages.AddRange( this.GetPhotoPages( h ) );
                var nextLinkNode = h.DocumentNode.SelectNodes( "//a[@rel='next']" );
                nextLink = nextLinkNode != null ? nextLinkNode[ 0 ].GetAttributeValue( "href", "" ) : "";
                if ( !string.IsNullOrEmpty( nextLink ) )
                {
                    nextLink = StagramLink + nextLink + "&vm=grid";
                    Regex regex = new Regex( StagramLink );
                    if ( regex.Matches( nextLink ).Count > 1 )
                    {
                        regex = new Regex( Regex.Escape( StagramLink ) );
                        nextLink = regex.Replace( nextLink, "", 1 );
                    }
                }
                Thread.Sleep( 1000 );
            }
            while ( !string.IsNullOrEmpty( nextLink ) );

            this.Progress.Type = ProgressType.GettingImagesLinks;
            List<string> photosLinks = new List<string>();
            this.Progress.MaxProgress = photoPages.Count;
            for ( int i = 0; i < photoPages.Count; i++ )
            {
                string photoPage = photoPages[ i ];
                string photoLink = this.GetPhotoLink( photoPage );
                if ( !string.IsNullOrEmpty( photoLink ) )
                {
                    photosLinks.Add( photoLink );
                }
                this.Progress.CurrentProgress = i + 1;
                Thread.Sleep( 1000 );
            }
            if ( !Directory.Exists( savePath ) )
            {
                Directory.CreateDirectory( savePath );
            }
            this.Progress.CurrentProgress = 0;
            this.Progress.MaxProgress = photosLinks.Count;
            this.Progress.Type = ProgressType.DownloadingImages;
            for ( int i = 0; i < photosLinks.Count; i++ )
            {
                string link = photosLinks[ i ];
                this.DownloadFile( link, savePath, i + 1 );
                this.Progress.CurrentProgress = i + 1;
                Thread.Sleep( 500 );
            }
        }

        #region Static methods

        public static string FixUserName( string url )
        {
            var regex = new Regex( "http(s)?://instagram\\.com/(\\w+)(#)?" );
            Match match = regex.Match( url );
            return match.Success ? match.Groups[ 2 ].ToString() : url;
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using ( var client = new WebClient() )
                {
                    using ( var stream = client.OpenRead( "http://instagram.com/" ) )
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Members

        ~InstagramDownloader()
        {
            this.Dispose( false );
        }

        public void Dispose()
        {
            this.Dispose( true );
            GC.SuppressFinalize( this );
        }

        private void Dispose( bool disposing )
        {
            if ( !this._disposed )
            {
                if ( disposing )
                {
                    if ( this._webClient != null )
                    {
                        this._webClient.Dispose();
                    }
                }

                // Indicate that the instance has been disposed.
                this._webClient = null;
                this.Progress = null;
                this._disposed = true;
                this.ErrorsLinks.Clear();
                this.ErrorsLinks = null;
            }
        }

        #endregion
    }
}