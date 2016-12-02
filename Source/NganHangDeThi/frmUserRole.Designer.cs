namespace NganHangDeThi
{
    partial class frmUserRole
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
            this.radDock1 = new Telerik.WinControls.UI.Docking.RadDock();
            this.toolWindow1 = new Telerik.WinControls.UI.Docking.ToolWindow();
            this.m_lstUsers = new Telerik.WinControls.UI.RadListControl();
            this.toolTabStrip1 = new Telerik.WinControls.UI.Docking.ToolTabStrip();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.documentTabStrip1 = new Telerik.WinControls.UI.Docking.DocumentTabStrip();
            this.documentWindow1 = new Telerik.WinControls.UI.Docking.DocumentWindow();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.m_subjectGrid = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.m_treeUserRole = new Telerik.WinControls.UI.RadTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).BeginInit();
            this.radDock1.SuspendLayout();
            this.toolWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_lstUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).BeginInit();
            this.toolTabStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.documentContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).BeginInit();
            this.documentTabStrip1.SuspendLayout();
            this.documentWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            this.radGridView1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_subjectGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_subjectGrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_treeUserRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radDock1
            // 
            this.radDock1.ActiveWindow = this.documentWindow1;
            this.radDock1.Controls.Add(this.toolTabStrip1);
            this.radDock1.Controls.Add(this.documentContainer1);
            this.radDock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDock1.DocumentManager.DocumentInsertOrder = Telerik.WinControls.UI.Docking.DockWindowInsertOrder.InFront;
            this.radDock1.IsCleanUpTarget = true;
            this.radDock1.Location = new System.Drawing.Point(0, 0);
            this.radDock1.MainDocumentContainer = this.documentContainer1;
            this.radDock1.Name = "radDock1";
            this.radDock1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.radDock1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radDock1.RootElement.Padding = new System.Windows.Forms.Padding(5);
            this.radDock1.Size = new System.Drawing.Size(1103, 746);
            this.radDock1.SplitterWidth = 4;
            this.radDock1.TabIndex = 0;
            this.radDock1.TabStop = false;
            this.radDock1.Text = "radDock1";
            // 
            // toolWindow1
            // 
            this.toolWindow1.Caption = null;
            this.toolWindow1.Controls.Add(this.m_lstUsers);
            this.toolWindow1.Location = new System.Drawing.Point(1, 24);
            this.toolWindow1.Name = "toolWindow1";
            this.toolWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.Docked;
            this.toolWindow1.Size = new System.Drawing.Size(198, 710);
            this.toolWindow1.Text = "User";
            // 
            // m_lstUsers
            // 
            this.m_lstUsers.AutoSizeItems = true;
            this.m_lstUsers.CaseSensitiveSort = true;
            this.m_lstUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lstUsers.ItemHeight = 18;
            this.m_lstUsers.Location = new System.Drawing.Point(0, 0);
            this.m_lstUsers.Name = "m_lstUsers";
            this.m_lstUsers.Size = new System.Drawing.Size(198, 710);
            this.m_lstUsers.TabIndex = 0;
            this.m_lstUsers.Text = "radListView1";
            this.m_lstUsers.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.SelectedUserChanged);
            this.m_lstUsers.SelectedIndexChanging += new Telerik.WinControls.UI.Data.PositionChangingEventHandler(this.SelectedUserChanging);
            // 
            // toolTabStrip1
            // 
            this.toolTabStrip1.Controls.Add(this.toolWindow1);
            this.toolTabStrip1.Location = new System.Drawing.Point(5, 5);
            this.toolTabStrip1.Name = "toolTabStrip1";
            // 
            // 
            // 
            this.toolTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.toolTabStrip1.SelectedIndex = 0;
            this.toolTabStrip1.Size = new System.Drawing.Size(200, 736);
            this.toolTabStrip1.TabIndex = 1;
            this.toolTabStrip1.TabStop = false;
            // 
            // documentContainer1
            // 
            this.documentContainer1.Controls.Add(this.documentTabStrip1);
            this.documentContainer1.Location = new System.Drawing.Point(209, 5);
            this.documentContainer1.Name = "documentContainer1";
            this.documentContainer1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer1.RootElement.Padding = new System.Windows.Forms.Padding(5);
            this.documentContainer1.Size = new System.Drawing.Size(889, 736);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SplitterWidth = 4;
            this.documentContainer1.TabIndex = 0;
            this.documentContainer1.TabStop = false;
            // 
            // documentTabStrip1
            // 
            this.documentTabStrip1.Controls.Add(this.documentWindow1);
            this.documentTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.documentTabStrip1.Name = "documentTabStrip1";
            // 
            // 
            // 
            this.documentTabStrip1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentTabStrip1.SelectedIndex = 0;
            this.documentTabStrip1.Size = new System.Drawing.Size(889, 736);
            this.documentTabStrip1.TabIndex = 0;
            this.documentTabStrip1.TabStop = false;
            // 
            // documentWindow1
            // 
            this.documentWindow1.Controls.Add(this.radGridView1);
            this.documentWindow1.Location = new System.Drawing.Point(6, 29);
            this.documentWindow1.Name = "documentWindow1";
            this.documentWindow1.PreviousDockState = Telerik.WinControls.UI.Docking.DockState.TabbedDocument;
            this.documentWindow1.Size = new System.Drawing.Size(877, 701);
            this.documentWindow1.Text = "Quyen";
            // 
            // radGridView1
            // 
            this.radGridView1.Controls.Add(this.splitContainer1);
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(0, 0);
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(877, 701);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.Text = "radGridView1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.radGroupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.radGroupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(877, 701);
            this.splitContainer1.SplitterDistance = 553;
            this.splitContainer1.TabIndex = 1;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.m_subjectGrid);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.FooterImageIndex = -1;
            this.radGroupBox1.FooterImageKey = "";
            this.radGroupBox1.HeaderImageIndex = -1;
            this.radGroupBox1.HeaderImageKey = "";
            this.radGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox1.HeaderText = "Quyền Trên Môn Học";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            // 
            // 
            // 
            this.radGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox1.Size = new System.Drawing.Size(553, 701);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Quyền Trên Môn Học";
            // 
            // m_subjectGrid
            // 
            this.m_subjectGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_subjectGrid.Location = new System.Drawing.Point(2, 18);
            this.m_subjectGrid.Name = "m_subjectGrid";
            this.m_subjectGrid.Size = new System.Drawing.Size(549, 681);
            this.m_subjectGrid.TabIndex = 0;
            this.m_subjectGrid.Text = "radGridView2";
            this.m_subjectGrid.ValueChanged += new System.EventHandler(this.OnRoleChanged);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.m_treeUserRole);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox2.FooterImageIndex = -1;
            this.radGroupBox2.FooterImageKey = "";
            this.radGroupBox2.HeaderImageIndex = -1;
            this.radGroupBox2.HeaderImageKey = "";
            this.radGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox2.HeaderText = "Quyền Chức Năng";
            this.radGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            // 
            // 
            // 
            this.radGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox2.Size = new System.Drawing.Size(320, 701);
            this.radGroupBox2.TabIndex = 0;
            this.radGroupBox2.Text = "Quyền Chức Năng";
            // 
            // m_treeUserRole
            // 
            this.m_treeUserRole.CheckBoxes = true;
            this.m_treeUserRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_treeUserRole.Location = new System.Drawing.Point(2, 18);
            this.m_treeUserRole.Name = "m_treeUserRole";
            this.m_treeUserRole.Size = new System.Drawing.Size(316, 681);
            this.m_treeUserRole.SpacingBetweenNodes = -1;
            this.m_treeUserRole.TabIndex = 0;
            this.m_treeUserRole.Text = "radTreeView1";
            this.m_treeUserRole.TriStateMode = true;
            // 
            // frmUserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 746);
            this.Controls.Add(this.radDock1);
            this.Name = "frmUserRole";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Phân quyền";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmUserRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radDock1)).EndInit();
            this.radDock1.ResumeLayout(false);
            this.toolWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_lstUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolTabStrip1)).EndInit();
            this.toolTabStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.documentContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentTabStrip1)).EndInit();
            this.documentTabStrip1.ResumeLayout(false);
            this.documentWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.radGridView1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_subjectGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_subjectGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_treeUserRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.Docking.RadDock radDock1;
        private Telerik.WinControls.UI.Docking.ToolWindow toolWindow1;
        private Telerik.WinControls.UI.Docking.ToolTabStrip toolTabStrip1;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private Telerik.WinControls.UI.Docking.DocumentTabStrip documentTabStrip1;
        private Telerik.WinControls.UI.Docking.DocumentWindow documentWindow1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadListControl m_lstUsers;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView m_subjectGrid;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadTreeView m_treeUserRole;

    }
}
