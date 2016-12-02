using Common;
using Controller.Services;
using Model.POCO;
using NganHangDeThi.Form_Popup;
using NganHangDeThi.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace NganHangDeThi {
    public partial class frmLimitedTest : BaseForm {
        private TestsService m_testService;
        private SubjectsService m_subjectsService;
        private QuestionsService m_questionsService;
        private List<Question> m_selectedQuestion;

        public List<int> SelectedSubjectIds {
            get { return m_lstSubjects.SelectedItems != null ? m_lstSubjects.SelectedItems.Select(i => (int)i.Tag).ToList() : new List<int>(); }
        }
        private void InitSubjectLstView() {
            var lstSubjects = m_subjectsService.GetAllSubject();
            var radItems = from subject in lstSubjects
                           select new RadListDataItem { Text = subject.SubjectNo + " : " + subject.Name, Tag = subject.SubjectId };
            m_lstSubjects.Items.Clear();
            m_lstSubjects.DataSource = null;
            m_lstSubjects.Items.AddRange(radItems);
            m_cbxPurpose.DataSource = EnumHelpers.GetAllQuestionPurpose();
            m_cbxPurpose.DisplayMember = "DisplayText";
            m_cbxPurpose.ValueMember = "Value";
            m_cbxPurpose.DropDownStyle=RadDropDownStyle.DropDownList;
        }
        public frmLimitedTest() {
            InitializeComponent();
            NganHangEntities context = new NganHangEntities();
            m_testService = new TestsService(context);
            m_subjectsService = new SubjectsService(context);
            m_questionsService = new QuestionsService(context);
            m_selectedQuestion = new List<Question>();
            InitSubjectLstView();
            m_gridTests.SelectionChanged += m_gridTests_SelectionChanged;

            m_dtTestDate.Value = DateTime.Now;
        }
        void m_gridTests_SelectionChanged(object sender, EventArgs e) {
            if (m_gridTests.Rows.Count > 0 && m_gridTests.SelectedRows.Count > 0) {
                CanDelete = true;
                NotifyStateChanged();
            }
        }
        private void m_btnStart_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(m_txtMaDe.Text) || string.IsNullOrEmpty(m_txtTenDe.Text)) {
                RadMessageBox.Show("Bạn hãy điền mã đề, tên đề thi đầy đủ!", "Lỗi!", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }
            if (SelectedSubjectIds.Count == 0) {
                RadMessageBox.Show("Chọn môn học để tạo đề thi!", "Lỗi!", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }
            int numberOfQuestion = m_questionsService.CountQuestionsInSubjects(SelectedSubjectIds);
            if (speTotalQuestions.Value > numberOfQuestion) {
                RadMessageBox.Show(
                    "Số câu hỏi hiện có là " + numberOfQuestion + "! Bạn vui lòng chọn số câu hỏi nhỏ hơn",
                    "Thông tin", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }
            if (speTotalQuestions.Value != speEasyQuestions.Value + speNormalQuestions.Value + speHardQuestions.Value) {
                RadMessageBox.Show("Tổng số câu hỏi dễ, trung bình, khó không bằng số lượng câu hỏi cần tạo", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            if (speTotalQuestions.Value == 0) {
                RadMessageBox.Show("Bạn chưa chọn câu hỏi để tạo đề", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            double totalTime = Convert.ToDouble(speTime.Value);
            decimal estimateTime = speEasyQuestions.Value * Constants.DEFAULT_EASY_QUESTION_TIME +
                speNormalQuestions.Value * Constants.DEFAULT_BASIC_QUESTION_TIME +
                speHardQuestions.Value * Constants.DEFAULT_ADVANCE_QUESTION_TIME;
            double moreTime = Convert.ToDouble(ConfigurationManager.AppSettings["Minute"]);
            if (Convert.ToDouble(estimateTime) > totalTime + moreTime) {
                if (RadMessageBox.Show("Thời gian dự tính hoàn thành bài thi: " + estimateTime +
                                       "\nThời gian người dùng đã chọn: " + totalTime +
                                       ".\nBạn có muốn tiếp tục tạo đề thi không",
                                    "Cảnh báo", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation) == DialogResult.No) {
                    return;
                }
            }
            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;
            try {
                Test test = new Test();
                test.TestDate = m_dtTestDate.Value;
                test.Name = m_txtTenDe.Text;
                test.TestNo = m_txtMaDe.Text;
                //test.FK_SubjectId = CurrentSubjectId;
                test.Time = Convert.ToInt32(speTime.Value);
                test.IsLimited = true;
                string confirmMessage = string.Empty;
                Test testSaved = m_testService.CreateLimitedTest(test, m_selectedQuestion, Convert.ToInt32(speSubTest.Value), moreTime, out confirmMessage);
                if (!string.IsNullOrEmpty(confirmMessage)) {
                    if (RadMessageBox.Show(confirmMessage, "Cảnh báo",
                                                MessageBoxButtons.YesNo, RadMessageIcon.Exclamation) == DialogResult.Yes) {
                        m_testService.SaveTest(testSaved);
                        IsDirty = false;
                    }
                } else {
                    m_testService.SaveTest(testSaved);
                    IsDirty = false;
                }
                LoadTestDatas();

            } catch (NumberQuestionNotEnoughException exception) {
                RadMessageBox.Show(exception.ErrorMsg, "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                Cursor.Current = Cursors.Default;
            }
        }

        public override void Delete() {
            if (m_gridTests.SelectedRows != null && m_gridTests.SelectedRows.Count > 0) {
                if (RadMessageBox.Show(
                    "Bạn muốn xóa bài test này không?",
                    "Thông tin", MessageBoxButtons.OK, RadMessageIcon.Info) == DialogResult.OK) {
                    Test test = m_gridTests.SelectedRows[0].DataBoundItem as Test;
                    if (test != null) {
                        test.IsDeleted = true;
                        m_testService.UpdateTest(test);
                        LoadTestDatas();
                    }
                }
            }
        }
        private void m_lstSubjects_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e) {
            //if (!UserService.CurrentUser.HasRole(UserRole.Administrator) &&
            //    !UserService.CurrentUser.HasRight(CurrentSubjectId, RightType.ListTest)) {
            //    RadMessageBox.Show("You havenot access to this subject, please contact addmin to help.", "Access deny",
            //                        MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            //    radGroupBox1.Enabled = false;
            //} else {
            //    radGroupBox1.Enabled = true;
            //    LoadTestDatas();
            //    if (!UserService.CurrentUser.HasRole(UserRole.Administrator) &&
            //    !UserService.CurrentUser.HasRight(CurrentSubjectId, RightType.CreateTest)) {
            //        m_btnStart.Enabled = false;
            //    }
            //}
        }
        private void LoadTestDatas() {
            m_gridTests.DataSource = m_testService.GetLimitedTests();
        }
        private void m_gridTests_CellDoubleClick(object sender, GridViewCellEventArgs e) {
            var item = m_gridTests.SelectedRows.FirstOrDefault().DataBoundItem as Test;
            frmSelectedTestCopy selectedTest = new frmSelectedTestCopy(item.TestId);
            selectedTest.ShowDialog();
        }
        private void btnChooseQuestion_Click(object sender, EventArgs e) {
            frmSelectQuestions selectQuestions = new frmSelectQuestions(m_questionsService, SelectedSubjectIds, (int)m_cbxPurpose.SelectedValue);
            if (selectQuestions.ShowDialog() == DialogResult.OK) {
                speTotalQuestions.Value = selectQuestions.SelectedQuestions.Count;
                speEasyQuestions.Value = selectQuestions.SelectedQuestions.Where(q => q.Level == (int)QuestionLevel.Easy).Count();
                speNormalQuestions.Value = selectQuestions.SelectedQuestions.Where(q => q.Level == (int)QuestionLevel.Normal).Count();
                speHardQuestions.Value = selectQuestions.SelectedQuestions.Where(q => q.Level == (int)QuestionLevel.Hard).Count();
                speTime.Value = Convert.ToDecimal(selectQuestions.SelectedQuestions.Sum(q => q.Time));
                m_selectedQuestion = selectQuestions.SelectedQuestions;
            }
        }

        private void frmLimitedTest_Load(object sender, EventArgs e) {
            LoadTestDatas();
        }
    }
}
