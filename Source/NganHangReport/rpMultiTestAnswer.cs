namespace NganHangReport {
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rpMultiTestAnswer.
    /// </summary>
    public partial class rpMultiTestAnswer : Telerik.Reporting.Report {
        public string SchoolName {
            get { return txtSchoolName.Value; }
            set { txtSchoolName.Value = value; }
        }
        public string AnswerName {
            get { return txtAnswerName.Value; }
            set { txtAnswerName.Value = value; }
        }
        public string TestDate {
            get { return txtTestDate.Value; }
            set { txtTestDate.Value = value; }
        }
        public string TestTime {
            get { return txtTestTime.Value; }
            set { txtTestTime.Value = value; }
        }
        public rpMultiTestAnswer() {
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