using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace StartupDelayed
{
    public partial class frmConfigFiles : Form
    {
        public frmConfigFiles()
        {
            InitializeComponent();
        }

        public AppSettingsManager SetMan = null;

        private void frmConfigFiles_Load(object sender, EventArgs e)
        {
            txtConfigDir.Text = SetMan.configDir;
            txtConfigFile.Text = SetMan.configFile.Replace(SetMan.configDir,"");
            txtTasksFile.Text = SetMan.TasksFile.Replace(SetMan.configDir, "");
            
            bool first = true;
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                if (first)
                {
                    first = false;
                    continue;
                }
                txtArguments.Text += arg + " ";
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult Ans = dlgFolder.ShowDialog();
            if (Ans == DialogResult.Cancel) return;
            string folder = dlgFolder.SelectedPath;

            try
            {
                File.Copy(CommonClass.AddSlash(txtConfigDir.Text) + txtConfigFile.Text,
                    CommonClass.AddSlash(folder) + txtConfigFile.Text,true);
                File.Copy(CommonClass.AddSlash(txtConfigDir.Text) + txtConfigFile.Text,
                    CommonClass.AddSlash(folder) + txtTasksFile.Text,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                return;
            }

            MessageBox.Show("Файлы сохранены", "OK", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
        
    }
}
