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
            this.label1 = new System.Windows.Forms.Label();
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.языкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
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
            this.msMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя пользователя:";
            // 
            // msMainMenu
            // 
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(289, 24);
            this.msMainMenu.TabIndex = 1;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // языкToolStripMenuItem
            // 
            this.языкToolStripMenuItem.Name = "языкToolStripMenuItem";
            this.языкToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.языкToolStripMenuItem.Text = "Язык";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Сохранять в:";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(3, 40);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(286, 20);
            this.tbUserName.TabIndex = 3;
            // 
            // tbSavePath
            // 
            this.tbSavePath.Location = new System.Drawing.Point(3, 79);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.Size = new System.Drawing.Size(250, 20);
            this.tbSavePath.TabIndex = 4;
            this.tbSavePath.Text = "C:\\Inst";
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectDir.Location = new System.Drawing.Point(259, 77);
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.Size = new System.Drawing.Size(30, 23);
            this.btnSelectDir.TabIndex = 5;
            this.btnSelectDir.Text = "...";
            this.btnSelectDir.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(0, 102);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(16, 13);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "...";
            // 
            // pb1
            // 
            this.pb1.Location = new System.Drawing.Point(3, 118);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(286, 21);
            this.pb1.TabIndex = 7;
            // 
            // lblImgFound
            // 
            this.lblImgFound.AutoSize = true;
            this.lblImgFound.ForeColor = System.Drawing.Color.Blue;
            this.lblImgFound.Location = new System.Drawing.Point(0, 142);
            this.lblImgFound.Name = "lblImgFound";
            this.lblImgFound.Size = new System.Drawing.Size(63, 13);
            this.lblImgFound.TabIndex = 8;
            this.lblImgFound.Text = "Найдено: 0";
            // 
            // lblImgDownloaded
            // 
            this.lblImgDownloaded.AutoSize = true;
            this.lblImgDownloaded.ForeColor = System.Drawing.Color.Green;
            this.lblImgDownloaded.Location = new System.Drawing.Point(69, 142);
            this.lblImgDownloaded.Name = "lblImgDownloaded";
            this.lblImgDownloaded.Size = new System.Drawing.Size(61, 13);
            this.lblImgDownloaded.TabIndex = 9;
            this.lblImgDownloaded.Text = "Скачано: 0";
            // 
            // lblImgErrors
            // 
            this.lblImgErrors.AutoSize = true;
            this.lblImgErrors.ForeColor = System.Drawing.Color.Red;
            this.lblImgErrors.Location = new System.Drawing.Point(136, 142);
            this.lblImgErrors.Name = "lblImgErrors";
            this.lblImgErrors.Size = new System.Drawing.Size(59, 13);
            this.lblImgErrors.TabIndex = 10;
            this.lblImgErrors.Text = "Ошибок: 0";
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Location = new System.Drawing.Point(3, 158);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(286, 23);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Старт";
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
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(289, 184);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblImgErrors);
            this.Controls.Add(this.lblImgDownloaded);
            this.Controls.Add(this.lblImgFound);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnSelectDir);
            this.Controls.Add(this.tbSavePath);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msMainMenu;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InstagramPhotoDownloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem языкToolStripMenuItem;
        private System.Windows.Forms.Label label2;
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

    }
}

