using Common;
using Controller.Services;
using Model.POCO;
using NganHangDeThi.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using Telerik.WinControls.UI;

namespace NganHangDeThi {
    public partial class frmCustomQuestion : SimpleBaseForm<Question, QuestionsService>
    {
        #region Properties
        private SubjectsService m_subjectsService;
        private bool m_isFirstLoad = true;
        private bool IsBinding = false;
        #endregion

        #region contructor
        public frmCustomQuestion() {
            InitializeComponent();
            this.m_gridQuestions.ShowGroupPanel = false;
            this.m_gridQuestions.EnableHotTracking = true;
            this.m_gridQuestions.ShowFilteringRow = true;
            this.m_gridQuestions.EnableFiltering = true;
            this.m_gridQuestions.EnableCustomFiltering = true;
            m_txtAnswer.AcceptsReturn = true;
            m_txtContent.AcceptsReturn = true;
            m_subjectsService = new SubjectsService();
            m_cbxLevels.DataSource = new BindingSource { DataSource = EnumHelpers.GetAllQuestionLevels() };
            m_cbxPurposes.DataSource = new BindingSource { DataSource = EnumHelpers.GetAllQuestionPurpose() };
            m_cbxLevels.DisplayMember = "DisplayText";
            m_cbxLevels.ValueMember = "Value";
            m_cbxPurposes.DisplayMember = "DisplayText";
            m_cbxPurposes.ValueMember = "Value";
            InitSubjectCombobox();
            m_cbxLevels.SelectedIndexChanged += m_cbxLevels_SelectedIndexChanged;
            m_gridQuestions.ViewCellFormatting += m_gridQuestions_ViewCellFormatting;
        }

        private void m_gridQuestions_ViewCellFormatting(object sender, CellFormattingEventArgs e) {
            if (e.CellElement is GridRowHeaderCellElement) {
                e.CellElement.Image = null;
                e.CellElement.Text = (m_gridQuestions.CurrentView.ViewInfo.Rows.IndexOf(e.Row) + 1).ToString();
            }
        }

        private void m_cbxLevels_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e) {
            if (CurrentEntity != null && !IsBinding && m_cbxLevels.SelectedItem != null) {
                var selectedItem = m_cbxLevels.SelectedItem.DataBoundItem as EnumDisplay;
                if (selectedItem != null) {
                    var selectedLevel = selectedItem.Value;
                    if (selectedLevel == (int)QuestionLevel.Easy) {
                        CurrentEntity.Time = Convert.ToDouble(Constants.DEFAULT_EASY_QUESTION_TIME);
                    } else if (selectedLevel == (int)QuestionLevel.Normal) {
                        CurrentEntity.Time = Convert.ToDouble(Constants.DEFAULT_BASIC_QUESTION_TIME);
                    } else if (selectedLevel == (int)QuestionLevel.Hard) {
                        CurrentEntity.Time = Convert.ToDouble(Constants.DEFAULT_ADVANCE_QUESTION_TIME);
                    }
                }
            }
        }


        private void InitSubjectCombobox() {
            m_cbxSubjects.DataSource = m_subjectsService.GetAllSubject();
            m_cbxSubjects.DisplayMember = "Name";
        }
        #endregion

        protected override void SetDetailBindingSource() {
            IsBinding = true;
            m_txtContent.DataBindings.Add("Text", BindingSource, "Content", false, DataSourceUpdateMode.OnPropertyChanged);
            m_cbxLevels.DataBindings.Add("SelectedValue", BindingSource, "Level", false, DataSourceUpdateMode.OnPropertyChanged);
            m_cbxPurposes.DataBindings.Add("SelectedValue", BindingSource, "Purpose", false,
                                           DataSourceUpdateMode.OnPropertyChanged);
            m_spinTime.DataBindings.Add("Value", BindingSource, "Time", false, DataSourceUpdateMode.OnPropertyChanged);
            m_txtAnswer.DataBindings.Clear();
            if (CurrentEntity != null) {
                m_txtAnswer.DataBindings.Add("Text", CurrentEntity.AnswerA, "Content");
            }
            IsBinding = false;
        }

        protected override void SetBindingSource() {
            m_gridQuestions.DataSource = BindingSource;
            BindingSource.CurrentChanged += OnBindingSourceCurrentChanged;
        }

        void OnBindingSourceCurrentChanged(object sender, EventArgs e) {
            m_txtAnswer.DataBindings.Clear();
            m_txtAnswer.Text = string.Empty;
            if (CurrentEntity != null) {
                m_txtAnswer.DataBindings.Add("Text", CurrentEntity.AnswerA, "Content");
            }
        }

