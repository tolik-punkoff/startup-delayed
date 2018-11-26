namespace StartupDelayed
{
    partial class frmAppSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCheckTimeTypeMin = new System.Windows.Forms.RadioButton();
            this.rbCheckTimeTypeSecs = new System.Windows.Forms.RadioButton();
            this.txtCheckTime = new System.Windows.Forms.TextBox();
            this.chkCloseAfterSuccess = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStartup = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCheckTimeTypeMin);
            this.groupBox1.Controls.Add(this.rbCheckTimeTypeSecs);
            this.groupBox1.Controls.Add(this.txtCheckTime);
            this.groupBox1.Location = new System.Drawing.Point(31, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Проверять наличие файла каждые:";
            // 
            // rbCheckTimeTypeMin
            // 
            this.rbCheckTimeTypeMin.AutoSize = true;
            this.rbCheckTimeTypeMin.Location = new System.Drawing.Point(105, 45);
            this.rbCheckTimeTypeMin.Name = "rbCheckTimeTypeMin";
            this.rbCheckTimeTypeMin.Size = new System.Drawing.Size(55, 17);
            this.rbCheckTimeTypeMin.TabIndex = 2;
            this.rbCheckTimeTypeMin.Text = "минут";
            this.rbCheckTimeTypeMin.UseVisualStyleBackColor = true;
            // 
            // rbCheckTimeTypeSecs
            // 
            this.rbCheckTimeTypeSecs.AutoSize = true;
            this.rbCheckTimeTypeSecs.Checked = true;
            this.rbCheckTimeTypeSecs.Location = new System.Drawing.Point(39, 45);
            this.rbCheckTimeTypeSecs.Name = "rbCheckTimeTypeSecs";
            this.rbCheckTimeTypeSecs.Size = new System.Drawing.Size(60, 17);
            this.rbCheckTimeTypeSecs.TabIndex = 1;
            this.rbCheckTimeTypeSecs.TabStop = true;
            this.rbCheckTimeTypeSecs.Text = "секунд";
            this.rbCheckTimeTypeSecs.UseVisualStyleBackColor = true;
            // 
            // txtCheckTime
            // 
            this.txtCheckTime.Location = new System.Drawing.Point(30, 19);
            this.txtCheckTime.MaxLength = 5;
            this.txtCheckTime.Name = "txtCheckTime";
            this.txtCheckTime.Size = new System.Drawing.Size(142, 20);
            this.txtCheckTime.TabIndex = 0;
            this.txtCheckTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCheckTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCheckTime_KeyPress);
            // 
            // chkCloseAfterSuccess
            // 
            this.chkCloseAfterSuccess.AutoSize = true;
            this.chkCloseAfterSuccess.Location = new System.Drawing.Point(3, 77);
            this.chkCloseAfterSuccess.Name = "chkCloseAfterSuccess";
            this.chkCloseAfterSuccess.Size = new System.Drawing.Size(264, 17);
            this.chkCloseAfterSuccess.TabIndex = 1;
            this.chkCloseAfterSuccess.Text = "Закрыть программу после запуска всех задач";
            this.chkCloseAfterSuccess.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(3, 135);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(192, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStartup
            // 
            this.btnStartup.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartup.Location = new System.Drawing.Point(3, 100);
            this.btnStartup.Name = "btnStartup";
            this.btnStartup.Size = new System.Drawing.Size(264, 31);
            this.btnStartup.TabIndex = 4;
            this.btnStartup.Text = "Добавить в автозагрузку";
            this.btnStartup.UseVisualStyleBackColor = true;
            this.btnStartup.Click += new System.EventHandler(this.btnStartup_Click);
            // 
            // frmAppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 160);
            this.Controls.Add(this.btnStartup);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkCloseAfterSuccess);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAppSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.frmAppSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCheckTimeTypeMin;
        private System.Windows.Forms.RadioButton rbCheckTimeTypeSecs;
        private System.Windows.Forms.TextBox txtCheckTime;
        private System.Windows.Forms.CheckBox chkCloseAfterSuccess;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnStartup;

    }
}