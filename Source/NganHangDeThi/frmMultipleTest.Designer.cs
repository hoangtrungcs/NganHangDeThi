using Controller.Services;
using Model.POCO;

namespace NganHangDeThi
{
    partial class frmMultipleTest 
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.grpCurrentSubject = new Telerik.WinControls.UI.RadGroupBox();
            this.lstSelectedSubject = new Telerik.WinControls.UI.RadListView();
            this.btnNext = new Telerik.WinControls.UI.RadButton();
            this.btnPre = new Telerik.WinControls.UI.RadButton();
            this.grpTestInfo = new Telerik.WinControls.UI.RadGroupBox();
            this.ddlPurpose = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.txtTestName = new Telerik.WinControls.UI.RadTextBox();
            this.txtTestNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.speTotalQuestion = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.speTestTime = new Telerik.WinControls.UI.RadSpinEditor();
            this.speSubTest = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.dtpTestDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.speHardQuestion = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.speNormalQuestion = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.speEasyQuestion = new Telerik.WinControls.UI.RadSpinEditor();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.grpAllSubject = new Telerik.WinControls.UI.RadGroupBox();
            this.lstAllSubject = new Telerik.WinControls.UI.RadListView();
            this.btnCreateTest = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.m_gridTests = new Telerik.WinControls.UI.RadGridView();
            this.grpLevel = new Telerik.WinControls.UI.RadGroupBox();
            this.chkIsNotSame = new Telerik.WinControls.UI.RadCheckBox();
            this.cbbClassMixedTest = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.dropdownClass = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.grpCurrentSubject)).BeginInit();
            this.grpCurrentSubject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstSelectedSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTestInfo)).BeginInit();
            this.grpTestInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPurpose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speTotalQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speTestTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speSubTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTestDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speHardQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speNormalQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speEasyQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAllSubject)).BeginInit();
            this.grpAllSubject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstAllSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridTests.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLevel)).BeginInit();
            this.grpLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsNotSame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbClassMixedTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbClassMixedTest.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbClassMixedTest.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCurrentSubject
            // 
            this.grpCurrentSubject.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.grpCurrentSubject.Controls.Add(this.lstSelectedSubject);
            this.grpCurrentSubject.FooterImageIndex = -1;
            this.grpCurrentSubject.FooterImageKey = "";
            this.grpCurrentSubject.HeaderImageIndex = -1;
            this.grpCurrentSubject.HeaderImageKey = "";
            this.grpCurrentSubject.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.grpCurrentSubject.HeaderText = "Các môn sẽ tạo đề thi";
            this.grpCurrentSubject.Location = new System.Drawing.Point(246, 5);
            this.grpCurrentSubject.Name = "grpCurrentSubject";
            this.grpCurrentSubject.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.grpCurrentSubject.Size = new System.Drawing.Size(200, 244);
            this.grpCurrentSubject.TabIndex = 1;
            this.grpCurrentSubject.Text = "Các môn sẽ tạo đề thi";
            // 
            // lstSelectedSubject
            // 
            this.lstSelectedSubject.AllowEdit = false;
            this.lstSelectedSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSelectedSubject.GroupItemSize = new System.Drawing.Size(200, 20);
            this.lstSelectedSubject.ItemSize = new System.Drawing.Size(200, 20);
            this.lstSelectedSubject.Location = new System.Drawing.Point(2, 18);
            this.lstSelectedSubject.MultiSelect = true;
            this.lstSelectedSubject.Name = "lstSelectedSubject";
            this.lstSelectedSubject.Size = new System.Drawing.Size(196, 224);
            this.lstSelectedSubject.TabIndex = 4;
            this.lstSelectedSubject.Text = "radListView2";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(206, 70);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(34, 24);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">>";
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(206, 105);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(34, 24);
            this.btnPre.TabIndex = 3;
            this.btnPre.Text = "<<";
            // 
            // grpTestInfo
            // 
            this.grpTestInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.grpTestInfo.Controls.Add(this.ddlPurpose);
            this.grpTestInfo.Controls.Add(this.radLabel10);
            this.grpTestInfo.Controls.Add(this.txtTestName);
            this.grpTestInfo.Controls.Add(this.txtTestNo);
            this.grpTestInfo.Controls.Add(this.radLabel1);
            this.grpTestInfo.Controls.Add(this.radLabel2);
            this.grpTestInfo.Controls.Add(this.speTotalQuestion);
            this.grpTestInfo.Controls.Add(this.radLabel6);
            this.grpTestInfo.Controls.Add(this.radLabel3);
            this.grpTestInfo.Controls.Add(this.radLabel5);
            this.grpTestInfo.Controls.Add(this.speTestTime);
            this.grpTestInfo.Controls.Add(this.speSubTest);
            this.grpTestInfo.Controls.Add(this.radLabel4);
            this.grpTestInfo.Controls.Add(this.dtpTestDate);
            this.grpTestInfo.FooterImageIndex = -1;
            this.grpTestInfo.FooterImageKey = "";
            this.grpTestInfo.HeaderImageIndex = -1;
            this.grpTestInfo.HeaderImageKey = "";
            this.grpTestInfo.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.grpTestInfo.HeaderText = "Thông tin đề thi";
            this.grpTestInfo.Location = new System.Drawing.Point(451, 43);
            this.grpTestInfo.Name = "grpTestInfo";
            this.grpTestInfo.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.grpTestInfo.Size = new System.Drawing.Size(656, 114);
            this.grpTestInfo.TabIndex = 4;
            this.grpTestInfo.Text = "Thông tin đề thi";
            // 
            // ddlPurpose
            // 
            this.ddlPurpose.DropDownAnimationEnabled = true;
            this.ddlPurpose.Location = new System.Drawing.Point(471, 74);
            this.ddlPurpose.MaxDropDownItems = 0;
            this.ddlPurpose.Name = "ddlPurpose";
            this.ddlPurpose.ShowImageInEditorArea = true;
            this.ddlPurpose.Size = new System.Drawing.Size(173, 20);
            this.ddlPurpose.TabIndex = 12;
            // 
            // radLabel10
            // 
            this.radLabel10.Location = new System.Drawing.Point(416, 76);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(52, 18);
            this.radLabel10.TabIndex = 16;
            this.radLabel10.Text = "Mục đích";
            // 
            // txtTestName
            // 
            this.txtTestName.Location = new System.Drawing.Point(247, 21);
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.Size = new System.Drawing.Size(155, 20);
            this.txtTestName.TabIndex = 6;
            this.txtTestName.TabStop = false;
            // 
            // txtTestNo
            // 
            this.txtTestNo.Location = new System.Drawing.Point(65, 21);
            this.txtTestNo.Name = "txtTestNo";
            this.txtTestNo.Size = new System.Drawing.Size(106, 20);
            this.txtTestNo.TabIndex = 5;
            this.txtTestNo.TabStop = false;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(5, 23);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(54, 18);
            this.radLabel1.TabIndex = 11;
            this.radLabel1.Text = "Mã đề thi";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(185, 23);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(56, 18);
            this.radLabel2.TabIndex = 12;
            this.radLabel2.Text = "Tên đề thi";
            // 
            // speTotalQuestion
            // 
            this.speTotalQuestion.Location = new System.Drawing.Point(65, 74);
            this.speTotalQuestion.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speTotalQuestion.Name = "speTotalQuestion";
            // 
            // 
            // 
            this.speTotalQuestion.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.speTotalQuestion.ShowBorder = true;
            this.speTotalQuestion.Size = new System.Drawing.Size(63, 20);
            this.speTotalQuestion.TabIndex = 8;
            this.speTotalQuestion.TabStop = false;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(5, 76);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(58, 18);
            this.radLabel6.TabIndex = 15;
            this.radLabel6.Text = "Số câu hỏi";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(274, 76);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(67, 18);
            this.radLabel3.TabIndex = 12;
            this.radLabel3.Text = "Số lượng đề";
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(147, 76);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(53, 18);
            this.radLabel5.TabIndex = 14;
            this.radLabel5.Text = "TG (phút)";
            // 
            // speTestTime
            // 
            this.speTestTime.Location = new System.Drawing.Point(206, 74);
            this.speTestTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speTestTime.Name = "speTestTime";
            // 
            // 
            // 
            this.speTestTime.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.speTestTime.ShowBorder = true;
            this.speTestTime.Size = new System.Drawing.Size(55, 20);
            this.speTestTime.TabIndex = 10;
            this.speTestTime.TabStop = false;
            // 
            // speSubTest
            // 
            this.speSubTest.Location = new System.Drawing.Point(346, 74);
            this.speSubTest.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.speSubTest.Name = "speSubTest";
            // 
            // 
            // 
            this.speSubTest.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.speSubTest.ShowBorder = true;
            this.speSubTest.Size = new System.Drawing.Size(55, 20);
            this.speSubTest.TabIndex = 11;
            this.speSubTest.TabStop = false;
            this.speSubTest.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(416, 23);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(49, 18);
            this.radLabel4.TabIndex = 13;
            this.radLabel4.Text = "Ngày thi";
            // 
            // dtpTestDate
            // 
            this.dtpTestDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpTestDate.Location = new System.Drawing.Point(471, 21);
            this.dtpTestDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTestDate.MinDate = new System.DateTime(((long)(0)));
            this.dtpTestDate.Name = "dtpTestDate";
            this.dtpTestDate.NullableValue = new System.DateTime(2013, 9, 8, 8, 58, 8, 987);
            this.dtpTestDate.NullDate = new System.DateTime(((long)(0)));
            this.dtpTestDate.Size = new System.Drawing.Size(173, 20);
            this.dtpTestDate.TabIndex = 7;
            this.dtpTestDate.TabStop = false;
            this.dtpTestDate.Text = "Sunday, September 8, 2013";
            this.dtpTestDate.Value = new System.DateTime(2013, 9, 8, 8, 58, 8, 987);
            // 
            // speHardQuestion
            // 
            this.speHardQuestion.Location = new System.Drawing.Point(346, 36);
            this.speHardQuestion.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speHardQuestion.Name = "speHardQuestion";
            // 
            // 
            // 
            this.speHardQuestion.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.speHardQuestion.ShowBorder = true;
            this.speHardQuestion.Size = new System.Drawing.Size(57, 20);
            this.speHardQuestion.TabIndex = 15;
            this.speHardQuestion.TabStop = false;
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(279, 38);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(61, 18);
            this.radLabel9.TabIndex = 17;
            this.radLabel9.Text = "Số câu khó";
            // 
            // speNormalQuestion
            // 
            this.speNormalQuestion.Location = new System.Drawing.Point(204, 37);
            this.speNormalQuestion.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speNormalQuestion.Name = "speNormalQuestion";
            // 
            // 
            // 
            this.speNormalQuestion.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.speNormalQuestion.ShowBorder = true;
            this.speNormalQuestion.Size = new System.Drawing.Size(57, 20);
            this.speNormalQuestion.TabIndex = 14;
            this.speNormalQuestion.TabStop = false;
            // 
            // radLabel8
            // 
            this.radLabel8.Location = new System.Drawing.Point(143, 39);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(55, 18);
            this.radLabel8.TabIndex = 12;
            this.radLabel8.Text = "Số câu TB";
            // 
            // speEasyQuestion
            // 
            this.speEasyQuestion.Location = new System.Drawing.Point(65, 37);
            this.speEasyQuestion.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speEasyQuestion.Name = "speEasyQuestion";
            // 
            // 
            // 
            this.speEasyQuestion.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.speEasyQuestion.ShowBorder = true;
            this.speEasyQuestion.Size = new System.Drawing.Size(63, 20);
            this.speEasyQuestion.TabIndex = 13;
            this.speEasyQuestion.TabStop = false;
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(4, 37);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(55, 18);
            this.radLabel7.TabIndex = 16;
            this.radLabel7.Text = "Số câu dễ";
            // 
            // grpAllSubject
            // 
            this.grpAllSubject.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.grpAllSubject.Controls.Add(this.lstAllSubject);
            this.grpAllSubject.FooterImageIndex = -1;
            this.grpAllSubject.FooterImageKey = "";
            this.grpAllSubject.HeaderImageIndex = -1;
            this.grpAllSubject.HeaderImageKey = "";
            this.grpAllSubject.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.grpAllSubject.HeaderText = "Danh sách môn học";
            this.grpAllSubject.Location = new System.Drawing.Point(0, 5);
            this.grpAllSubject.Name = "grpAllSubject";
            this.grpAllSubject.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.grpAllSubject.Size = new System.Drawing.Size(200, 244);
            this.grpAllSubject.TabIndex = 5;
            this.grpAllSubject.Text = "Danh sách môn học";
            // 
            // lstAllSubject
            // 
            this.lstAllSubject.AllowEdit = false;
            this.lstAllSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAllSubject.GroupItemSize = new System.Drawing.Size(200, 20);
            this.lstAllSubject.ItemSize = new System.Drawing.Size(200, 20);
            this.lstAllSubject.Location = new System.Drawing.Point(2, 18);
            this.lstAllSubject.MultiSelect = true;
            this.lstAllSubject.Name = "lstAllSubject";
            this.lstAllSubject.Size = new System.Drawing.Size(196, 224);
            this.lstAllSubject.TabIndex = 1;
            this.lstAllSubject.Text = "radListView1";
            // 
            // btnCreateTest
            // 
            this.btnCreateTest.Location = new System.Drawing.Point(975, 254);
            this.btnCreateTest.Name = "btnCreateTest";
            this.btnCreateTest.Size = new System.Drawing.Size(130, 24);
            this.btnCreateTest.TabIndex = 16;
            this.btnCreateTest.Text = "Tạo đề thi";
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox4.Controls.Add(this.m_gridTests);
            this.radGroupBox4.FooterImageIndex = -1;
            this.radGroupBox4.FooterImageKey = "";
            this.radGroupBox4.HeaderImageIndex = -1;
            this.radGroupBox4.HeaderImageKey = "";
            this.radGroupBox4.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox4.HeaderText = "Bộ đề thi";
            this.radGroupBox4.Location = new System.Drawing.Point(0, 283);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox4.Size = new System.Drawing.Size(1107, 234);
            this.radGroupBox4.TabIndex = 7;
            this.radGroupBox4.Text = "Bộ đề thi";
            // 
            // m_gridTests
            // 
            this.m_gridTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_gridTests.Location = new System.Drawing.Point(2, 18);
            // 
            // m_gridTests
            // 
            this.m_gridTests.MasterTemplate.AutoGenerateColumns = false;
            this.m_gridTests.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "MultiTestNo";
            gridViewTextBoxColumn1.FormatString = "";
            gridViewTextBoxColumn1.HeaderText = "Mã đề";
            gridViewTextBoxColumn1.Name = "colTestNo";
            gridViewTextBoxColumn1.Width = 129;
            gridViewTextBoxColumn2.FieldName = "MultiTestName";
            gridViewTextBoxColumn2.FormatString = "";
            gridViewTextBoxColumn2.HeaderText = "Tên đề";
            gridViewTextBoxColumn2.Name = "colName";
            gridViewTextBoxColumn2.Width = 346;
            gridViewDateTimeColumn1.FieldName = "MultiTestDate";
            gridViewDateTimeColumn1.FormatString = "";
            gridViewDateTimeColumn1.HeaderText = "Ngày thi";
            gridViewDateTimeColumn1.Name = "colTestDate";
            gridViewDateTimeColumn1.Width = 344;
            gridViewTextBoxColumn3.FieldName = "ClassNameForMulti";
            gridViewTextBoxColumn3.HeaderText = "Lớp";
            gridViewTextBoxColumn3.Name = "colClassName";
            gridViewTextBoxColumn3.Width = 266;
            this.m_gridTests.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn3});
            this.m_gridTests.Name = "m_gridTests";
            this.m_gridTests.ReadOnly = true;
            this.m_gridTests.Size = new System.Drawing.Size(1103, 214);
            this.m_gridTests.TabIndex = 0;
            // 
            // grpLevel
            // 
            this.grpLevel.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.grpLevel.Controls.Add(this.chkIsNotSame);
            this.grpLevel.Controls.Add(this.radLabel7);
            this.grpLevel.Controls.Add(this.speHardQuestion);
            this.grpLevel.Controls.Add(this.speEasyQuestion);
            this.grpLevel.Controls.Add(this.radLabel8);
            this.grpLevel.Controls.Add(this.radLabel9);
            this.grpLevel.Controls.Add(this.speNormalQuestion);
            this.grpLevel.FooterImageIndex = -1;
            this.grpLevel.FooterImageKey = "";
            this.grpLevel.HeaderImageIndex = -1;
            this.grpLevel.HeaderImageKey = "";
            this.grpLevel.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.grpLevel.HeaderText = "Số câu hỏi";
            this.grpLevel.Location = new System.Drawing.Point(451, 163);
            this.grpLevel.Name = "grpLevel";
            this.grpLevel.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.grpLevel.Size = new System.Drawing.Size(656, 85);
            this.grpLevel.TabIndex = 18;
            this.grpLevel.Text = "Số câu hỏi";
            // 
            // chkIsNotSame
            // 
            this.chkIsNotSame.Location = new System.Drawing.Point(416, 37);
            this.chkIsNotSame.Name = "chkIsNotSame";
            this.chkIsNotSame.Size = new System.Drawing.Size(148, 18);
            this.chkIsNotSame.TabIndex = 25;
            this.chkIsNotSame.Text = "Tạo đề không trùng nhau";
            // 
            // cbbClassMixedTest
            // 
            // 
            // cbbClassMixedTest.NestedRadGridView
            // 
            this.cbbClassMixedTest.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.cbbClassMixedTest.EditorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbClassMixedTest.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbbClassMixedTest.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.cbbClassMixedTest.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.cbbClassMixedTest.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.cbbClassMixedTest.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.cbbClassMixedTest.EditorControl.MasterTemplate.EnableGrouping = false;
            this.cbbClassMixedTest.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.cbbClassMixedTest.EditorControl.Name = "NestedRadGridView";
            this.cbbClassMixedTest.EditorControl.ReadOnly = true;
            this.cbbClassMixedTest.EditorControl.ShowGroupPanel = false;
            this.cbbClassMixedTest.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.cbbClassMixedTest.EditorControl.TabIndex = 0;
            this.cbbClassMixedTest.Location = new System.Drawing.Point(674, 194);
            this.cbbClassMixedTest.Name = "cbbClassMixedTest";
            // 
            // 
            // 
            this.cbbClassMixedTest.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.cbbClassMixedTest.Size = new System.Drawing.Size(275, 20);
            this.cbbClassMixedTest.TabIndex = 21;
            this.cbbClassMixedTest.TabStop = false;
            // 
            // radLabel11
            // 
            this.radLabel11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel11.Location = new System.Drawing.Point(452, 12);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(54, 18);
            this.radLabel11.TabIndex = 11;
            this.radLabel11.Text = "Chọn lớp";
            // 
            // dropdownClass
            // 
            this.dropdownClass.DropDownAnimationEnabled = true;
            this.dropdownClass.Location = new System.Drawing.Point(512, 10);
            this.dropdownClass.MaxDropDownItems = 0;
            this.dropdownClass.Name = "dropdownClass";
            this.dropdownClass.ShowImageInEditorArea = true;
            this.dropdownClass.Size = new System.Drawing.Size(583, 20);
            this.dropdownClass.TabIndex = 20;
            // 
            // frmMultipleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 514);
            this.Controls.Add(this.dropdownClass);
            this.Controls.Add(this.grpLevel);
            this.Controls.Add(this.radGroupBox4);
            this.Controls.Add(this.btnCreateTest);
            this.Controls.Add(this.grpAllSubject);
            this.Controls.Add(this.radLabel11);
            this.Controls.Add(this.grpTestInfo);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.grpCurrentSubject);
            this.Name = "frmMultipleTest";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Tạo đề thi từ nhiều môn học";
            this.ThemeName = "ControlDefault";
            ((System.ComponentModel.ISupportInitialize)(this.grpCurrentSubject)).EndInit();
            this.grpCurrentSubject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstSelectedSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTestInfo)).EndInit();
            this.grpTestInfo.ResumeLayout(false);
            this.grpTestInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlPurpose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speTotalQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speTestTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speSubTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTestDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speHardQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speNormalQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speEasyQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAllSubject)).EndInit();
            this.grpAllSubject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstAllSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_gridTests.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLevel)).EndInit();
            this.grpLevel.ResumeLayout(false);
            this.grpLevel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsNotSame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbClassMixedTest.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbClassMixedTest.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbClassMixedTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox grpCurrentSubject;
        private Telerik.WinControls.UI.RadButton btnNext;
        private Telerik.WinControls.UI.RadButton btnPre;
        private Telerik.WinControls.UI.RadGroupBox grpTestInfo;
        private Telerik.WinControls.UI.RadTextBox txtTestName;
        private Telerik.WinControls.UI.RadTextBox txtTestNo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadSpinEditor speSubTest;
        private Telerik.WinControls.UI.RadDateTimePicker dtpTestDate;
        private Telerik.WinControls.UI.RadSpinEditor speHardQuestion;
        private Telerik.WinControls.UI.RadSpinEditor speNormalQuestion;
        private Telerik.WinControls.UI.RadSpinEditor speEasyQuestion;
        private Telerik.WinControls.UI.RadSpinEditor speTestTime;
        private Telerik.WinControls.UI.RadSpinEditor speTotalQuestion;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadListView lstSelectedSubject;
        private Telerik.WinControls.UI.RadGroupBox grpAllSubject;
        private Telerik.WinControls.UI.RadListView lstAllSubject;
        private Telerik.WinControls.UI.RadButton btnCreateTest;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadGridView m_gridTests;
        private Telerik.WinControls.UI.RadGroupBox grpLevel;
        private Telerik.WinControls.UI.RadDropDownList ddlPurpose;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadMultiColumnComboBox cbbClassMixedTest;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadDropDownList dropdownClass;
        private Telerik.WinControls.UI.RadCheckBox chkIsNotSame;

    }
}
