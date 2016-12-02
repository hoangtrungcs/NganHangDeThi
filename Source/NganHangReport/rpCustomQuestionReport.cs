namespace NganHangReport {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rpCustomQuestionReport.
    /// </summary>
    public partial class rpCustomQuestionReport : Telerik.Reporting.Report {
        public string SchoolName {
            get { return m_txtSchoolInfo.Value; }
            set { m_txtSchoolInfo.Value = value; }
        }
        public string Department {
            get { return m_txtDepartmentInfo.Value; }
            set { m_txtDepartmentInfo.Value = value; }
        }
        public string TestName {
            get { return m_txtTestName.Value; }
            set { m_txtTestName.Value = value; }
        }
       
        public rpCustomQuestionReport() {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}