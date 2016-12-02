namespace NganHangReport {
    partial class rpCustomQuestionReport {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.m_txtSchoolInfo = new Telerik.Reporting.TextBox();
            this.m_txtDepartmentInfo = new Telerik.Reporting.TextBox();
            this.m_txtTestName = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.CustomQuestionDataSource = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.59999996423721313D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.m_txtSchoolInfo,
            this.m_txtDepartmentInfo,
            this.m_txtTestName});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pageHeaderSection1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pageHeaderSection1.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.pageHeaderSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.pageHeaderSection1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.pageHeaderSection1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.pageHeaderSection1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Inch(0D);
            // 
            // m_txtSchoolInfo
            // 
            this.m_txtSchoolInfo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9378803194267675E-05D));
            this.m_txtSchoolInfo.Name = "m_txtSchoolInfo";
            this.m_txtSchoolInfo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0000007152557373D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.m_txtSchoolInfo.Style.Font.Bold = true;
            this.m_txtSchoolInfo.Value = "";
            // 
            // m_txtDepartmentInfo
            // 
            this.m_txtDepartmentInfo.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.m_txtDepartmentInfo.Name = "m_txtDepartmentInfo";
            this.m_txtDepartmentInfo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0000007152557373D), Telerik.Reporting.Drawing.Unit.Inch(0.20000004768371582D));
            this.m_txtDepartmentInfo.Value = "";
            // 
            // m_txtTestName
            // 
            this.m_txtTestName.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.m_txtTestName.Name = "m_txtTestName";
            this.m_txtTestName.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5676772594451904D), Telerik.Reporting.Drawing.Unit.Inch(0.39996060729026794D));
            this.m_txtTestName.Style.Font.Bold = true;
            this.m_txtTestName.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.m_txtTestName.Value = "";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2});
            this.detail.Name = "detail";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D), Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.6676778793334961D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.textBox2.Value = "= Fields.Content";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox4,
            this.textBox5});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.7675986289978027D), Telerik.Reporting.Drawing.Unit.Inch(0.049960613250732422D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox4.Value = "Trang: ";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.2676773071289062D), Telerik.Reporting.Drawing.Unit.Inch(0.049960613250732422D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.textBox5.Value = "= PageNumber";
            // 
            // CustomQuestionDataSource
            // 
            this.CustomQuestionDataSource.DataSource = typeof(Model.QuestionModel);
            this.CustomQuestionDataSource.Name = "CustomQuestionDataSource";
            // 
            // rpCustomQuestionReport
            // 
            this.DataSource = this.CustomQuestionDataSource;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "rpCustomQuestionReport";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.75D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.75D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.75D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.75D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.7677168846130371D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox m_txtSchoolInfo;
        private Telerik.Reporting.TextBox m_txtDepartmentInfo;
        private Telerik.Reporting.TextBox m_txtTestName;
        private Telerik.Reporting.ObjectDataSource CustomQuestionDataSource;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
    }
}