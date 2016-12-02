namespace NganHangReport
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for rpMultiTestQuestion.
    /// </summary>
    public partial class rpTestQuestion : Telerik.Reporting.Report
    {

        public string SubjectName
        {
            get { return txtSubjectName.Value; }
            set { txtSubjectName.Value = value; }
        }
        public string SubjectHeader
        {
            get { return txtSubjectHeader.Value; }
            set { txtSubjectHeader.Value = value; }
        }
        public string TestName
        {
            get { return txtTestName.Value; }
            set { txtTestName.Value = value; }
        }
        public string TestDate
        {
            get { return txtTestDate.Value; }
            set { txtTestDate.Value = value; }
        }
        public string TestTime
        {
            get { return txtTestTime.Value; }
            set { txtTestTime.Value = value; }
        }
        public string ClassName
        {
            get { return txtClassName.Value; }
            set { txtClassName.Value = value; }
        }
        public rpTestQuestion()
        {
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