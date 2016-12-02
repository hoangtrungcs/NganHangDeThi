namespace StudentTesting {
    partial class ResultForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.testResult1 = new StudentTesting.TestResult();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radButton1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 380);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(621, 41);
            this.radPanel1.TabIndex = 0;
            // 
            // testResult1
            // 
            this.testResult1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testResult1.Location = new System.Drawing.Point(0, 0);
            this.testResult1.Name = "testResult1";
            this.testResult1.Size = new System.Drawing.Size(621, 380);
            this.testResult1.TabIndex = 1;
            // 
            // radButton1
            // 
            this.radButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton1.Location = new System.Drawing.Point(516, 4);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(102, 32);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "Dong";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 421);
            this.Controls.Add(this.testResult1);
            this.Controls.Add(this.radPanel1);
            this.Name = "ResultForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "KET QUA BAI THI";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private TestResult testResult1;
    }
}