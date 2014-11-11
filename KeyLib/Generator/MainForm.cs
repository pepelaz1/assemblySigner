using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeyLib;

namespace Generator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

    
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            RegKey rk = new RegKey();
            rk.Generate();
            tbKey.Text = rk.Key;
            tbHash.Text = rk.Hash;
        }

        private void tbHash_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
