using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StartupDelayed
{
    public partial class frmCLIHelp : Form
    {
        public frmCLIHelp()
        {
            InitializeComponent();
        }

        private void frmCLIHelp_Load(object sender, EventArgs e)
        {
            txtHelp.Text = Properties.Resources.cl_help;
            txtHelp.SelectionStart = 0;
        }
    }
}
