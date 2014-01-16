namespace InstagramPhotoDownloader
{
    partial class FrmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.языкToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEnglishLang = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRusLang = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRepo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.языкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbSavePath = new System.Windows.Forms.TextBox();
            this.btnSelectDir = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pb1 = new System.Windows.Forms.ProgressBar();
            this.lblImgFound = new System.Windows.Forms.Label();
            this.lblImgDownloaded = new System.Windows.Forms.Label();
            this.lblImgErrors = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tmrProgress = new System.Windows.Forms.Timer(this.components);
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrCheckInternet = new System.Windows.Forms.Timer(this.components);
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.fbd1 = new System.Windows.Forms.FolderBrowserDialog();
            this.msMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.языкToolStripMenuItem1,
            this.оПрограммеToolStripMenuItem1});
            resources.ApplyResources(this.msMainMenu, "msMainMenu");
            this.msMainMenu.Name = "msMainMenu";
            // 
            // языкToolStripMenuItem1
            // 
            this.языкToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEnglishLang,
            this.tsmiRusLang});
            this.языкToolStripMenuItem1.Name = "языкToolStripMenuItem1";
            resources.ApplyResources(this.языкToolStripMenuItem1, "языкToolStripMenuItem1");
            // 
            // tsmiEnglishLang
            // 
            this.tsmiEnglishLang.Name = "tsmiEnglishLang";
            resources.ApplyResources(this.tsmiEnglishLang, "tsmiEnglishLang");
            this.tsmiEnglishLang.Click += new System.EventHandler(this.tsmiEnglishLang_Click);
            // 
            // tsmiRusLang
            // 
            this.tsmiRusLang.Name = "tsmiRusLang";
            resources.ApplyResources(this.tsmiRusLang, "tsmiRusLang");
            this.tsmiRusLang.Click += new System.EventHandler(this.tsmiRusLang_Click);
            // 
            // оПрограммеToolStripMenuItem1
            // 
            this.оПрограммеToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSite,
            this.tsmiRepo,
            this.toolStripMenuItem1,
            this.tsmiAbout});
            this.оПрограммеToolStripMenuItem1.Name = "оПрограммеToolStripMenuItem1";
            resources.ApplyResources(this.оПрограммеToolStripMenuItem1, "оПрограммеToolStripMenuItem1");
            // 
            // tsmiSite
            // 
            this.tsmiSite.Name = "tsmiSite";
            resources.ApplyResources(this.tsmiSite, "tsmiSite");
            this.tsmiSite.Click += new System.EventHandler(this.tsmiSite_Click);
            // 
            // tsmiRepo
            // 
            this.tsmiRepo.Name = "tsmiRepo";
            resources.ApplyResources(this.tsmiRepo, "tsmiRepo");
            this.tsmiRepo.Click += new System.EventHandler(this.tsmiRepo_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            resources.ApplyResources(this.tsmiAbout, "tsmiAbout");
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // языкToolStripMenuItem
            // 
            this.языкToolStripMenuItem.Name = "языкToolStripMenuItem";
            resources.ApplyResources(this.языкToolStripMenuItem, "языкToolStripMenuItem");
            // 
            // tbUserName
            // 
            resources.ApplyResources(this.tbUserName, "tbUserName");
            this.tbUserName.Name = "tbUserName";
            // 
            // tbSavePath
            // 
            resources.ApplyResources(this.tbSavePath, "tbSavePath");
            this.tbSavePath.Name = "tbSavePath";
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnSelectDir, "btnSelectDir");
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.UseVisualStyleBackColor = true;
            this.btnSelectDir.Click += new System.EventHandler(this.btnSelectDir_Click);
            // 
            // lblInfo
            // 
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            // 
            // pb1
            // 
            resources.ApplyResources(this.pb1, "pb1");
            this.pb1.Name = "pb1";
            // 
            // lblImgFound
            // 
            resources.ApplyResources(this.lblImgFound, "lblImgFound");
            this.lblImgFound.ForeColor = System.Drawing.Color.Blue;
            this.lblImgFound.Name = "lblImgFound";
            // 
            // lblImgDownloaded
            // 
            resources.ApplyResources(this.lblImgDownloaded, "lblImgDownloaded");
            this.lblImgDownloaded.ForeColor = System.Drawing.Color.Green;
            this.lblImgDownloaded.Name = "lblImgDownloaded";
            // 
            // lblImgErrors
            // 
            resources.ApplyResources(this.lblImgErrors, "lblImgErrors");
            this.lblImgErrors.ForeColor = System.Drawing.Color.Red;
            this.lblImgErrors.Name = "lblImgErrors";
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tmrProgress
            // 
            this.tmrProgress.Tick += new System.EventHandler(this.tmrProgress_Tick);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            resources.ApplyResources(this.оПрограммеToolStripMenuItem, "оПрограммеToolStripMenuItem");
            // 
            // tmrCheckInternet
            // 
            this.tmrCheckInternet.Enabled = true;
            this.tmrCheckInternet.Tick += new System.EventHandler(this.tmrCheckInternet_Tick);
            // 
            // lblUserName
            // 
            resources.ApplyResources(this.lblUserName, "lblUserName");
            this.lblUserName.Name = "lblUserName";
            // 
            // lblSavePath
            // 
            resources.ApplyResources(this.lblSavePath, "lblSavePath");
            this.lblSavePath.Name = "lblSavePath";
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSavePath);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblImgErrors);
            this.Controls.Add(this.lblImgDownloaded);
            this.Controls.Add(this.lblImgFound);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnSelectDir);
            this.Controls.Add(this.tbSavePath);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.msMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msMainMenu;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem языкToolStripMenuItem;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbSavePath;
        private System.Windows.Forms.Button btnSelectDir;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ProgressBar pb1;
        private System.Windows.Forms.Label lblImgFound;
        private System.Windows.Forms.Label lblImgDownloaded;
        private System.Windows.Forms.Label lblImgErrors;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer tmrProgress;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem языкToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem1;
        private System.Windows.Forms.Timer tmrCheckInternet;
        private System.Windows.Forms.ToolStripMenuItem tsmiSite;
        private System.Windows.Forms.ToolStripMenuItem tsmiRepo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiEnglishLang;
        private System.Windows.Forms.ToolStripMenuItem tsmiRusLang;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.FolderBrowserDialog fbd1;

    }
}

