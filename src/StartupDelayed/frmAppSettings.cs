using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StartupDelayed
{
    public partial class frmAppSettings : Form
    {
        public frmAppSettings()
        {
            InitializeComponent();
        }
        
        public AppSettingsManager ASM = null;
        FormWorker fw = null;

        private void frmAppSettings_Load(object sender, EventArgs e)
        {
            if (!ASM.LoadConfig())
            {
                MessageBox.Show(ASM.ConfigError, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            fw = new FormWorker(ASM.Settings, this);
            fw.FillForm();
        }

        private void txtCheckTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ввод только цифр
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!fw.GetData())
            {
                MessageBox.Show(fw.ErrorMessage, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (!ASM.SaveConfig())
            {
                MessageBox.Show(ASM.ConfigError, "Error", MessageBoxButtons.OK,
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

        private void btnStartup_Click(object sender, EventArgs e)
        {
            try
            {
                StartupProgramm.AddToStartup();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Описание ошибки: " + ex.Message,
                    "Ошибка создания ярлыка автозагрузки", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            MessageBox.Show("Создан ярлык в автозагрузке текущего пользователя",
                 "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
