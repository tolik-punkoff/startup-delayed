using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StartupDelayed
{
    public partial class frmAdd : Form
    {
        public bool IsEdit = false;
        public object idValue = null;
        public MainDataSet dsMain = null;

        FormWorker fw = null;

        public frmAdd()
        {
            InitializeComponent();
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            fw = new FormWorker(dsMain, "StartupTasks", this);
            if (IsEdit)
            {
                this.Text = "Редактировать задачу [ID: " + idValue + "]";
                if (!fw.FillFormFromDataSet(idValue))
                {
                    MessageBox.Show(fw.ErrorMessage, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //string.IsNullOrEmpty(txtTaskPath.Text.Trim())
            string wp = CommonClass.WrongPath(txtTaskPath.Text.Trim());
            if (wp != string.Empty)
            {
                MessageBox.Show("Ошибка в поле 'Путь': " + wp, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (string.IsNullOrEmpty(txtTaskName.Text.Trim()))
            {
                MessageBox.Show("Заполните 'Название'", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }            

            if (!System.IO.File.Exists(txtTaskPath.Text.Trim()))
            {
                DialogResult Ans = MessageBox.Show("В данный момент файл " 
                    + txtTaskPath.Text.Trim()+
                    " не найден. Все равно продолжить?",
                    "Вопрос", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (Ans == DialogResult.No) return;                
            }
            
            bool Res = false;
            if (IsEdit)
                Res = fw.AddOrEditRow(idValue);                
            else
                Res = fw.AddOrEditRow(null);

            if (!Res)
            {
                MessageBox.Show(fw.ErrorMessage, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult Ans = dlgOpen.ShowDialog();
            if (Ans == DialogResult.OK)
            {
                txtTaskPath.Text = dlgOpen.FileName;
                int lslash = txtTaskPath.Text.LastIndexOf('\\');
                txtWorkingDirectory.Text = txtTaskPath.Text.Substring(0, lslash+1);
            }
        }

        private void btnRunNow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaskPath.Text.Trim()))
            {
                MessageBox.Show("Заполните 'Путь'", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            StartupTask tmpTask = new StartupTask(txtTaskPath.Text);
            tmpTask.AsAdmin = chkAsAdmin.Checked;
            tmpTask.Parameters = txtParameters.Text;
            tmpTask.WorkingDirectory = txtWorkingDirectory.Text;
            if (!tmpTask.Exist())
            {
                MessageBox.Show("В данный момент файл "+txtTaskPath.Text+
                    " отсутствует.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            if (!tmpTask.Run())
            {
                MessageBox.Show(tmpTask.ErrorMessage, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
