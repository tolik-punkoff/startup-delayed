namespace StartupDelayed
{
    partial class frmAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdd));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.txtTaskPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtParameters = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAsAdmin = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.chkActiveTask = new System.Windows.Forms.CheckBox();
            this.btnRunNow = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWorkingDirectory = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbWindowStyleNormal = new System.Windows.Forms.RadioButton();
            this.rbWindowStyleMaximized = new System.Windows.Forms.RadioButton();
            this.rbWindowStyleMinimized = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя:";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(36, 10);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(508, 20);
            this.txtTaskName.TabIndex = 1;
            // 
            // txtTaskPath
            // 
            this.txtTaskPath.Location = new System.Drawing.Point(36, 36);
            this.txtTaskPath.Name = "txtTaskPath";
            this.txtTaskPath.Size = new System.Drawing.Size(426, 20);
            this.txtTaskPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Путь:";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(469, 37);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Выбрать...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtParameters
            // 
            this.txtParameters.Location = new System.Drawing.Point(100, 87);
            this.txtParameters.Name = "txtParameters";
            this.txtParameters.Size = new System.Drawing.Size(446, 20);
            this.txtParameters.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Параметры:";
            // 
            // chkAsAdmin
            // 
            this.chkAsAdmin.AutoSize = true;
            this.chkAsAdmin.Location = new System.Drawing.Point(313, 121);
            this.chkAsAdmin.Name = "chkAsAdmin";
            this.chkAsAdmin.Size = new System.Drawing.Size(198, 17);
            this.chkAsAdmin.TabIndex = 10;
            this.chkAsAdmin.Text = "Запуск от имени администратора";
            this.chkAsAdmin.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(6, 169);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(469, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "Исполняемые файлы (*.exe, *.com, *.bat, *.cmd)|*.exe;*.com;*.bat;*.cmd|Все файлы " +
                "(*.*)|*.*";
            // 
            // chkActiveTask
            // 
            this.chkActiveTask.AutoSize = true;
            this.chkActiveTask.Checked = true;
            this.chkActiveTask.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActiveTask.Location = new System.Drawing.Point(313, 144);
            this.chkActiveTask.Name = "chkActiveTask";
            this.chkActiveTask.Size = new System.Drawing.Size(106, 17);
            this.chkActiveTask.TabIndex = 11;
            this.chkActiveTask.Text = "Задача активна";
            this.chkActiveTask.UseVisualStyleBackColor = true;
            // 
            // btnRunNow
            // 
            this.btnRunNow.Location = new System.Drawing.Point(425, 140);
            this.btnRunNow.Name = "btnRunNow";
            this.btnRunNow.Size = new System.Drawing.Size(119, 23);
            this.btnRunNow.TabIndex = 12;
            this.btnRunNow.Text = "Запустить сейчас";
            this.btnRunNow.UseVisualStyleBackColor = true;
            this.btnRunNow.Click += new System.EventHandler(this.btnRunNow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Рабочий каталог:";
            // 
            // txtWorkingDirectory
            // 
            this.txtWorkingDirectory.Location = new System.Drawing.Point(100, 62);
            this.txtWorkingDirectory.Name = "txtWorkingDirectory";
            this.txtWorkingDirectory.Size = new System.Drawing.Size(444, 20);
            this.txtWorkingDirectory.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbWindowStyleMinimized);
            this.groupBox1.Controls.Add(this.rbWindowStyleMaximized);
            this.groupBox1.Controls.Add(this.rbWindowStyleNormal);
            this.groupBox1.Location = new System.Drawing.Point(9, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 47);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид окна запускаемой программы:";
            // 
            // rbWindowStyleNormal
            // 
            this.rbWindowStyleNormal.AutoSize = true;
            this.rbWindowStyleNormal.Checked = true;
            this.rbWindowStyleNormal.Location = new System.Drawing.Point(6, 19);
            this.rbWindowStyleNormal.Name = "rbWindowStyleNormal";
            this.rbWindowStyleNormal.Size = new System.Drawing.Size(91, 17);
            this.rbWindowStyleNormal.TabIndex = 7;
            this.rbWindowStyleNormal.TabStop = true;
            this.rbWindowStyleNormal.Text = "Нормальный";
            this.rbWindowStyleNormal.UseVisualStyleBackColor = true;
            // 
            // rbWindowStyleMaximized
            // 
            this.rbWindowStyleMaximized.AutoSize = true;
            this.rbWindowStyleMaximized.Location = new System.Drawing.Point(103, 19);
            this.rbWindowStyleMaximized.Name = "rbWindowStyleMaximized";
            this.rbWindowStyleMaximized.Size = new System.Drawing.Size(92, 17);
            this.rbWindowStyleMaximized.TabIndex = 8;
            this.rbWindowStyleMaximized.Text = "Развернутый";
            this.rbWindowStyleMaximized.UseVisualStyleBackColor = true;
            // 
            // rbWindowStyleMinimized
            // 
            this.rbWindowStyleMinimized.AutoSize = true;
            this.rbWindowStyleMinimized.Location = new System.Drawing.Point(201, 19);
            this.rbWindowStyleMinimized.Name = "rbWindowStyleMinimized";
            this.rbWindowStyleMinimized.Size = new System.Drawing.Size(80, 17);
            this.rbWindowStyleMinimized.TabIndex = 9;
            this.rbWindowStyleMinimized.Text = "Свернутый";
            this.rbWindowStyleMinimized.UseVisualStyleBackColor = true;
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 196);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtWorkingDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRunNow);
            this.Controls.Add(this.chkActiveTask);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkAsAdmin);
            this.Controls.Add(this.txtParameters);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtTaskPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить задачу";
            this.Load += new System.EventHandler(this.frmAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.TextBox txtTaskPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox txtParameters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAsAdmin;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.CheckBox chkActiveTask;
        private System.Windows.Forms.Button btnRunNow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWorkingDirectory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbWindowStyleNormal;
        private System.Windows.Forms.RadioButton rbWindowStyleMinimized;
        private System.Windows.Forms.RadioButton rbWindowStyleMaximized;
    }
}