namespace AssemblySinger
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbAssembly = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dlgAssembly = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.tbKeyfile = new System.Windows.Forms.TextBox();
            this.btnBrowseKey = new System.Windows.Forms.Button();
            this.dlgKey = new System.Windows.Forms.OpenFileDialog();
            this.btnSign = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Target assembly:";
            // 
            // tbAssembly
            // 
            this.tbAssembly.Location = new System.Drawing.Point(105, 21);
            this.tbAssembly.Name = "tbAssembly";
            this.tbAssembly.Size = new System.Drawing.Size(409, 20);
            this.tbAssembly.TabIndex = 1;
            this.tbAssembly.Text = "D:\\Work\\MRoger\\AssemblySinger\\bin\\Debug\\TestAssembly.dll";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(512, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(26, 22);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // dlgAssembly
            // 
            this.dlgAssembly.Filter = "Assembles (*.dll;*exe)|*.dll;*.exe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Keypair file:";
            // 
            // tbKeyfile
            // 
            this.tbKeyfile.Location = new System.Drawing.Point(105, 56);
            this.tbKeyfile.Name = "tbKeyfile";
            this.tbKeyfile.Size = new System.Drawing.Size(409, 20);
            this.tbKeyfile.TabIndex = 4;
            this.tbKeyfile.Text = "D:\\Work\\MRoger\\AssemblySinger\\bin\\Debug\\key.snk";
            // 
            // btnBrowseKey
            // 
            this.btnBrowseKey.Location = new System.Drawing.Point(512, 55);
            this.btnBrowseKey.Name = "btnBrowseKey";
            this.btnBrowseKey.Size = new System.Drawing.Size(26, 21);
            this.btnBrowseKey.TabIndex = 5;
            this.btnBrowseKey.Text = "...";
            this.btnBrowseKey.UseVisualStyleBackColor = true;
            this.btnBrowseKey.Click += new System.EventHandler(this.btnBrowseKey_Click);
            // 
            // dlgKey
            // 
            this.dlgKey.Filter = "Key files (*.pfx)|*.pfx|Snk files (*.snk)|*.snk";
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(233, 131);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(75, 23);
            this.btnSign.TabIndex = 6;
            this.btnSign.Text = "Sign/Resign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password for Pfx:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(105, 95);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(409, 20);
            this.tbPassword.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 166);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.btnBrowseKey);
            this.Controls.Add(this.tbKeyfile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbAssembly);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assembly singer applcation";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAssembly;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog dlgAssembly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbKeyfile;
        private System.Windows.Forms.Button btnBrowseKey;
        private System.Windows.Forms.OpenFileDialog dlgKey;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
    }
}

