namespace MRogerApp
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
            this.btnCallFn1 = new System.Windows.Forms.Button();
            this.tbXml = new System.Windows.Forms.TextBox();
            this.btnCallFn2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbAssemblies = new System.Windows.Forms.ListBox();
            this.btnCallFn3 = new System.Windows.Forms.Button();
            this.tbDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCallFn1
            // 
            this.btnCallFn1.Location = new System.Drawing.Point(12, 24);
            this.btnCallFn1.Name = "btnCallFn1";
            this.btnCallFn1.Size = new System.Drawing.Size(88, 23);
            this.btnCallFn1.TabIndex = 0;
            this.btnCallFn1.Text = "Call function 1";
            this.btnCallFn1.UseVisualStyleBackColor = true;
            this.btnCallFn1.Click += new System.EventHandler(this.btnCallFn1_Click);
            // 
            // tbXml
            // 
            this.tbXml.Location = new System.Drawing.Point(125, 44);
            this.tbXml.Multiline = true;
            this.tbXml.Name = "tbXml";
            this.tbXml.Size = new System.Drawing.Size(593, 109);
            this.tbXml.TabIndex = 1;
            // 
            // btnCallFn2
            // 
            this.btnCallFn2.Location = new System.Drawing.Point(12, 177);
            this.btnCallFn2.Name = "btnCallFn2";
            this.btnCallFn2.Size = new System.Drawing.Size(88, 23);
            this.btnCallFn2.TabIndex = 2;
            this.btnCallFn2.Text = "Call function 2";
            this.btnCallFn2.UseVisualStyleBackColor = true;
            this.btnCallFn2.Click += new System.EventHandler(this.btnCallFn2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Loaded assemblies";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Xml";
            // 
            // lbAssemblies
            // 
            this.lbAssemblies.FormattingEnabled = true;
            this.lbAssemblies.Location = new System.Drawing.Point(129, 196);
            this.lbAssemblies.Name = "lbAssemblies";
            this.lbAssemblies.Size = new System.Drawing.Size(589, 121);
            this.lbAssemblies.TabIndex = 6;
            // 
            // btnCallFn3
            // 
            this.btnCallFn3.Location = new System.Drawing.Point(12, 335);
            this.btnCallFn3.Name = "btnCallFn3";
            this.btnCallFn3.Size = new System.Drawing.Size(88, 23);
            this.btnCallFn3.TabIndex = 7;
            this.btnCallFn3.Text = "Call function 3";
            this.btnCallFn3.UseVisualStyleBackColor = true;
            this.btnCallFn3.Click += new System.EventHandler(this.btnCallFn3_Click);
            // 
            // tbDir
            // 
            this.tbDir.Location = new System.Drawing.Point(129, 355);
            this.tbDir.Name = "tbDir";
            this.tbDir.Size = new System.Drawing.Size(589, 20);
            this.tbDir.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Directory extracted to";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 391);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDir);
            this.Controls.Add(this.btnCallFn3);
            this.Controls.Add(this.lbAssemblies);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCallFn2);
            this.Controls.Add(this.tbXml);
            this.Controls.Add(this.btnCallFn1);
            this.Name = "MainForm";
            this.Text = "Main form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCallFn1;
        private System.Windows.Forms.TextBox tbXml;
        private System.Windows.Forms.Button btnCallFn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbAssemblies;
        private System.Windows.Forms.Button btnCallFn3;
        private System.Windows.Forms.TextBox tbDir;
        private System.Windows.Forms.Label label3;
    }
}

