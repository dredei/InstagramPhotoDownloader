using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using HtmlAgilityPack;

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

    public class InstagramDownloader
    {
        public readonly ProgressC Progress;
        public readonly List<string> ErrorsLinks;

        private readonly WebClient _webClient;
        private const string StagramLink = "http://web.stagram.com";

        public InstagramDownloader()
        {
            this._webClient = new WebClient();
            this.Progress = new ProgressC();
            this.ErrorsLinks = new List<string>();
        }

        private string GetHTML( string url )
        {
            bool exception;
            string html = string.Empty;
            do
            {
                try
                {
                    html = this._webClient.DownloadString( url );
                    exception = false;
                }
                catch
                {
                    exception = true;
                    Thread.Sleep( 3000 );
                }
            }
            while ( exception );
            return html;
        }

        private void DownloadFile( string fileUrl, string savePath )
        {
            string fileName = savePath + "\\" + Path.GetFileName( fileUrl );
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
            var photosElements = document.DocumentNode.SelectNodes( "//div[@class='photo']" );
            if ( photosElements != null )
            {
                foreach ( HtmlNode photo in photosElements )
                {
                    string innerHtml = photo.InnerHtml;
                    string photoPage = innerHtml.Remove( 0, innerHtml.IndexOf( "\"" ) + 1 );
                    photoPage = photoPage.Substring( 0, photoPage.IndexOf( "\"" ) );
                    if ( photoPage != "hasvideo grid" )
                    {
                        photoPages.Add( photoPage );
                    }
                }
            }
            return photoPages;
        }

        private List<string> GetPhotoLinks( IEnumerable<string> photoPages )
        {
            List<string> photosUrls = new List<string>();
            foreach ( string photoPage in photoPages )
            {
                string html = this.GetHTML( StagramLink + photoPage );
                var h = new HtmlAgilityPack.HtmlDocument();
                h.LoadHtml( html );
                var photoDiv = h.DocumentNode.SelectNodes( "//div[@class='photo relative single']" );
                if ( photoDiv != null )
                {
                    string innerHtml = photoDiv[ 0 ].InnerHtml;
                    Regex regex = new Regex( "(http://.*\\.jpg)" );
                    photosUrls.Add( regex.Match( innerHtml ).Groups[ 1 ].ToString() );
                }
                Thread.Sleep( 1000 );
            }
            return photosUrls;
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
            List<string> photosLinks = this.GetPhotoLinks( photoPages );
            if ( !Directory.Exists( savePath ) )
            {
                Directory.CreateDirectory( savePath );
            }
            this.Progress.Type = ProgressType.DownloadingImages;
            this.Progress.MaxProgress = photosLinks.Count;
            for ( int i = 0; i < photosLinks.Count; i++ )
            {
                string link = photosLinks[ i ];
                this.DownloadFile( link, savePath );
                this.Progress.CurrentProgress = i + 1;
                Thread.Sleep( 1500 );
            }
        }
    }
}
