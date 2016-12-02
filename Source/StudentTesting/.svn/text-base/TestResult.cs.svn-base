using System.Windows.Forms;
using Controller.Services;

namespace StudentTesting {
    public partial class TestResult : UserControl {
        public TestResult() {
            InitializeComponent();
        }
        public void SetValue(string made, int usedTime, int rightNo, int wrongNo, int notyet) {
            m_lblUsername.Text = StudentsService.CurrentStudent.FullName;
            m_lblMSSV.Text = StudentsService.CurrentStudent.StudentNo;
            m_lblMaDe.Text = made;
            m_lblUsedTime.Text = usedTime/60 + " phut " + usedTime%60 + " giay";
            m_lblRights.Text = rightNo + " cau";
            m_lblWrong.Text = wrongNo + " cau";
            m_lblNotYet.Text = notyet + " cau";
        }
    }
}
