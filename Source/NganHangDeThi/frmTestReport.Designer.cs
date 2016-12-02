namespace NganHangDeThi {
    partial class frmTestReport {
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
            this.rpViewer = new Telerik.ReportViewer.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rpViewer
            // 
            this.rpViewer.AutoSize = true;
            this.rpViewer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rpViewer.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.rpViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rpViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpViewer.Location = new System.Drawing.Point(0, 0);
            this.rpViewer.Name = "rpViewer";
            this.rpViewer.ParametersAreaVisible = false;
            this.rpViewer.Size = new System.Drawing.Size(619, 400);
            this.rpViewer.TabIndex = 0;
            this.rpViewer.ViewMode = Telerik.ReportViewer.WinForms.ViewMode.PrintPreview;
            // 
            // frmMultiTestReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 400);
            this.Controls.Add(this.rpViewer);
            this.Name = "frmMultiTestReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "De thi tong hop";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer rpViewer;
    }
}