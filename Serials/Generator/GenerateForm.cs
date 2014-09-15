using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Generator
{
    public partial class GenerateForm : Form
    {
        public GenerateForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Enabled = false;
            using (SerialGenerator gen = new SerialGenerator((int)udSeed.Value, (int)udStartMember.Value))
            {
                gen.Generate();
            }
            MessageBox.Show("Generation finished");
            Enabled = true;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            Enabled = false;
            using (SerialGenerator gen = new SerialGenerator((int)udSeed.Value, (int)udStartMember.Value))
            {
                tbSerial.Text = gen.GetByNumber((int)udSeriaNum.Value);
            }
            Enabled = true;
        }

        private void GenerateForm_Load(object sender, EventArgs e)
        {
            using (SerialGenerator gen = new SerialGenerator())
            {
                udSeriaNum.Maximum = (decimal)gen.SerialsCount-1;
                udSeed.Value = (decimal)gen.Seed;
                udStartMember.Value = (decimal)gen.StartMember;
            }            
        }
    }
}
