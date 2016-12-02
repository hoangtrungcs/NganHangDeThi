using System.Data;
using Common;
using Controller.Services;
using Model.POCO;
using NganHangDeThi.Form_Popup;
using NganHangDeThi.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace NganHangDeThi
{
    public partial class frmTest : BaseForm
    {
        private TestsService m_testService;
        private SubjectsService m_subjectsService;
        private QuestionsService m_questionsService;
        private SubjectsClassService _subjectsClassService;
        private ClassService _classService;

        public int CurrentSubjectId
        {
            get { return m_lstSubjects.SelectedItem != null ? (int)m_lstSubjects.SelectedItem.Tag : 0; }
        }
        private void InitSubjectLstView()
        {
            var lstSubjects = m_subjectsService.GetAllSubject();
            var radItems = from subject in lstSubjects
                           select new RadListDataItem { Text = subject.SubjectNo + " : " + subject.Name, Tag = subject.SubjectId };
            m_lstSubjects.Items.Clear();
            m_lstSubjects.DataSource = null;
            m_lstSubjects.Items.AddRange(radItems);

            m_cbxPurpose.DataSource = EnumHelpers.GetAllQuestionPurpose();
            m_cbxPurpose.DisplayMember = "DisplayText";
            m_cbxPurpose.ValueMember = "Value";
            m_cbxPurpose.DropDownStyle = RadDropDownStyle.DropDownList;

            //BiddingMultiColumnClass();
            dropdownClass.DataSource = _classService.GetAll();
            dropdownClass.DisplayMember = "ClassName";
            dropdownClass.ValueMember = "ClassId";
            dropdownClass.DropDownStyle = RadDropDownStyle.DropDown;

            dropdownClass.SelectedIndex = -1;
            dropdownClass.Text = "--- Chọn lớp học ---";


        }

        //private void BiddingMultiColumnClass()
        //{
        //    this.cbbClass.AutoSizeDropDownToBestFit = true;
        //    RadMultiColumnComboBoxElement multiColumnComboElement = this.cbbClass.MultiColumnComboBoxElement;
        //    multiColumnComboElement.DropDownSizingMode = SizingMode.UpDownAndRightBottom;
        //    //multiColumnComboElement.DropDownMinSize = new Size(420, 300);
        //    multiColumnComboElement.EditorControl.MasterTemplate.AutoGenerateColumns = false;

        //    GridViewTextBoxColumn column = new GridViewTextBoxColumn("ClassId");
        //    column.HeaderText = "Class Id";
        //    multiColumnComboElement.Columns.Add(column);

        //    column = new GridViewTextBoxColumn("ClassNo");
        //    column.HeaderText = "Mã lớp";
        //    multiColumnComboElement.Columns.Add(column);

        //    column = new GridViewTextBoxColumn("ClassName");
        //    column.HeaderText = "Tên lớp";
        //    multiColumnComboElement.Columns.Add(column);

        //    cbbClass.DataSource = _classService.GetAll();
        //    cbbClass.ValueMember = "ClassId";
        //    cbbClass.DisplayMember = "ClassName";
      

        //    FilterDescriptor descriptor = new FilterDescriptor(this.cbbClass.DisplayMember, FilterOperator.StartsWith, string.Empty);
        //    this.cbbClass.EditorControl.FilterDescriptors.Add(descriptor);
        //    this.cbbClass.DropDownStyle = RadDropDownStyle.DropDown;
        //}

        public frmTest()
        {
            InitializeComponent();
            NganHangEntities context = new NganHangEntities();
            m_testService = new TestsService(context);
            _classService = new ClassService(context);
            m_subjectsService = new SubjectsService(context);
            m_questionsService = new QuestionsService(context);
            InitSubjectLstView();
            speTotalQuestions.Validated += speTotalQuestions_LostFocus;
            speEasyQuestions.Validated += speEasyQuestions_LostFocus;
            speNormalQuestions.Validated += speNormalQuestions_LostFocus;
            speHardQuestions.Validated += speHardQuestions_LostFocus;
            m_gridTests.SelectionChanged += m_gridTests_SelectionChanged;

            m_dtTestDate.Value = DateTime.Now;
        }

        void m_gridTests_SelectionChanged(object sender, EventArgs e)
        {
            if (m_gridTests.Rows.Count > 0 && m_gridTests.SelectedRows.Count > 0)
            {
                CanDelete = true;
                NotifyStateChanged();
            }
        }

        public override void Save()
        {

        }
        public void Create()
        {

        }
        public override void Add()
        {

        }
        public override void Edit()
        {

        }
        public override void Cancel()
        {

        }
        public override void Delete()
        {
            if (m_gridTests.SelectedRows != null && m_gridTests.SelectedRows.Count > 0)
            {
                if (RadMessageBox.Show(
                    "Bạn muốn xóa bài test này không?",
                    "Thông tin", MessageBoxButtons.OK, RadMessageIcon.Info) == DialogResult.OK)
                {
                    Test test = m_gridTests.SelectedRows[0].DataBoundItem as Test;
                    if (test != null)
                    {
                        test.IsDeleted = true;
                        m_testService.UpdateTest(test);
                        LoadTestDatas();
                    }
                }
            }
        }

        private void m_btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtMaDe.Text) || string.IsNullOrEmpty(m_txtTenDe.Text))
            {
                RadMessageBox.Show("Bạn hãy điền mã đề, tên đề thi đầy đủ!", "Lỗi!", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }
            if (CurrentSubjectId <= 0)
            {
                RadMessageBox.Show("Chọn môn học để tạo đề thi!", "Lỗi!", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }
            int numberOfQuestion = m_questionsService.CountQuestionsInSubject(CurrentSubjectId);
            if (speTotalQuestions.Value > numberOfQuestion)
            {
                RadMessageBox.Show(
                    "Số câu hỏi hiện có là " + numberOfQuestion + "! Bạn vui lòng chọn số câu hỏi nhỏ hơn",
                    "Thông tin", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }
            if (chkIsNotSame.Checked && (speTotalQuestions.Value * speSubTest.Value > numberOfQuestion))
            {
                RadMessageBox.Show("Số câu hỏi hiện có là " + numberOfQuestion + "! Bạn vui lòng chọn số câu hỏi, số đề tạo ra nhỏ hơn",
                    "Thông tin", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }
            if (speTotalQuestions.Value != speEasyQuestions.Value + speNormalQuestions.Value + speHardQuestions.Value)
            {
                RadMessageBox.Show("Tổng số câu hỏi dễ, trung bình, khó không bằng số lượng câu hỏi cần tạo", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            decimal totalTime = speTime.Value;
            decimal estimateTime = speEasyQuestions.Value * Constants.DEFAULT_EASY_QUESTION_TIME +
                speNormalQuestions.Value * Constants.DEFAULT_BASIC_QUESTION_TIME +
                speHardQuestions.Value * Constants.DEFAULT_ADVANCE_QUESTION_TIME;
            decimal moreTime = Convert.ToDecimal(ConfigurationManager.AppSettings["Minute"]);
            if (estimateTime > totalTime + moreTime)
            {
                if (RadMessageBox.Show("Thời gian dự tính hoàn thành bài thi: " + estimateTime +
                                       "\nThời gian người dùng đã chọn: " + totalTime +
                                       ".\nBạn có muốn tiếp tục tạo đề thi không",
                                    "Cảnh báo", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation) == DialogResult.No)
                {
                    return;
                }
            }
            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Test test = new Test();
                test.TestDate = m_dtTestDate.Value;
                test.Name = m_txtTenDe.Text;
                test.TestNo = m_txtMaDe.Text;
                test.FK_SubjectId = CurrentSubjectId;
                if(dropdownClass.SelectedValue!=null)
                    test.FK_ClassId = (int)dropdownClass.SelectedValue;
                test.Time = Convert.ToInt32(speTime.Value);
                string confirmMessage = string.Empty;
                Test testSaved = m_testService.CreateTest(test, CurrentSubjectId,
                                         new List<Tuple<QuestionLevel, int>> {
                                             new Tuple<QuestionLevel, int>(QuestionLevel.Easy, Convert.ToInt32(speEasyQuestions.Value)),
                                             new Tuple<QuestionLevel, int>(QuestionLevel.Normal, Convert.ToInt32(speNormalQuestions.Value)),
                                             new Tuple<QuestionLevel, int>(QuestionLevel.Hard, Convert.ToInt32(speHardQuestions.Value))
                                         }, (int)m_cbxPurpose.SelectedValue, Convert.ToInt32(speSubTest.Value), Convert.ToDouble(moreTime), out confirmMessage);
                if (!string.IsNullOrEmpty(confirmMessage))
                {
                    if (RadMessageBox.Show(confirmMessage, "Cảnh báo",
                                                MessageBoxButtons.YesNo, RadMessageIcon.Exclamation) == DialogResult.Yes)
                    {
                        m_testService.SaveTest(testSaved);
                        IsDirty = false;
                    }
                }
                else
                {
                    m_testService.SaveTest(testSaved);
                    IsDirty = false;
                }
                LoadTestDatas();

            }
            catch (NumberQuestionNotEnoughException exception)
            {
                RadMessageBox.Show(exception.ErrorMsg, "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void m_lstSubjects_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (!UserService.CurrentUser.HasRole(UserRole.Administrator) &&
                !UserService.CurrentUser.HasRight(CurrentSubjectId, RightType.ListTest))
            {
                RadMessageBox.Show("You have not access to this subject, please contact addmin to help.", "Access deny",
                                    MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                radGroupBox1.Enabled = false;
            }
            else
            {
                radGroupBox1.Enabled = true;
                //Giai doan 2
                //BindingSubjectClass();
                LoadTestDatas();
                if (!UserService.CurrentUser.HasRole(UserRole.Administrator) &&
                !UserService.CurrentUser.HasRight(CurrentSubjectId, RightType.CreateTest))
                {
                    m_btnStart.Enabled = false;
                }
            }
        }

        //Giai doan 2 
        //private void BindingSubjectClass()
        //{
        //    ddl_Class.DataSource = _subjectsClassService.GetAllSubjecClassBySubject(CurrentSubjectId);
        //    ddl_Class.DisplayMember = "SubjectsClassName";
        //    ddl_Class.ValueMember = "SubjectsClassId";
        //}

        private void LoadTestDatas()
        {
            if (CurrentSubjectId > 0)
            {
                m_gridTests.DataSource = null;
                var tests = m_testService.GetAllTestsBySubject(CurrentSubjectId);
                m_gridTests.DataSource = tests;
            }
        }
        private void CheckConstrainQuestion(QuestionLevel level)
        {
            // Check constrain total question
            //if (speTotalQuestions.Value < speEasyQuestions.Value + speNormalQuestions.Value + speHardQuestions.Value) {
            //    RadMessageBox.Show("Tong so cau hoi khong duoc nho hon cac cau hoi de, trung binh, kho", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
            //    return;
            //}
            //if (level == QuestionLevel.Easy) {  //  Edit total question
            //    speEasyQuestions.Value = speTotalQuestions.Value - speNormalQuestions.Value - speHardQuestions.Value;
            //} else if (level == QuestionLevel.Basic) {  //  Edit easy question
            //    speNormalQuestions.Value = speTotalQuestions.Value - speEasyQuestions.Value - speHardQuestions.Value;
            //} else if (level == QuestionLevel.Intermediate) {  //  Edit normal question
            //    speHardQuestions.Value = speTotalQuestions.Value - speEasyQuestions.Value - speNormalQuestions.Value;
            //} else { // edit hard question
            //    speTotalQuestions.Value = speEasyQuestions.Value + speNormalQuestions.Value + speHardQuestions.Value;
            //}
        }

        private void m_gridTests_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            var item = m_gridTests.SelectedRows.FirstOrDefault().DataBoundItem as Test;

            frmSelectedTestCopy selectedTest = new frmSelectedTestCopy(item.TestId);
            selectedTest.ShowDialog();
        }
        private void speTotalQuestions_LostFocus(object sender, EventArgs e)
        {
            CheckConstrainQuestion(QuestionLevel.Easy);
        }
        private void speEasyQuestions_LostFocus(object sender, EventArgs e)
        {
            CheckConstrainQuestion(QuestionLevel.Easy);
        }
        private void speNormalQuestions_LostFocus(object sender, EventArgs e)
        {
            CheckConstrainQuestion(QuestionLevel.Normal);
        }
        private void speHardQuestions_LostFocus(object sender, EventArgs e)
        {
            CheckConstrainQuestion(QuestionLevel.Hard);
        }


    }
}
