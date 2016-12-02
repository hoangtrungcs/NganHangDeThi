using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Common;
using Controller.Services;
using Microsoft.Office.Interop.Word;
using Model;
using Model.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using NganHangDeThi.ReportWithImage;
using Telerik.WinControls.UI;

namespace NganHangDeThi.Form_Popup
{
    public partial class frmSelectedTestCopy : RadForm
    {
        private TestsService m_testService;

        public frmSelectedTestCopy()
        {
            InitializeComponent();

        }

        public frmSelectedTestCopy(long testId)
        {
            InitializeComponent();
           
            // Event handler
            lstTests.ItemMouseDoubleClick += OnItemDoubleClick;

            m_testService = new TestsService();
            List<TestCopy> testCopies = m_testService.GetTestCopiesByTestId(testId);
            Test test = m_testService.GetTestById(testId);
            int index = 1;
            List<EnumDisplay> copyDisplayed = new List<EnumDisplay>();
            // multiTest main
            //copyDisplayed.Add(new EnumDisplay(string.Format("Đề: {0} - Đề số: 0{1}", multiTest.MultiTestName, index), 
            //                                  (int)multiTest.MultiTestId, index++));
            // multiTest copies
            copyDisplayed.AddRange(testCopies.Select(
                tc => new EnumDisplay(string.Format("Đề: {0} - Đề số: 0{1}", test.Name, index),
                                      tc.TestCopyId,
                                      index++)).ToList());
            lstTests.DataSource = copyDisplayed;
            lstTests.DisplayMember = "DisplayText";
        }

        private void OnItemDoubleClick(object sender, ListViewItemEventArgs e)
        {
            EnumDisplay selectedItem = lstTests.SelectedItem.DataBoundItem as EnumDisplay;
            if (selectedItem != null)
            {
                int index = (int)selectedItem.Tag;

                //TODO: 2 Case load repport
                //1. If have image ==> load rtf file  
                //frmTestReportWithImage frmTestReportWithImage = new frmTestReportWithImage(selectedItem.Value, index);
                //frmTestReportWithImage.Show();

                //LoadReportWithImage(selectedItem.Value, index);

                //2. If not have image load frmTestReport form

                frmTestReport report = new frmTestReport(selectedItem.Value, index);
                if(report.IsShow)
                    report.Show();
            }
        }

        private void btnViewTest_Click(object sender, System.EventArgs e)
        {
            OnItemDoubleClick(null, null);
        }

        private void btnViewAnswer_Click(object sender, System.EventArgs e)
        {
            EnumDisplay selectedItem = lstTests.SelectedItem.DataBoundItem as EnumDisplay;
            if (selectedItem != null)
            {
                int index = (int)selectedItem.Tag;
                frmTestReport report = new frmTestReport(selectedItem.Value, index, null);
                report.Show();
            }
        }
    }
}
