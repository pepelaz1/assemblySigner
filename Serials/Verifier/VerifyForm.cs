using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Verifier
{
    public partial class VerifyForm : Form
    {
        public VerifyForm()
        {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            Enabled = false;
            using (SerialVerifier sv = new SerialVerifier())
            {
                if (sv.Verify(tbSerial.Text) == true)
                {
                    tbSerial.Text = sv.Serial;
                    MessageBox.Show("Serial is ok");
                }
                else
                    MessageBox.Show("Serial is wrong");
            }
            Enabled = true;
        }
    }
}
