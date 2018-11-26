namespace StartupDelayed
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileConfigs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpCLI = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.grdMain = new System.Windows.Forms.DataGridView();
            this.niMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmnuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuMainShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuMainStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuMainExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.cmnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(632, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSettings,
            this.mnuFileConfigs,
            this.toolStripSeparator1,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(45, 20);
            this.mnuFile.Text = "&Файл";
            // 
            // mnuFileSettings
            // 
            this.mnuFileSettings.Name = "mnuFileSettings";
            this.mnuFileSettings.Size = new System.Drawing.Size(196, 22);
            this.mnuFileSettings.Text = "&Настройки...";
            this.mnuFileSettings.Click += new System.EventHandler(this.mnuFileSettings_Click);
            // 
            // mnuFileConfigs
            // 
            this.mnuFileConfigs.Name = "mnuFileConfigs";
            this.mnuFileConfigs.Size = new System.Drawing.Size(196, 22);
            this.mnuFileConfigs.Text = "&Файлы конфигурации...";
            this.mnuFileConfigs.Click += new System.EventHandler(this.mnuFileConfigs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(196, 22);
            this.mnuFileExit.Text = "&Выход";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditAdd,
            this.mnuEditEdit,
            this.mnuEditDelete});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(98, 20);
            this.mnuEdit.Text = "&Редактировать";
            // 
            // mnuEditAdd
            // 
            this.mnuEditAdd.Name = "mnuEditAdd";
            this.mnuEditAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.mnuEditAdd.Size = new System.Drawing.Size(203, 22);
            this.mnuEditAdd.Text = "&Добавить...";
            this.mnuEditAdd.Click += new System.EventHandler(this.mnuEditAdd_Click);
            // 
            // mnuEditEdit
            // 
            this.mnuEditEdit.Name = "mnuEditEdit";
            this.mnuEditEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuEditEdit.Size = new System.Drawing.Size(203, 22);
            this.mnuEditEdit.Text = "Р&едактировать...";
            this.mnuEditEdit.Click += new System.EventHandler(this.mnuEditEdit_Click);
            // 
            // mnuEditDelete
            // 
            this.mnuEditDelete.Name = "mnuEditDelete";
            this.mnuEditDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.mnuEditDelete.Size = new System.Drawing.Size(203, 22);
            this.mnuEditDelete.Text = "Удалить";
            this.mnuEditDelete.Click += new System.EventHandler(this.mnuEditDelete_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpCLI,
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(59, 20);
            this.mnuHelp.Text = "Помощь";
            // 
            // mnuHelpCLI
            // 
            this.mnuHelpCLI.Name = "mnuHelpCLI";
            this.mnuHelpCLI.Size = new System.Drawing.Size(239, 22);
            this.mnuHelpCLI.Text = "Параметры командной строки...";
            this.mnuHelpCLI.Click += new System.EventHandler(this.mnuHelpCLI_Click);
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(239, 22);
            this.mnuHelpAbout.Text = "О программе...";
            this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
            // 
            // grdMain
            // 
            this.grdMain.AllowUserToAddRows = false;
            this.grdMain.AllowUserToDeleteRows = false;
            this.grdMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.Location = new System.Drawing.Point(0, 24);
            this.grdMain.Name = "grdMain";
            this.grdMain.ReadOnly = true;
            this.grdMain.Size = new System.Drawing.Size(632, 428);
            this.grdMain.TabIndex = 1;
            this.grdMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMain_CellDoubleClick);
            this.grdMain.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdMain_CellFormatting);
            this.grdMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMain_CellContentClick);
            // 
            // niMain
            // 
            this.niMain.ContextMenuStrip = this.cmnuMain;
            this.niMain.Text = "Менеджер отложенной автозагрузки";
            this.niMain.Visible = true;
            // 
            // cmnuMain
            // 
            this.cmnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuMainShow,
            this.toolStripSeparator2,
            this.cmnuMainStop,
            this.toolStripSeparator3,
            this.cmnuMainExit});
            this.cmnuMain.Name = "cmnuMain";
            this.cmnuMain.Size = new System.Drawing.Size(177, 82);
            // 
            // cmnuMainShow
            // 
            this.cmnuMainShow.Name = "cmnuMainShow";
            this.cmnuMainShow.Size = new System.Drawing.Size(176, 22);
            this.cmnuMainShow.Text = "Показать  задачи...";
            this.cmnuMainShow.Click += new System.EventHandler(this.cmnuMainShow_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
            // 
            // cmnuMainStop
            // 
            this.cmnuMainStop.Name = "cmnuMainStop";
            this.cmnuMainStop.Size = new System.Drawing.Size(176, 22);
            this.cmnuMainStop.Text = "Остановить";
            this.cmnuMainStop.Click += new System.EventHandler(this.cmnuMainStop_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(173, 6);
            // 
            // cmnuMainExit
            // 
            this.cmnuMainExit.Name = "cmnuMainExit";
            this.cmnuMainExit.Size = new System.Drawing.Size(176, 22);
            this.cmnuMainExit.Text = "Выход";
            this.cmnuMainExit.Click += new System.EventHandler(this.cmnuMainExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 452);
            this.Controls.Add(this.grdMain);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отложенная автозагрузка";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.cmnuMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;        
        private System.Windows.Forms.ToolStripMenuItem mnuEditAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuEditEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuEditDelete;
        private System.Windows.Forms.DataGridView grdMain;
        private System.Windows.Forms.NotifyIcon niMain;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpCLI;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuFileConfigs;
        private System.Windows.Forms.ContextMenuStrip cmnuMain;
        private System.Windows.Forms.ToolStripMenuItem cmnuMainShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmnuMainStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmnuMainExit;
        
    }
}

