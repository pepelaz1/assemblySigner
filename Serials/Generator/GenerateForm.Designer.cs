namespace Generator
{
    partial class GenerateForm
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.udSeriaNum = new System.Windows.Forms.NumericUpDown();
            this.tbSerial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSeed = new System.Windows.Forms.Label();
            this.udSeed = new System.Windows.Forms.NumericUpDown();
            this.udStartMember = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.udSeriaNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udStartMember)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(418, 5);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(93, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate all";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(215, 39);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(93, 23);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "Get by number";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // udSeriaNum
            // 
            this.udSeriaNum.Location = new System.Drawing.Point(89, 41);
            this.udSeriaNum.Name = "udSeriaNum";
            this.udSeriaNum.Size = new System.Drawing.Size(120, 20);
            this.udSeriaNum.TabIndex = 3;
            // 
            // tbSerial
            // 
            this.tbSerial.Location = new System.Drawing.Point(8, 78);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.ReadOnly = true;
            this.tbSerial.Size = new System.Drawing.Size(503, 20);
            this.tbSerial.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Serial number";
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.Location = new System.Drawing.Point(12, 9);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(61, 13);
            this.lblSeed.TabIndex = 6;
            this.lblSeed.Text = "Seed value";
            // 
            // udSeed
            // 
            this.udSeed.Location = new System.Drawing.Point(89, 7);
            this.udSeed.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.udSeed.Name = "udSeed";
            this.udSeed.Size = new System.Drawing.Size(120, 20);
            this.udSeed.TabIndex = 7;
            // 
            // udStartMember
            // 
            this.udStartMember.Location = new System.Drawing.Point(292, 7);
            this.udStartMember.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.udStartMember.Name = "udStartMember";
            this.udStartMember.Size = new System.Drawing.Size(120, 20);
            this.udStartMember.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Start member";
            // 
            // GenerateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 112);
            this.Controls.Add(this.udStartMember);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.udSeed);
            this.Controls.Add(this.lblSeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSerial);
            this.Controls.Add(this.udSeriaNum);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnGenerate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serials generator";
            this.Load += new System.EventHandler(this.GenerateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.udSeriaNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udStartMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.NumericUpDown udSeriaNum;
        private System.Windows.Forms.TextBox tbSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSeed;
        private System.Windows.Forms.NumericUpDown udSeed;
        private System.Windows.Forms.NumericUpDown udStartMember;
        private System.Windows.Forms.Label label2;
    }
}

