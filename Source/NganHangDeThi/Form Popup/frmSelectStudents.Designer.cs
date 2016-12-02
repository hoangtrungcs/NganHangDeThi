namespace NganHangDeThi.Form_Popup
{
    partial class frmSelectStudents
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grvStudents = new Telerik.WinControls.UI.RadGridView();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStudents.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 524F));
            this.tableLayoutPanel1.Controls.Add(this.grvStudents, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 474);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grvStudents
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grvStudents, 2);
            this.grvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvStudents.Location = new System.Drawing.Point(3, 3);
            // 
            // grvStudents
            // 
            this.grvStudents.MasterTemplate.AllowAddNewRow = false;
            this.grvStudents.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "StudentNo";
            gridViewTextBoxColumn1.FormatString = "";
            gridViewTextBoxColumn1.HeaderText = "Mã sinh viên";
            gridViewTextBoxColumn1.Name = "colStudentNo";
            gridViewTextBoxColumn1.Width = 117;
            gridViewTextBoxColumn2.FieldName = "FullName";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Họ tên";
            gridViewTextBoxColumn2.Name = "colFullName";
            gridViewTextBoxColumn2.Width = 245;
            gridViewTextBoxColumn3.FieldName = "Email";
            gridViewTextBoxColumn3.FormatString = "";
            gridViewTextBoxColumn3.HeaderText = "Email";
            gridViewTextBoxColumn3.Name = "colEmail";
            gridViewTextBoxColumn3.Width = 58;
            gridViewTextBoxColumn4.FieldName = "Phone";
            gridViewTextBoxColumn4.FormatString = "";
            gridViewTextBoxColumn4.HeaderText = "Điện thoại";
            gridViewTextBoxColumn4.Name = "colPhone";
            gridViewTextBoxColumn4.Width = 99;
            gridViewTextBoxColumn5.FieldName = "UserName";
            gridViewTextBoxColumn5.FormatString = "";
            gridViewTextBoxColumn5.HeaderText = "User name";
            gridViewTextBoxColumn5.Name = "colUserName";
            gridViewTextBoxColumn5.Width = 102;
            gridViewImageColumn1.FieldName = "Images";
            gridViewImageColumn1.FormatString = "";
            gridViewImageColumn1.HeaderText = "Hình ảnh";
            gridViewImageColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            gridViewImageColumn1.Name = "colImages";
            gridViewImageColumn1.Width = 113;
            this.grvStudents.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewImageColumn1});
            this.grvStudents.Name = "grvStudents";
            this.grvStudents.Size = new System.Drawing.Size(750, 417);
            this.grvStudents.TabIndex = 24;
            this.grvStudents.Text = "radGridView1";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(653, 431);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOK.Location = new System.Drawing.Point(3, 431);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 40);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Chọn";
            this.btnOK.Click += new System.EventHandler(this.OnAccept);
            // 
            // frmSelectStudents
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(756, 474);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSelectStudents";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn sinh viên";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.OnLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvStudents.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadButton btnOK;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadGridView grvStudents;
    }
}
