using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace InstagramPhotoDownloader
{
    public partial class FrmMain : Form
    {
        private Thread _thread;
        private InstagramDownloader _instDownloader;

        public FrmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Work()
        {
            _instDownloader = new InstagramDownloader();
            _instDownloader.DownloadPhotos( tbUserName.Text, tbSavePath.Text );
            tmrProgress.Stop();
            this.DisEnControls();
            //instDownloader.Dispose();
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
                        this.lblInfo.Text = "Получаем ссылки изображений...";
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
            //if ( this._possibleProgressInTaskBar )
            //{
            //    this.pb1.SetTaskbarProgress();
            //}
        }

        private void FrmMain_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( this._thread != null )
            {
                this._thread.Abort();
            }
        }
    }
}