        protected override void InternalLoadData() {
            if (m_cbxSubjects.SelectedItem != null) {
                var subject = (Subject)m_cbxSubjects.SelectedItem.DataBoundItem;
                EntitiesCollection = Service.GetAllQuestionBySubject(subject.SubjectId, QuestionType.Custom);
            } else {
                EntitiesCollection = new List<Question>();
            }
        }
        protected override Question InternalCreateNew() {
            var q = base.InternalCreateNew();
            var subject = m_cbxSubjects.SelectedItem.DataBoundItem as Subject;
            if (subject != null) {
                q.FK_SubjectId = subject.SubjectId;
            }
            q.Type = (int)QuestionType.Custom;
            q.CreatedBy = UserService.CurrentUser.CurrentUser.Username;
            q.Time = Convert.ToDouble(Constants.DEFAULT_BASIC_QUESTION_TIME);
            q.Level = (int)QuestionLevel.Normal;
            q.CreatedDate = DateTime.Now;
            q.IsDelete = false;
            q.UpdatedDate = DateTime.Now;
            var answer = new Answer();
            answer.Content = string.Empty;
            answer.IsAnswer = true;
            answer.IsAddNew = true;
            q.Answers.Add(answer);
            q.UpdatedBy = UserService.CurrentUser.CurrentUser.Username;
            return q;
        }
        private void OnSubjectChanged(object sender, EventArgs e) {
            if (!m_isFirstLoad) {
                InternalLoadData();
                BindingSource.DataSource = EntitiesCollection;
                LoadSecurityStatus();
            }
            m_isFirstLoad = false;
        }
        public override void LoadSecurityStatus() {
            if (m_cbxSubjects.SelectedItem != null) {
                var subject = m_cbxSubjects.SelectedItem.DataBoundItem as Subject;
                if (subject != null) {
                    bool isAddmin = UserService.CurrentUser.HasRole(UserRole.Administrator);
                    CanCreate = isAddmin || UserService.CurrentUser.HasRight(subject.SubjectId, RightType.Create);
                    CanDelete = isAddmin || UserService.CurrentUser.HasRight(subject.SubjectId, RightType.Delete);
                    CanEdit = isAddmin || UserService.CurrentUser.HasRight(subject.SubjectId, RightType.Edit);
                    m_txtContent.ReadOnly = !(CanCreate || CanEdit);
                    m_cbxLevels.Enabled = (CanCreate || CanEdit);
                    m_cbxPurposes.Enabled = (CanCreate || CanEdit);
                    m_spinTime.Enabled = (CanCreate || CanEdit);
                    NotifyStateChanged();
                }
            }
        }

        private void m_btnExport_Click(object sender, EventArgs e) {
            if (m_cbxSubjects.SelectedItem == null) {
                RadMessageBox.Show("Xin vui lòng chọn môn học để xuất câu hỏi!", "Lỗi", MessageBoxButtons.OK,
                                   RadMessageIcon.Error);
                return;
            }
            if (EntitiesCollection == null || EntitiesCollection.Count == 0) {
                RadMessageBox.Show("Môn học hiện tại không có câu hỏi nào bạn không thể xuất ra file.\nXin vui lòng chọn môn học khác!", "Lỗi", MessageBoxButtons.OK,
                                   RadMessageIcon.Error);
                return;
            }
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Xml(*.xml)| *.xml";
            if (fileDialog.ShowDialog() == DialogResult.OK) {
                ExportHelpers.ExportQuestion(fileDialog.FileName, EntitiesCollection);
            }
        }

        private void m_btnImport_Click(object sender, EventArgs e) {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                try {
                    IList<Subject> importedSubjects = ExportHelpers.ImportQuestion(dialog.FileName);
                    List<Guid> questionGuids = new List<Guid>();
                    foreach (var subject in importedSubjects) {
                        questionGuids.AddRange(subject.Questions.Select(x => x.QuestionGuid));
                    }
                    var existedQuestionGuids = Service.GetExitsQuestionGuids(questionGuids);

                    //Remove all question from imported if it is existed in database (other word: don't import if it is existed)
                    foreach (var subject in importedSubjects) {
                        var questions = subject.Questions.Where(x => existedQuestionGuids.Contains(x.QuestionGuid));
                        foreach (var q in questions) {
                            subject.Questions.Remove(q);
                        }
                    }
                    var subjectsGuids = importedSubjects.Select(x => x.SubjectGuid).ToList();

                    List<Subject> existingSubjects = m_subjectsService.GetSubjectsBySubjectGuid(subjectsGuids);
                    var addNewSubjects =
                        importedSubjects.Where(x => existingSubjects.All(y => y.SubjectGuid != x.SubjectGuid)).ToList();
                    if (UserService.CurrentUser.HasRole(UserRole.Administrator) && addNewSubjects.Count > 0) {
                        if (RadMessageBox.Show(
                            string.Format("Hiện chưa có môn học {0} bạn có muốn import vào không?",
                                          addNewSubjects[0].Name), "Confirmation", MessageBoxButtons.YesNo) ==
                            DialogResult.Yes) {
                            m_subjectsService.SaveAll(addNewSubjects);
                        }
                    }

                    // Add all question in imported to existed subject
                    foreach (var subject in existingSubjects) {
                        var imSubject = importedSubjects.FirstOrDefault(x => x.SubjectGuid == subject.SubjectGuid);
                        if (imSubject != null) {
                            foreach (var q in imSubject.Questions) {
                                subject.Questions.Add(q);
                            }
                        }
                    }
                    m_subjectsService.SaveAll(existingSubjects);

                } catch (Exception) {
                    RadMessageBox.Show("Có lỗi trong quá trình nhập từ file!", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }

        private void OnShowReport(object sender, EventArgs e) {
            if (m_cbxSubjects.SelectedItem == null) {
                RadMessageBox.Show("Xin vui lòng chọn môn học để xuất câu hỏi!", "Lỗi", MessageBoxButtons.OK,
                                   RadMessageIcon.Error);
                return;
            }
            if (EntitiesCollection == null || EntitiesCollection.Count == 0) {
                RadMessageBox.Show("Môn học hiện tại không có câu hỏi nào bạn không thể xuất ra file.\nXin vui lòng chọn môn học khác!", "Lỗi", MessageBoxButtons.OK,
                                   RadMessageIcon.Error);
                return;
            }
            Subject subject = m_cbxSubjects.SelectedItem.DataBoundItem as Subject;
            CustomReportForm report = new CustomReportForm(subject.SubjectId);
            report.ShowDialog();
        }
    }
}
