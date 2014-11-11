using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeyLib;

namespace Verifier
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (RegKey.Verify(tbKey.Text, tbHash.Text) == true)
                MessageBox.Show("OK");
            else
                MessageBox.Show("Failed");
        }
    }
}
