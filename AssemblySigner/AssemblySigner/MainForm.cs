using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mono.Security;
using System.IO;
using System.Diagnostics;

namespace AssemblySinger
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (dlgAssembly.ShowDialog() == DialogResult.OK && dlgAssembly.FileName != "")
            {
                tbAssembly.Text = dlgAssembly.FileName;
            }
        }

        private void btnBrowseKey_Click(object sender, EventArgs e)
        {
            if (dlgKey.ShowDialog() == DialogResult.OK && dlgKey.FileName != "")
            {
                tbKeyfile.Text = dlgKey.FileName;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            try
            {
                Signer s = new Signer();
                Boolean result = Signer.ReSign(tbAssembly.Text, tbKeyfile.Text, tbPassword.Text);
                if (result == true)
                    MessageBox.Show("Assembly successfully resigned");
                else
                    MessageBox.Show("Fail to resign assembly");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnSign.Select();
        }
    }
}
