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
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace NganHangDeThi
{

    public partial class frmMixedTest : SimpleBaseForm<MultiTest, MultiTestService>
    {

        private BindingSource m_subjectBindingSource;
        private QuestionsService m_questionService;
        private ClassService _classService;

        public frmMixedTest()
        {
            InitializeComponent();
            m_gridTests.ShowGroupPanel = false;
            _classService = new ClassService();


            m_questionService = new QuestionsService();
            // register control event handler
            btnNext.Click += btnNext_Click;
            btnPre.Click += btnPre_Click;
            speEasyQuestion.ValueChanged += OnQuestionNoChanged;
            speNormalQuestion.ValueChanged += OnQuestionNoChanged;
            speHardQuestion.ValueChanged += OnQuestionNoChanged;
            speEasyQuestion1.ValueChanged += OnQuestionNoChanged;
            speNormalQuestion1.ValueChanged += OnQuestionNoChanged;
            speHardQuestion1.ValueChanged += OnQuestionNoChanged;
            m_gridTests.CellDoubleClick += OnCellDoubleClick;
            lstSelectedSubject.SelectedItemChanged += OnSelectedSubjectItemChanged;
            dtpTestDate.Value = DateTime.Now;
            this.Load += OnLoad;
            ddlPurpose.SelectedIndex = 0;

            dropdownClass.DataSource = _classService.GetAll();
            dropdownClass.DisplayMember = "ClassName";
            dropdownClass.ValueMember = "ClassId";
            dropdownClass.DropDownStyle = RadDropDownStyle.DropDown;

            dropdownClass.SelectedIndex = -1;
            dropdownClass.Text = "--- Chọn lớp học ---";

            //BiddingMultiColumnClass();
        }

        //private void BiddingMultiColumnClass()
        //{
        //    this.cbbClassMixedTest.AutoSizeDropDownToBestFit = true;
        //    RadMultiColumnComboBoxElement multiColumnComboElement = this.cbbClassMixedTest.MultiColumnComboBoxElement;
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

        //    cbbClassMixedTest.DataSource = _classService.GetAll();
        //    cbbClassMixedTest.ValueMember = "ClassId";
        //    cbbClassMixedTest.DisplayMember = "ClassName";

        //    FilterDescriptor descriptor = new FilterDescriptor(this.cbbClassMixedTest.DisplayMember, FilterOperator.StartsWith, string.Empty);
        //    this.cbbClassMixedTest.EditorControl.FilterDescriptors.Add(descriptor);
        //    this.cbbClassMixedTest.DropDownStyle = RadDropDownStyle.DropDownList;
        //}

        private void OnSelectedSubjectItemChanged(object sender, EventArgs e)
        {
            if (lstSelectedSubject.SelectedItem != null)
            {
                var subjectsMultiTest = lstSelectedSubject.SelectedItem.DataBoundItem as SubjectsMultiTest;
                if (subjectsMultiTest != null)
                {
                    grpLevel.Text = string.Format("Số câu hỏi trắc nghiệm của môn {0}", subjectsMultiTest.Subject.Name);
                    groupTuluan.Text = string.Format("Số câu hỏi tự luận của môn {0}", subjectsMultiTest.Subject.Name);
                }

            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (CurrentEntity != null)
            {
                IEnumerable<int> subjectIds = CurrentEntity.SubjectsMultiTests.Select(s => s.Subject.SubjectId);
                List<Subject> subjects = Service.GetAllSubjects().Where(s => !subjectIds.Contains(s.SubjectId)).ToList();
                lstAllSubject.DataSource = subjects;
                if (CurrentEntity.MultiTestId > 0)
                {
                    DisableControl();
                }
                else
                {
                    EnableControl();
                }
            }
            //LoadSecurityStatus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentEntity == null) return;
            if (lstAllSubject.DataSource != null && (lstAllSubject.DataSource as List<Subject>).Count > 0)
            {
                List<int> subjectIds = lstAllSubject.SelectedItems.Select(s => (s.DataBoundItem as Subject).SubjectId).ToList();
                List<SubjectsMultiTest> sm = Service.GetSubjectsMultiTestBySubjectIds(subjectIds, CurrentEntity.MultiTestId);
                for (int i = 0; i < sm.Count; i++)
                {
                    if (!UserService.CurrentUser.HasRole(UserRole.Administrator) && !UserService.CurrentUser.HasRight(sm[i].FK_SubjectId, RightType.CreateTest))
                    {
                        RadMessageBox.Show(string.Format("Bạn không có quyền tạo đề thi cho môn {0}", sm[i].Subject.SubjectNoName), "Cảnh báo",
                                                MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        return;
                    }
                    sm[i].MultiTest = CurrentEntity;
                    CurrentEntity.SubjectsMultiTests.Add(sm[i]);

                }
                BindingSource.ResetCurrentItem();
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (CurrentEntity != null && CurrentEntity.SubjectsMultiTests.Count > 0)
            {
                List<int> subjectIds = lstSelectedSubject.SelectedItems.Select(s => (s.DataBoundItem as SubjectsMultiTest).FK_SubjectId).ToList();
                List<SubjectsMultiTest> removes = CurrentEntity.SubjectsMultiTests.Where(s => subjectIds.Contains(s.FK_SubjectId)).ToList();
                removes.ForEach(r => CurrentEntity.SubjectsMultiTests.Remove(r));
                BindingSource.ResetCurrentItem();
            }
        }

        protected override void InternalLoadData()
        {
            EntitiesCollection = Service.GetAll().Where(t => t.IsMixedTest).OrderByDescending(t => t.MultiTestDate).ToList();
        }

        protected override void SetBindingSource()
        {
            m_gridTests.DataSource = BindingSource;
            ddlPurpose.DataSource = EnumHelpers.GetAllQuestionPurpose();
            ddlPurpose.DisplayMember = "DisplayText";
            ddlPurpose.ValueMember = "Value";
            ddlPurpose.DropDownStyle = RadDropDownStyle.DropDownList;

            BindingSource.CurrentItemChanged += (sender, e) =>
            {
                if (CurrentEntity == null) return;
                IEnumerable<int> subjectIds = CurrentEntity.SubjectsMultiTests.Select(s => s.Subject.SubjectId);
                List<Subject> subjects = Service.GetAllSubjects().Where(s => !subjectIds.Contains(s.SubjectId)).ToList();
                lstAllSubject.DataSource = subjects;
                if (CurrentEntity.MultiTestId > 0)
                {
                    DisableControl();
                }
                else
                {
                    EnableControl();
                }
                SetDetailBindingSource();
            };
        }

        protected override void SetDetailBindingSource()
        {
            if (BindingSource.Current != null)
            {
                ClearBindingSourceDetail();


                lstAllSubject.DisplayMember = "SubjectNoName";
                lstAllSubject.ValueMember = "SubjectId";

                m_subjectBindingSource = new BindingSource(BindingSource, "SubjectsMultiTests");
                lstSelectedSubject.DataSource = m_subjectBindingSource;

                lstSelectedSubject.DisplayMember = "Subject.SubjectNoName";
                lstSelectedSubject.ValueMember = "Subject.SubjectId";

                txtTestNo.DataBindings.Add("Text", BindingSource, "MultiTestNo");
                txtTestName.DataBindings.Add("Text", BindingSource, "MultiTestName");
                speSubTest.DataBindings.Add("Value", BindingSource, "CopyTestNo");
                dtpTestDate.DataBindings.Add("Value", BindingSource, "MultiTestDate");
                speTotalQuestion.DataBindings.Add("Value", BindingSource, "TotalQuestions");
                speTestTime.DataBindings.Add("Value", BindingSource, "Time");
                ddlPurpose.DataBindings.Add("SelectedValue", BindingSource, "Purpose");

                speEasyQuestion.DataBindings.Add("Value", m_subjectBindingSource, "EasyNo");
                speNormalQuestion.DataBindings.Add("Value", m_subjectBindingSource, "NormalNo");
                speHardQuestion.DataBindings.Add("Value", m_subjectBindingSource, "HardNo");

                speEasyQuestion1.DataBindings.Add("Value", m_subjectBindingSource, "EasyNo1");
                speNormalQuestion1.DataBindings.Add("Value", m_subjectBindingSource, "NormalNo1");
                speHardQuestion1.DataBindings.Add("Value", m_subjectBindingSource, "HardNo1");

            }
        }
        private void ClearBindingSourceDetail()
        {
            txtTestNo.DataBindings.Clear();
            txtTestName.DataBindings.Clear();
            speSubTest.DataBindings.Clear();
            dtpTestDate.DataBindings.Clear();
            speTotalQuestion.DataBindings.Clear();
            speTestTime.DataBindings.Clear();
            ddlPurpose.DataBindings.Clear();

            speEasyQuestion.DataBindings.Clear();
            speNormalQuestion.DataBindings.Clear();
            speHardQuestion.DataBindings.Clear();

            speEasyQuestion1.DataBindings.Clear();
            speNormalQuestion1.DataBindings.Clear();
            speHardQuestion1.DataBindings.Clear();
        }
        protected override MultiTest InternalCreateNew()
        {
            MultiTest newTest = base.InternalCreateNew();
            newTest.CopyTestNo = 2;
            newTest.MultiTestDate = DateTime.Now;
            return newTest;
        }

        public override void LoadSecurityStatus()
        {
            base.LoadSecurityStatus();
            if (CurrentEntity != null && CurrentEntity.SubjectsMultiTests.Count > 0)
            {
                SubjectsMultiTest subjectsMultiTest = lstSelectedSubject.SelectedItem.DataBoundItem as SubjectsMultiTest;
                if (subjectsMultiTest != null)
                {
                    Subject subject = subjectsMultiTest.Subject;
                    if (subject != null)
                    {
                        bool isAddmin = UserService.CurrentUser.HasRole(UserRole.Administrator);
                        CanCreate = isAddmin || UserService.CurrentUser.HasRight(subject.SubjectId, RightType.Create);
                        CanDelete = isAddmin || UserService.CurrentUser.HasRight(subject.SubjectId, RightType.Delete);
                        CanEdit = isAddmin || UserService.CurrentUser.HasRight(subject.SubjectId, RightType.Edit);
                        txtTestNo.ReadOnly = !(CanCreate || CanEdit);
                        txtTestName.ReadOnly = !(CanCreate || CanEdit);
                        speTestTime.Enabled = (CanCreate || CanEdit);
                        NotifyStateChanged();
                    }
                }
            }
            else
            {
                CanCreate = true;
                NotifyStateChanged();
            }
        }

        public override void Delete()
        {
            if (m_gridTests.SelectedRows.Count > 0)
            {
                if (RadMessageBox.Show("Bạn có muốn xóa bài test hiện tại?", "Xác nhận!", MessageBoxButtons.YesNo,
                                       RadMessageIcon.Error) == DialogResult.Yes)
                {
                    MultiTest test = m_gridTests.SelectedRows[0].DataBoundItem as MultiTest;
                    if (test != null)
                    {
                        test.IsDeleted = true;
                        Service.SaveAll(new List<MultiTest> { test });
                        ReloadData();
                    }
                }

            }
        }
        private void ReloadData()
        {
            ClearBindingSourceDetail();
            InternalLoadData();
            BindingSource.DataSource = EntitiesCollection;
        }
        private void OnCreateTest(object sender, EventArgs e)
        {
            if (CurrentEntity.SubjectsMultiTests.Count == 0)
            {
                RadMessageBox.Show("Vui lòng chọn môn học mà bạn cần tạo đề thi", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtTestNo.Text))
            {
                RadMessageBox.Show("Mã đề thi không được rỗng", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtTestName.Text))
            {
                RadMessageBox.Show("Tên đề thi không được rỗng", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            List<int> subjectIds = CurrentEntity.SubjectsMultiTests.Select(s => s.FK_SubjectId).ToList();
            int numOfQuestion = m_questionService.CountQuestionsInSubjects(subjectIds);
            if (numOfQuestion < speTotalQuestion.Value)
            {
                RadMessageBox.Show(string.Format("Số lượng câu hỏi của các môn được chọn hiện có là {0}.\n Vui lòng chọn số câu hỏi nhỏ hơn", numOfQuestion),
                                        "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            decimal totalQuestion = CurrentEntity.SubjectsMultiTests.Sum(s => s.EasyNo) + CurrentEntity.SubjectsMultiTests.Sum(s => s.NormalNo) +
                CurrentEntity.SubjectsMultiTests.Sum(s => s.HardNo) + CurrentEntity.SubjectsMultiTests.Sum(s => s.EasyNo1) + CurrentEntity.SubjectsMultiTests.Sum(s => s.NormalNo1) +
                CurrentEntity.SubjectsMultiTests.Sum(s => s.HardNo1);
            if (totalQuestion != speTotalQuestion.Value)
            {
                string error = string.Empty;
                foreach (var item in CurrentEntity.SubjectsMultiTests)
                {
                    error += string.Format("- {0} có {1} câu hỏi", item.Subject.SubjectNoName, item.EasyNo + item.NormalNo + item.HardNo);
                    error += "\n" + string.Format("- Trắc nghiệm:");
                    error += "\n" + string.Format("    + Dễ: {0} câu", item.EasyNo);
                    error += "\n" + string.Format("    + Trung bình: {0} câu", item.NormalNo);
                    error += "\n" + string.Format("    + Khó: {0} câu", item.HardNo);
                    error += "\n" + string.Format("- Tự luận:");
                    error += "\n" + string.Format("    + Dễ: {0} câu", item.EasyNo1);
                    error += "\n" + string.Format("    + Trung bình: {0} câu", item.NormalNo1);
                    error += "\n" + string.Format("    + Khó: {0} câu", item.HardNo1);
                    error += "\n";
                }
                RadMessageBox.Show(error + "Tổng số câu hỏi và tổng câu hỏi đã chọn không khớp nhau. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }
            decimal totalTime = speTestTime.Value;
            decimal estimateTime = speEasyQuestion.Value * 0.5m + speNormalQuestion.Value * 1 + speHardQuestion.Value * 2;
            int moreTime = Convert.ToInt32(ConfigurationManager.AppSettings["Minute"]);
            if (estimateTime > totalTime + moreTime)
            {
                if (RadMessageBox.Show("Thời gian dự tính hoàn thành bài thi nhiều hơn thời gian thi.\nBạn có muốn tiếp tục tạo đề thi không?",
                                    "Cảnh báo", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation) == DialogResult.No)
                {
                    return;
                }
            }
            if (estimateTime < totalTime + moreTime)
            {
                if (RadMessageBox.Show("Thời gian dự tính hoàn thành bài thi nhỏ hơn thời gian thi.\nBạn có muốn tiếp tục tạo đề thi không?",
                                    "Cảnh báo", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation) == DialogResult.No)
                {
                    return;
                }
            }
            // Review
            string message = string.Empty;
            foreach (var item in CurrentEntity.SubjectsMultiTests)
            {
                message += string.Format("- {0} có {1} câu hỏi", item.Subject.SubjectNoName, item.EasyNo + item.NormalNo + item.HardNo);
                message += "\n" + string.Format("- Trắc nghiệm:");
                message += "\n" + string.Format("    + Dễ: {0} câu", item.EasyNo);
                message += "\n" + string.Format("    + Trung bình: {0} câu", item.NormalNo);
                message += "\n" + string.Format("    + Khó: {0} câu", item.HardNo);
                message += "\n" + string.Format("- Tự luận:");
                message += "\n" + string.Format("    + Dễ: {0} câu", item.EasyNo1);
                message += "\n" + string.Format("    + Trung bình: {0} câu", item.NormalNo1);
                message += "\n" + string.Format("    + Khó: {0} câu", item.HardNo1);
                message += "\n";
            }
            if (RadMessageBox.Show(message + "Bạn có muốn tạo đề thi không?", "Review", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
            {
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    Dictionary<int, List<Tuple<QuestionLevel, int>>> questionsNo = new Dictionary<int, List<Tuple<QuestionLevel, int>>>();
                    Dictionary<int, List<Tuple<QuestionLevel, int>>> questionsNo1 = new Dictionary<int, List<Tuple<QuestionLevel, int>>>();
                    foreach (SubjectsMultiTest subject in CurrentEntity.SubjectsMultiTests)
                    {
                        questionsNo.Add(subject.FK_SubjectId, new List<Tuple<QuestionLevel, int>>() { 
                            new Tuple<QuestionLevel, int>(QuestionLevel.Easy, subject.EasyNo),
                            new Tuple<QuestionLevel, int>(QuestionLevel.Normal, subject.NormalNo),
                            new Tuple<QuestionLevel, int>(QuestionLevel.Hard, subject.HardNo)
                        });
                        questionsNo1.Add(subject.FK_SubjectId, new List<Tuple<QuestionLevel, int>>() { 
                            new Tuple<QuestionLevel, int>(QuestionLevel.Easy, subject.EasyNo1),
                            new Tuple<QuestionLevel, int>(QuestionLevel.Normal, subject.NormalNo1),
                            new Tuple<QuestionLevel, int>(QuestionLevel.Hard, subject.HardNo1)
                        });
                    }
                    string confirmMessage = string.Empty;
                  
                    MultiTest test = Service.CreateMixedTest(CurrentEntity, dropdownClass.SelectedValue, questionsNo, questionsNo1, CurrentEntity.CopyTestNo, CurrentEntity.TotalQuestions, CurrentEntity.Purpose, moreTime, out confirmMessage);
                    if (!string.IsNullOrEmpty(confirmMessage))
                    {
                        if (RadMessageBox.Show(confirmMessage, "Cảnh báo",
                                                MessageBoxButtons.YesNo, RadMessageIcon.Exclamation) == DialogResult.Yes)
                        {
                            Service.SaveTest(test);
                            IsDirty = false;
                            LoadSecurityStatus();
                        }
                    }
                    else
                    {
                        Service.SaveTest(test);
                        IsDirty = false;
                        LoadSecurityStatus();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            ReloadData();
        }
    
        private void OnQuestionNoChanged(object sender, EventArgs e)
        {
            if (CurrentEntity != null && CurrentEntity.MultiTestId > 0 || m_subjectBindingSource.Current == null)
                return;
            RadSpinEditor spe = sender as RadSpinEditor;
            int subjectId = (m_subjectBindingSource.Current as SubjectsMultiTest).FK_SubjectId;
            string subjectName = (m_subjectBindingSource.Current as SubjectsMultiTest).Subject.SubjectNoName;
            switch (spe.Name)
            {
                case "speTotalQuestion":
                    int totalNo = m_questionService.Count(subjectId, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (totalNo < spe.Value)
                    {
                        RadMessageBox.Show(string.Format("Tổng số câu hỏi hiện có của môn {0} là {1}, nhỏ hơn số câu hỏi bạn vừa chọn.\n{2}", subjectName, totalNo,
                                           "chương trình sẽ tự động cập nhật lại số câu hỏi bạn chọn bằng với số câu hỏi hiện có trong csdl."),
                                           "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        spe.Value = totalNo;
                    }
                    break;
                case "speEasyQuestion":
                    int easyNo = m_questionService.GetAllQuestionBySubjectAndLevel(subjectId, (int)QuestionLevel.Easy, (int)QuestionType.Choice, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (easyNo < spe.Value)
                    {
                        RadMessageBox.Show(string.Format("Số câu hỏi dễ hiện có của môn {0} la {1}, nhỏ hơn số câu hỏi dễ bạn vừa chọn.\n{2}", subjectName, easyNo,
                                           "chương trình sẽ tự động cập nhật lại số câu hỏi bạn chọn bằng với số câu hỏi hiện có trong csdl."),
                                           "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        spe.Value = easyNo;
                    }
                    break;
                case "speNormalQuestion":
                    int normalNo = m_questionService.GetAllQuestionBySubjectAndLevel(subjectId, (int)QuestionLevel.Normal, (int)QuestionType.Choice, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (normalNo < spe.Value)
                    {
                        RadMessageBox.Show(string.Format("Số câu hỏi trung bình hiện có của môn {0} la {1}, nhỏ hơn số câu hỏi trung bình bạn vừa chọn.\n{2}", subjectName, normalNo,
                                           "chương trình sẽ tự động cập nhật lại số câu hỏi bạn chọn bằng với số câu hỏi hiện có trong csdl."),
                                           "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        spe.Value = normalNo;
                    }
                    break;
                case "speHardQuestion":
                    int hardNo = m_questionService.GetAllQuestionBySubjectAndLevel(subjectId, (int)QuestionLevel.Hard, (int)QuestionType.Choice, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (hardNo < spe.Value)
                    {
                        RadMessageBox.Show(string.Format("Số câu hỏi khó hiện có của môn {0} la {1}, nhỏ hơn số câu hỏi khó bạn vừa chọn.\n{2}", subjectName, hardNo,
                                           "chương trình sẽ tự động cập nhật lại số câu hỏi bạn chọn bằng với số câu hỏi hiện có trong csdl."),
                                           "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        spe.Value = hardNo;
                    }
                    break;
                case "speEasyQuestion1":
                    int easyNo1 = m_questionService.GetAllQuestionBySubjectAndLevel(subjectId, (int)QuestionLevel.Easy, (int)QuestionType.Custom, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (easyNo1 < spe.Value)
                    {
                        RadMessageBox.Show(string.Format("Số câu hỏi dễ hiện có của môn {0} la {1}, nhỏ hơn số câu hỏi dễ bạn vừa chọn.\n{2}", subjectName, easyNo1,
                                           "chương trình sẽ tự động cập nhật lại số câu hỏi bạn chọn bằng với số câu hỏi hiện có trong csdl."),
                                           "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        spe.Value = easyNo1;
                    }
                    break;
                case "speNormalQuestion1":
                    int normalNo1 = m_questionService.GetAllQuestionBySubjectAndLevel(subjectId, (int)QuestionLevel.Normal, (int)QuestionType.Custom, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (normalNo1 < spe.Value)
                    {
                        RadMessageBox.Show(string.Format("Số câu hỏi trung bình hiện có của môn {0} la {1}, nhỏ hơn số câu hỏi trung bình bạn vừa chọn.\n{2}", subjectName, normalNo1,
                                           "chương trình sẽ tự động cập nhật lại số câu hỏi bạn chọn bằng với số câu hỏi hiện có trong csdl."),
                                           "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        spe.Value = normalNo1;
                    }
                    break;
                case "speHardQuestion1":
                    int hardNo1 = m_questionService.GetAllQuestionBySubjectAndLevel(subjectId, (int)QuestionLevel.Hard, (int)QuestionType.Custom, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (hardNo1 < spe.Value)
                    {
                        RadMessageBox.Show(string.Format("Số câu hỏi khó hiện có của môn {0} la {1}, nhỏ hơn số câu hỏi khó bạn vừa chọn.\n{2}", subjectName, hardNo1,
                                           "chương trình sẽ tự động cập nhật lại số câu hỏi bạn chọn bằng với số câu hỏi hiện có trong csdl."),
                                           "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        spe.Value = hardNo1;
                    }
                    break;
                default:
                    break;
            }
        }

        private void OnCellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            frmSelectedMultiTestCopy selectMultiTest = new frmSelectedMultiTestCopy(CurrentEntity.MultiTestId);
            selectMultiTest.ShowDialog();
        }

        private void DisableControl()
        {
            btnNext.Enabled = false;
            btnPre.Enabled = false;
            btnCreateTest.Enabled = false;
            txtTestNo.Enabled = false;
            txtTestName.Enabled = false;
            dtpTestDate.Enabled = false;
            speTotalQuestion.Enabled = false;
            speTestTime.Enabled = false;
            speSubTest.Enabled = false;
            ddlPurpose.Enabled = false;
            speEasyQuestion.Enabled = false;
            speNormalQuestion.Enabled = false;
            speHardQuestion.Enabled = false;
            speEasyQuestion1.Enabled = false;
            speNormalQuestion1.Enabled = false;
            speHardQuestion1.Enabled = false;
        }

        private void EnableControl()
        {
            btnNext.Enabled = true;
            btnPre.Enabled = true;
            btnCreateTest.Enabled = true;
            txtTestNo.Enabled = true;
            txtTestName.Enabled = true;
            dtpTestDate.Enabled = true;
            speTotalQuestion.Enabled = true;
            speTestTime.Enabled = true;
            speSubTest.Enabled = true;
            ddlPurpose.Enabled = true;
            speEasyQuestion.Enabled = true;
            speNormalQuestion.Enabled = true;
            speHardQuestion.Enabled = true;
            speEasyQuestion1.Enabled = true;
            speNormalQuestion1.Enabled = true;
            speHardQuestion1.Enabled = true;
        }
    }
}
