﻿using System.Linq;
using Common;
using Controller.Services;
using Model.POCO;
using NganHangDeThi.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace NganHangDeThi.Form_Popup
{
    public partial class frmEditQuestion : SimpleBaseForm<Question, QuestionsService>
    {
        private SubjectsService m_subjectService = new SubjectsService();

        private List<Subject> m_importedSubjects;

        public frmEditQuestion()
        {
            InitializeComponent();
            m_cbxSubjects.DataSource = m_subjectService.GetAllSubject();
            m_cbxSubjects.DisplayMember = "Name";
            m_cbxQuestionLevels.DataSource = new BindingSource { DataSource = EnumHelpers.GetAllQuestionLevels() };
            m_cbxPurposes.DataSource = new BindingSource { DataSource = EnumHelpers.GetAllQuestionPurpose() };

            m_cbxQuestionLevels.DisplayMember = "DisplayText";
            m_cbxQuestionLevels.ValueMember = "Value";
            m_cbxPurposes.DisplayMember = "DisplayText";
            m_cbxPurposes.ValueMember = "Value";
            this.m_gridQuestions.ShowGroupPanel = false;
            this.m_gridQuestions.EnableHotTracking = true;
            this.m_gridQuestions.ShowFilteringRow = true;
            this.m_gridQuestions.EnableFiltering = true;
            this.m_gridQuestions.EnableCustomFiltering = true;

            radRadioButton1.ToggleStateChanged += OnToggleStateChanged;
            radRadioButton2.ToggleStateChanged += OnToggleStateChanged;
            radRadioButton3.ToggleStateChanged += OnToggleStateChanged;
            radRadioButton4.ToggleStateChanged += OnToggleStateChanged;
            chkRandomAnswer.ToggleStateChanged += ChkRandomAnswerOnToggleStateChanged;
            m_cbxSubjects.SelectedIndexChanged += OnSubjectChanged;
            m_cbxQuestionLevels.SelectedIndexChanged += OnQuestionLevelChanged;
        }

        private void ChkRandomAnswerOnToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (CurrentEntity != null)
            {
                CurrentEntity.IsAnswerRandom = chkRandomAnswer.Checked;
            }
        }

        public frmEditQuestion(IList<Subject> importedSubjects)
        {
            InitializeComponent();
            m_importedSubjects = importedSubjects.ToList();
            m_cbxSubjects.DataSource = m_importedSubjects;
            m_cbxSubjects.DisplayMember = "Name";
            m_cbxQuestionLevels.DataSource = new BindingSource { DataSource = EnumHelpers.GetAllQuestionLevels() };
            m_cbxPurposes.DataSource = new BindingSource { DataSource = EnumHelpers.GetAllQuestionPurpose() };

            m_cbxQuestionLevels.DisplayMember = "DisplayText";
            m_cbxQuestionLevels.ValueMember = "Value";
            m_cbxPurposes.DisplayMember = "DisplayText";
            m_cbxPurposes.ValueMember = "Value";
            this.m_gridQuestions.ShowGroupPanel = false;
            this.m_gridQuestions.EnableHotTracking = true;
            this.m_gridQuestions.ShowFilteringRow = true;
            this.m_gridQuestions.EnableFiltering = true;
            this.m_gridQuestions.EnableCustomFiltering = true;
            // Add header checkbox column
            CustomCheckBoxColumn column = new CustomCheckBoxColumn();
            column.FieldName = "Checked";
            column.Name = "colChecked";
            column.HeaderText = "All";
            m_gridQuestions.Columns.Insert(0, column);

            radRadioButton1.ToggleStateChanged += OnToggleStateChanged;
            radRadioButton2.ToggleStateChanged += OnToggleStateChanged;
            radRadioButton3.ToggleStateChanged += OnToggleStateChanged;
            radRadioButton4.ToggleStateChanged += OnToggleStateChanged;
            m_cbxSubjects.SelectedIndexChanged += OnSubjectChanged;
            m_cbxQuestionLevels.SelectedIndexChanged += OnQuestionLevelChanged;
        }

        private void OnQuestionLevelChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (CurrentEntity != null && m_cbxQuestionLevels.SelectedItem != null)
            {
                var selectedItem = m_cbxQuestionLevels.SelectedItem.DataBoundItem as EnumDisplay;
                if (selectedItem != null)
                {
                    var selectedLevel = selectedItem.Value;
                    if (selectedLevel == (int)QuestionLevel.Easy)
                    {
                        CurrentEntity.Time = Convert.ToDouble(Constants.DEFAULT_EASY_QUESTION_TIME);
                    }
                    else if (selectedLevel == (int)QuestionLevel.Normal)
                    {
                        CurrentEntity.Time = Convert.ToDouble(Constants.DEFAULT_BASIC_QUESTION_TIME);
                    }
                    else if (selectedLevel == (int)QuestionLevel.Hard)
                    {
                        CurrentEntity.Time = Convert.ToDouble(Constants.DEFAULT_ADVANCE_QUESTION_TIME);
                    }
                }
            }
        }

        private void OnSubjectChanged(object sender, EventArgs e)
        {
            InternalLoadData();
            BindingSource.DataSource = EntitiesCollection;
            LoadSecurityStatus();
        }
        void OnToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            var rb = sender as RadRadioButton;
            if (CurrentEntity != null && rb != null && !IsBinding && rb.IsChecked)
            {
                CurrentEntity.AnswerA.IsAnswer = radRadioButton1.IsChecked;
                CurrentEntity.AnswerB.IsAnswer = radRadioButton2.IsChecked;
                CurrentEntity.AnswerC.IsAnswer = radRadioButton3.IsChecked;
                CurrentEntity.AnswerD.IsAnswer = radRadioButton4.IsChecked;
            }
        }
        protected override Question InternalCreateNew()
        {
            Question question = base.InternalCreateNew();
            var subject = m_cbxSubjects.SelectedItem.DataBoundItem as Subject;
            if (subject != null)
            {
                question.FK_SubjectId = subject.SubjectId;
            }
            question.Type = (int)QuestionType.Choice;
            question.CreatedBy = UserService.CurrentUser.CurrentUser.Username;
            question.Level = (int)QuestionLevel.Normal;
            question.Time = Convert.ToDouble(Constants.DEFAULT_BASIC_QUESTION_TIME);
            question.CreatedDate = DateTime.Now;
            question.IsDelete = false;
            question.UpdatedDate = DateTime.Now;
            question.UpdatedBy = UserService.CurrentUser.CurrentUser.Username;
            question.Answers.Add(new Answer());
            question.Answers.Add(new Answer());
            question.Answers.Add(new Answer());
            question.Answers.Add(new Answer());

            return question;
        }
        private void OnCustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            if (string.IsNullOrEmpty(this.filterTextBox.Text))
            {
                e.Visible = true;
                for (int i = 0; i < this.m_gridQuestions.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                    e.Row.InvalidateRow();
                }
                return;
            }
            e.Visible = false;
            for (int i = 0; i < this.m_gridQuestions.ColumnCount; i++)
            {
                if (e.Row.Cells[i].Value != null)
                {
                    string text = e.Row.Cells[i].Value.ToString();
                    if (text.IndexOf(this.filterTextBox.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        e.Visible = true;
                        e.Row.Cells[i].Style.CustomizeFill = true;
                        e.Row.Cells[i].Style.DrawFill = true;
                        e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                    }
                    else
                    {
                        e.Row.Cells[i].Style.Reset(); e.Row.InvalidateRow();
                    }
                }
            }
        }
        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            this.m_gridQuestions.MasterTemplate.Refresh();
        }
        protected override void SetBindingSource()
        {
            BindingSource.CurrentChanged += BindingSource_CurrentChanged;
            m_gridQuestions.DataSource = BindingSource;

            CurrentEntity.PropertyChanged += (sender, e) => { IsDirty = false; };
        }

        void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CurrentEntity != null)
            {
                IsBinding = true;
                radRadioButton1.IsChecked = CurrentEntity.AnswerA.IsAnswer;
                if (CurrentEntity.AnswerB != null)
                {
                    radRadioButton2.IsChecked = CurrentEntity.AnswerB.IsAnswer;
                }
                if (CurrentEntity.AnswerC != null)
                {
                    radRadioButton3.IsChecked = CurrentEntity.AnswerC.IsAnswer;
                }
                if (CurrentEntity.AnswerD != null)
                {
                    radRadioButton4.IsChecked = CurrentEntity.AnswerD.IsAnswer;
                }
                chkRandomAnswer.IsChecked = CurrentEntity.IsAnswerRandom.GetValueOrDefault(false);
                IsBinding = false;
            }
        }
        protected override void SetDetailBindingSource()
        {
            base.SetDetailBindingSource();
            m_txtContent.DataBindings.Add("Text", BindingSource, "Content");
            m_cbxQuestionLevels.DataBindings.Add("SelectedValue", BindingSource, "Level", false, DataSourceUpdateMode.OnPropertyChanged);
            m_cbxPurposes.DataBindings.Add("SelectedValue", BindingSource, "Purpose", false,
                                           DataSourceUpdateMode.OnPropertyChanged);
            m_spinTime.DataBindings.Add("Value", BindingSource, "Time", false, DataSourceUpdateMode.OnPropertyChanged);

            //radRadioButton1.DataBindings.Add("IsChecked", BindingSource, "AnswerA.IsAnswer");
            //radRadioButton2.DataBindings.Add("IsChecked", BindingSource, "AnswerB.IsAnswer");
            //radRadioButton3.DataBindings.Add("IsChecked", BindingSource, "AnswerC.IsAnswer");
            //radRadioButton4.DataBindings.Add("IsChecked", BindingSource, "AnswerD.IsAnswer");

            m_txtAnswerA.DataBindings.Add("Text", BindingSource, "AnswerA.Content");
            m_txtAnswerB.DataBindings.Add("Text", BindingSource, "AnswerB.Content");
            m_txtAnswerC.DataBindings.Add("Text", BindingSource, "AnswerC.Content");
            m_txtAnswerD.DataBindings.Add("Text", BindingSource, "AnswerD.Content");
        }
        protected override void InternalLoadData()
        {
            if (m_cbxSubjects.SelectedItem != null)
            {
                var subject = (Subject)m_cbxSubjects.SelectedItem.DataBoundItem;
                var questions = subject.Questions.ToList();
                foreach (var question in questions)
                {
                    if (question.Content.Contains("rtf1"))
                        question.Content = RtfHelpers.ConvertRtfToText(question.Content);
                }
                EntitiesCollection = subject.Questions.ToList();
            }
            else
            {
                EntitiesCollection = new List<Question>();
            }
        }
        public override void LoadSecurityStatus()
        {
            //if (m_cbxSubjects.SelectedItem != null) {
            //    var subject = m_cbxSubjects.SelectedItem.DataBoundItem as Subject;
            //    if (subject != null) {
            //        bool isAddmin = UserService.CurrentUser.HasRole(UserRole.Administrator);
            //        CanCreate = isAddmin || UserService.CurrentUser.HasRight(subject.SubjectId, RightType.Create);
            //        CanDelete = isAddmin || UserService.CurrentUser.HasRight(subject.SubjectId, RightType.Delete);
            //        CanEdit = isAddmin || UserService.CurrentUser.HasRight(subject.SubjectId, RightType.Edit);
            //        m_txtContent.ReadOnly = !(CanCreate || CanEdit);
            //        m_cbxQuestionLevels.Enabled = (CanCreate || CanEdit);
            //        m_cbxPurposes.Enabled = (CanCreate || CanEdit);
            //        m_spinTime.Enabled = (CanCreate || CanEdit);
            //        NotifyStateChanged();
            //    }
            //}
            IsDirty = false;
            CanEdit = false;
        }

        public override void Save()
        {
            //foreach (Question question in EntitiesCollection.Where(q => q.IsAddNew || q.HasChanged)) {
            //    foreach (Answer answer in question.Answers) {
            //        string[] content = answer.Content.Split(' ');
            //        int a = content.Where(c => c.Trim().Equals("a", StringComparison.OrdinalIgnoreCase)).Count();
            //        int b = content.Where(c => c.Trim().Equals("b", StringComparison.OrdinalIgnoreCase)).Count();
            //        int c1 = content.Where(c => c.Trim().Equals("c", StringComparison.OrdinalIgnoreCase)).Count();
            //        if (a + b + c1 > 1) {
            //            question.IsAnswerRandom = false;
            //        }
            //    }
            //}
            //base.Save();
            throw new NotImplementedException();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            EntitiesCollection.ForEach(x => x.AcceptChanged());
            base.OnClosing(e);
        }

        public bool IsBinding { get; set; }

        private void m_btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                IList<Subject> importedSubjects = m_importedSubjects;
                List<Guid> questionGuids = new List<Guid>();
                List<Tuple<int, Guid>> questionGuidBySubjects = new List<Tuple<int, Guid>>();
                foreach (var subject in importedSubjects)
                {
                    //questionGuids.AddRange(subject.Questions.Select(x => x.QuestionGuid));
                    //Khac mon hoc cung Guid khong can check
                    //questionGuids.AddRange(subject.Questions.Select(x => x.QuestionGuid));
                    var firstOrDefault = subject.Questions.FirstOrDefault(x => x.FK_SubjectId == subject.SubjectId);
                    if (firstOrDefault != null)
                    {
                        var subjectQuestionGuid = new Tuple<int, Guid>(subject.SubjectId, firstOrDefault.QuestionGuid);
                        questionGuidBySubjects.Add(subjectQuestionGuid);
                    }
                }
                //Khac mon hoc cung Guid khong can check
                //var existedQuestionGuids = Service.GetExitsQuestionGuids(questionGuids);

                //Remove all question from imported if it is existed in database (other word: don't import if it is existed)
                foreach (var subject in importedSubjects)
                {
                    var existsQuestionGuidBySubjectId =
                        questionGuidBySubjects.FirstOrDefault(x => x.Item1 == subject.SubjectId);

                    var questions =
                        subject.Questions.Where(
                            x =>
                            existsQuestionGuidBySubjectId != null && (x.FK_SubjectId == existsQuestionGuidBySubjectId.Item1 &&
                                                                      x.QuestionGuid == existsQuestionGuidBySubjectId.Item2 || !x.Checked)).ToList();
                    foreach (var q in questions)
                    {
                        subject.Questions.Remove(q);
                    }
                }
                var subjectsGuids = importedSubjects.Select(x => x.SubjectGuid).ToList();

                List<Subject> existingSubjects = m_subjectService.GetSubjectsBySubjectGuid(subjectsGuids);
                var addNewSubjects =
                    importedSubjects.Where(x => existingSubjects.All(y => y.SubjectGuid != x.SubjectGuid)).ToList();
                if (UserService.CurrentUser.HasRole(UserRole.Administrator) && addNewSubjects.Count > 0)
                {
                    if (RadMessageBox.Show(
                        string.Format("Hiện chưa có môn học {0} bạn có muốn import vào không?",
                                      addNewSubjects[0].Name), "Xác nhận", MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        m_subjectService.SaveAll(addNewSubjects);
                    }
                }

                // Add all question in imported to existed subject
                string successMessage = string.Empty;
                foreach (var subject in existingSubjects)
                {
                    var imSubject = importedSubjects.FirstOrDefault(x => x.SubjectGuid == subject.SubjectGuid);
                    if (imSubject != null)
                    {
                        successMessage += string.Format("- Môn {0} : {1} câu.\n", imSubject.Name, imSubject.Questions.Count);
                        foreach (var q in imSubject.Questions)
                        {
                            subject.Questions.Add(q);
                        }
                    }
                }
                m_subjectService.SaveAll(existingSubjects);
                RadMessageBox.Show(successMessage, "Thành công", MessageBoxButtons.OK);

            }
            catch (Exception)
            {
                RadMessageBox.Show("Có lỗi trong quá trình nhập từ file!", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void m_btnExport_Click(object sender, EventArgs e)
        {
            if (m_cbxSubjects.SelectedItem == null)
            {
                RadMessageBox.Show("Xin vui lòng chọn môn học để xuất câu hỏi!", "Lỗi", MessageBoxButtons.OK,
                                   RadMessageIcon.Error);
                return;
            }
            if (EntitiesCollection == null || EntitiesCollection.Count == 0)
            {
                RadMessageBox.Show("Môn học hiện tại không có câu hỏi nào bạn không thể xuất ra file.\nXin vui lòng chọn môn học khác!", "Lỗi", MessageBoxButtons.OK,
                                   RadMessageIcon.Error);
                return;
            }
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "qbk(*.qbk)| *.qbk";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportHelpers.ExportQuestion(fileDialog.FileName, EntitiesCollection);
                RadMessageBox.Show("Hoàn tất");
            }
        }
    }
}
