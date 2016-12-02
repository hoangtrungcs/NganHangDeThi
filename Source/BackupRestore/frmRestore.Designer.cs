namespace BackupRestore
{
    partial class frmRestore
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnRestore = new Telerik.WinControls.UI.RadButton();
            this.txtFilePath = new Telerik.WinControls.UI.RadTextBox();
            this.btnBrowse = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radLabel1.Location = new System.Drawing.Point(5, 9);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.AccessibleDescription = null;
            this.radLabel1.RootElement.AccessibleName = null;
            this.radLabel1.Size = new System.Drawing.Size(68, 18);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Chọn tập tin";
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRestore.Location = new System.Drawing.Point(369, 33);
            this.btnRestore.Name = "btnRestore";
            // 
            // 
            // 
            this.btnRestore.RootElement.AccessibleDescription = null;
            this.btnRestore.RootElement.AccessibleName = null;
            this.btnRestore.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 130, 24);
            this.btnRestore.Size = new System.Drawing.Size(130, 50);
            this.btnRestore.TabIndex = 6;
            this.btnRestore.Text = "Phục hồi";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFilePath.Location = new System.Drawing.Point(75, 7);
            this.txtFilePath.Name = "txtFilePath";
            // 
            // 
            // 
            this.txtFilePath.RootElement.AccessibleDescription = null;
            this.txtFilePath.RootElement.AccessibleName = null;
            this.txtFilePath.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 100, 20);
            this.txtFilePath.RootElement.StretchVertically = true;
            this.txtFilePath.Size = new System.Drawing.Size(405, 20);
            this.txtFilePath.TabIndex = 5;
            this.txtFilePath.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBrowse.Location = new System.Drawing.Point(479, 7);
            this.btnBrowse.Name = "btnBrowse";
            // 
            // 
            // 
            this.btnBrowse.RootElement.AccessibleDescription = null;
            this.btnBrowse.RootElement.AccessibleName = null;
            this.btnBrowse.RootElement.ControlBounds = new System.Drawing.Rectangle(0, 0, 130, 24);
            this.btnBrowse.Size = new System.Drawing.Size(20, 20);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "...";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // frmRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 86);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnBrowse);
            this.Name = "frmRestore";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phục hồi dữ liệu";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnRestore;
        private Telerik.WinControls.UI.RadTextBox txtFilePath;
        private Telerik.WinControls.UI.RadButton btnBrowse;
    }
}
