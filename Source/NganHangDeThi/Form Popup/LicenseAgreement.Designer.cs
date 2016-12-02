namespace NganHangDeThi.Form_Popup
{
    partial class ResizeImageInRichTextBox
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
        
            this.textBox1.Location = new System.Drawing.Point(113, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(358, 20);
            this.textBox1.TabIndex = 1;
         
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(113, 85);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(358, 52);
            this.textBox2.TabIndex = 11;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(477, 48);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(73, 20);
            this.radButton1.TabIndex = 12;
            this.radButton1.Text = "Copy";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(477, 85);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(73, 20);
            this.radButton2.TabIndex = 13;
            this.radButton2.Text = "Đăng Kí";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // LicenseAgreement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 177);
            this.Controls.Add(this.textBox2);
          
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
    }
}
