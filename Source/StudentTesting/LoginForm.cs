using System;
using System.Windows.Forms;
using Controller.Services;
using Model;
using Model.POCO;

namespace StudentTesting {
    public partial class LoginForm : Form {
        private StudentsService m_studentService;
        private SubjectsService m_subjectService;
        public int SelectedSubjectId { get; set; }
        public LoginForm() {
            NganHangEntities db = new NganHangEntities();
            
            InitializeComponent();
            
            m_subjectService = new SubjectsService(db);
            m_studentService = new StudentsService(db);
            m_cbxSubjects.DataSource = m_studentService.GetAllSubjects();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(m_txtUsername.Text)) {
                MessageBox.Show("Please enter username!","Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(m_txtPassword.Text)) {
                MessageBox.Show("Please enter password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!m_studentService.Login(m_txtUsername.Text, m_txtPassword.Text)) {
                MessageBox.Show("Username or password is incorrect. Please try again!", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            Subject selectedSubject = m_cbxSubjects.SelectedItem.DataBoundItem as Subject;
            if (!m_studentService.Login(m_txtUsername.Text, m_txtPassword.Text, selectedSubject.SubjectId)) {
                MessageBox.Show("Ban ko co bai test nao cho mon nay!", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            SelectedSubjectId = selectedSubject.SubjectId;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
