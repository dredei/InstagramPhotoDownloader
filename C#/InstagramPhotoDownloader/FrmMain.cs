using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Windows7.DesktopIntegration.WindowsForms;
using ExtensionMethods;
using Ini;
using Microsoft.Win32;

namespace InstagramPhotoDownloader
{
    public partial class FrmMain : Form
    {
        private Thread _thread;
        private Thread _checkInternetThread;
        private InstagramDownloader _instDownloader;
        private string _language = "en-GB";
        private readonly Version _version = Version.Parse( "1.0.0" );
        private readonly bool _possibleProgressInTaskBar;

        public FrmMain()
        {
            this.LoadSettings();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo( this._language );
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            tbSavePath.Text = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments ) + "\\InstagramPhotoDownloader";
            if ( Environment.OSVersion.Version >= new Version( 6, 1 ) ) // if version current version >= win7
            {
                this._possibleProgressInTaskBar = true;
            }
        }

        private void ChangeLanguage( string lang )
        {
            this._language = lang;
            this.SaveSettings();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo( this._language );
            DialogResult res = MessageBox.Show( strings.RestartApp, strings.Warning, MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning );
            if ( res == DialogResult.Yes )
            {
                Application.Restart();
            }
        }

        private void SaveSettings()
        {
            try
            {
                var ini = new IniFile( Application.StartupPath + @"\Settings.ini" );
                ini.Write( "Lang", this._language, "Options" );
            }
            catch
            {
            }
        }

        private void LoadSettings()
        {
            try
            {
                var ini = new IniFile( Application.StartupPath + @"\Settings.ini" );
                this._language = ini.Read( "Lang", "Options", this._language );
            }
            catch
            {
            }
        }

        private void Work()
        {
            _instDownloader = new InstagramDownloader();
            _instDownloader.DownloadPhotos( tbUserName.Text, tbSavePath.Text );
            tmrProgress.Stop();
            this.DisEnControls();
            MessageBox.Show( strings.Done, strings.Information, MessageBoxButtons.OK, MessageBoxIcon.Information );
            if ( this._instDownloader.ErrorsLinks.Count > 0 )
            {
                DialogResult dr = MessageBox.Show( strings.CopyToClipboard, strings.Error, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question );
                if ( dr != DialogResult.Yes )
                {
                    return;
                }
                StringBuilder sb = new StringBuilder();
                foreach ( string s in this._instDownloader.ErrorsLinks )
                {
                    sb.AppendLine( s );
                }
                Clipboard.SetText( sb.ToString() );
            }
            _instDownloader.Dispose();
        }

        private void DisEnControls()
        {
            this.tbSavePath.Enabled = !this.tbSavePath.Enabled;
            this.tbUserName.Enabled = !this.tbUserName.Enabled;
            this.btnSelectDir.Enabled = !this.btnSelectDir.Enabled;
            this.btnStart.Enabled = !this.btnStart.Enabled;
        }

        private void AutoPosLabels()
        {
            this.lblImgDownloaded.Left = this.lblImgFound.Right + 6;
            this.lblImgErrors.Left = this.lblImgDownloaded.Right + 6;
        }

        private void btnStart_Click( object sender, EventArgs e )
        {
            if ( string.IsNullOrEmpty( tbUserName.Text ) || string.IsNullOrEmpty( tbSavePath.Text ) )
            {
                MessageBox.Show( strings.FillTheFields, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            tbUserName.Text = InstagramDownloader.FixUserName( tbUserName.Text );
            this.DisEnControls();
            this._thread = new Thread( this.Work );
            this._thread.Start();
            tmrProgress.Start();
        }

        private void tmrProgress_Tick( object sender, EventArgs e )
        {
            if ( this._instDownloader != null )
            {
                ProgressC progress = this._instDownloader.Progress;
                switch ( progress.Type )
                {
                    case ProgressType.GettingImages:
                        this.lblInfo.Text = string.Format( strings.GettingImages, progress.Page );
                        this.pb1.Style = ProgressBarStyle.Marquee;
                        break;

                    case ProgressType.GettingImagesLinks:
                        this.lblInfo.Text = string.Format( strings.GettingImagesLinks, progress.CurrentProgress, progress.MaxProgress );
                        this.pb1.Style = ProgressBarStyle.Marquee;
                        break;

                    case ProgressType.DownloadingImages:
                        this.lblInfo.Text = strings.DownloadingImages;
                        this.pb1.Style = ProgressBarStyle.Blocks;
                        this.pb1.Maximum = progress.MaxProgress;
                        this.pb1.Value = progress.CurrentProgress;
                        break;
                }
                this.lblImgFound.Text = strings.Found + progress.MaxProgress;
                this.lblImgDownloaded.Text = strings.Downloaded + progress.Downloaded;
                this.lblImgErrors.Text = strings.Errors + this._instDownloader.ErrorsLinks.Count;
            }
            this.AutoPosLabels();
            if ( this._possibleProgressInTaskBar )
            {
                this.pb1.SetTaskbarProgress();
            }
        }

        private void FrmMain_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( this._thread != null )
            {
                this._thread.Abort();
            }
            if ( this._checkInternetThread != null )
            {
                this._checkInternetThread.Abort();
            }
            this.SaveSettings();
        }

        private void tmrCheckInternet_Tick( object sender, EventArgs e )
        {
            this.tmrCheckInternet.Stop();
            this._checkInternetThread = new Thread( delegate()
            {
                if ( InstagramDownloader.CheckForInternetConnection() )
                {
                    this.btnStart.Enabled = true;
                }
                else
                {
                    this.tmrCheckInternet.Interval = 5000;
                    MessageBox.Show( strings.UnableAccess, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error );
                    this.tmrCheckInternet.Start();
                }
            } ) { Priority = ThreadPriority.Lowest };
            this._checkInternetThread.Start();
        }

        private void tsmiSite_Click( object sender, EventArgs e )
        {
            Process.Start( "http://www.softez.pp.ua/" );
        }

        private void tsmiRepo_Click( object sender, EventArgs e )
        {
            Process.Start( "https://github.com/dredei/InstagramPhotoDownloader" );
        }

        private void tsmiAbout_Click( object sender, EventArgs e )
        {
            MessageBox.Show( strings.AboutInfo.FixNewLines() + this._version, strings.About, MessageBoxButtons.OK,
                MessageBoxIcon.Information );
        }

        private void tsmiEnglishLang_Click( object sender, EventArgs e )
        {
            this.ChangeLanguage( "en-GB" );
        }

        private void tsmiRusLang_Click( object sender, EventArgs e )
        {
            this.ChangeLanguage( "ru-RU" );
        }

        private void btnSelectDir_Click( object sender, EventArgs e )
        {
            fbd1.SelectedPath = tbSavePath.Text;
            if ( fbd1.ShowDialog() == DialogResult.OK )
            {
                tbSavePath.Text = fbd1.SelectedPath;
            }
        }
    }
}
