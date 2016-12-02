using Common;
using Controller.Services;
using Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.WinControls.UI;

namespace NganHangDeThi.Form_Popup {
    public partial class frmSelectedMultiTestCopy : RadForm {
        private MultiTestService m_multiTestService;

        public frmSelectedMultiTestCopy() {
            InitializeComponent();
        }

        public frmSelectedMultiTestCopy(long multiTestId) {
            InitializeComponent();
            // Event handler
            lstMultitests.ItemMouseDoubleClick += OnItemDoubleClick;

            m_multiTestService = new MultiTestService();
            List<MultiTestCopy> multiTestCopies = m_multiTestService.GetTestCopiesByTestId(multiTestId);
            MultiTest multiTest = m_multiTestService.GetMultiTestById(multiTestId);
            int index = 1;
            List<EnumDisplay> copyDisplayed = new List<EnumDisplay>();
            // multiTest main
            //copyDisplayed.Add(new EnumDisplay(string.Format("Đề: {0} - Đề số: 0{1}", multiTest.MultiTestName, index), 
            //                                  (int)multiTest.MultiTestId, index++));
            // multiTest copies
            copyDisplayed.AddRange(multiTestCopies.Select(
                tc => new EnumDisplay(string.Format("Đề: {0} - Đề số: 0{1}", multiTest.MultiTestName, index), 
                                      tc.MultiTestCopyId, 
                                      index++)).ToList());
            lstMultitests.DataSource = copyDisplayed;
            lstMultitests.DisplayMember = "DisplayText";
            lstMultitests.Tag = multiTest.IsMixedTest;
        }

        private void OnItemDoubleClick(object sender, ListViewItemEventArgs e) {
            if (lstMultitests.Tag != null && Convert.ToBoolean(lstMultitests.Tag)) {
                EnumDisplay selectedItem = lstMultitests.SelectedItem.DataBoundItem as EnumDisplay;
                if (selectedItem != null) {
                    int index = (int)selectedItem.Tag;
                    frmMultiTestReport report = new frmMultiTestReport(selectedItem.Value, index, null, null);
                    report.Show();
                }
            } else {
                EnumDisplay selectedItem = lstMultitests.SelectedItem.DataBoundItem as EnumDisplay;
                if (selectedItem != null) {
                    int index = (int)selectedItem.Tag;
                    frmMultiTestReport report = new frmMultiTestReport(selectedItem.Value, index);
                    report.Show();
                }
            }
        }

        private void btnViewTest_Click(object sender, System.EventArgs e) {
            OnItemDoubleClick(null, null);
        }

        private void btnViewAnswer_Click(object sender, System.EventArgs e) {
            if (lstMultitests.Tag != null && Convert.ToBoolean(lstMultitests.Tag)) {
                EnumDisplay selectedItem = lstMultitests.SelectedItem.DataBoundItem as EnumDisplay;
                if (selectedItem != null) {
                    int index = (int)selectedItem.Tag;
                    frmMultiTestReport report = new frmMultiTestReport(selectedItem.Value, index, null);
                    report.Show();
                }
            } else {
                EnumDisplay selectedItem = lstMultitests.SelectedItem.DataBoundItem as EnumDisplay;
                if (selectedItem != null) {
                    int index = (int)selectedItem.Tag;
                    frmMultiTestReport report = new frmMultiTestReport(selectedItem.Value, index, null);
                    report.Show();
                }
            }
        }
    }
}
