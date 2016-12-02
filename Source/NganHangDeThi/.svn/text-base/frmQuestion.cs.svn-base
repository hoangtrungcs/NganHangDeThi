using System.Collections.Specialized;
using System.Linq;
using Common;
using Controller.Services;
using Model.POCO;
using NganHangDeThi.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.RichTextBox.Model;
using Telerik.WinControls.UI;
using NganHangDeThi.Form_Popup;

namespace NganHangDeThi
{
    public partial class frmQuestion : SimpleBaseForm<Question, QuestionsService>
    //public partial class frmQuestion : BaseForm
    {
        readonly ContextMenu _contextMenu = new ContextMenu();
        private EventHandler _menuHandler;

        private SubjectsService m_subjectService = new SubjectsService();
        public frmQuestion()
        {
            InitializeComponent();

            m_txtContent.ContextMenu = _contextMenu;
            _menuHandler = new EventHandler(ContentMenu_Click);

            m_cbxSubjects.DataSource = m_subjectService.GetAllSubject();
            m_cbxSubjects.DisplayMember = "Name";
            
            m_cbxSubjects.DropDownStyle = RadDropDownStyle.DropDownList;
            m_cbxPurposes.DropDownStyle=RadDropDownStyle.DropDownList;
            m_cbxQuestionLevels.DropDownStyle=RadDropDownStyle.DropDownList;

            m_cbxQuestionLevels.DataSource = new BindingSource { DataSource = EnumHelpers.GetAllQuestionLevels() };
            m_cbxPurposes.DataSource = new BindingSource { DataSource = EnumHelpers.GetAllQuestionPurpose() };
            //m_txtContent.AcceptsTab = true;
            //m_txtAnswerA.AcceptsReturn = true;
            m_txtAnswerB.AcceptsReturn = true;
            m_txtAnswerC.AcceptsReturn = true;
            m_txtAnswerD.AcceptsReturn = true;

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
            m_gridQuestions.ViewCellFormatting += m_gridQuestions_ViewCellFormatting;
        }

        private void ChkRandomAnswerOnToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (CurrentEntity != null)
            {
                CurrentEntity.IsAnswerRandom = chkRandomAnswer.Checked;
            }
        }

        private void ContentMenu_Click(object sender, EventArgs e)
        {
            if (_contextMenu.MenuItems[0].Text == "Thêm hình ảnh")
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "JPG files (*.jpg)|*.jpg";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(openFileDialog1.FileName);
                    Clipboard.SetImage(image);
                    m_txtContent.Paste();
                    Clipboard.Clear();
                }
            }
            else if (_contextMenu.MenuItems[0].Text == "Chỉnh sửa")
            {
                //var width= m_txtContent.Text.Substring(m_txtContent.SelectedRtf.IndexOf(@"\pict\wmetafile"),)
                //ResizeImage frmResizeImage=new ResizeImage();
            }
        }

        private void m_gridQuestions_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "STT" && string.IsNullOrEmpty(e.CellElement.Text))
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
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
            question.Purpose = (int)PurposeOverview.Total;
            question.Time = Convert.ToDouble(Constants.DEFAULT_BASIC_QUESTION_TIME);
            question.CreatedDate = DateTime.Now;
            question.IsDelete = false;
            question.UpdatedDate = DateTime.Now;
            question.UpdatedBy = UserService.CurrentUser.CurrentUser.Username;
            question.Answers.Add(new Answer());
            question.Answers.Add(new Answer());
            question.Answers.Add(new Answer());
            question.Answers.Add(new Answer());
            question.AnswerD.IsAnswer = true;
            question.QuestionGuid = Guid.NewGuid();
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
        }

        void BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CurrentEntity != null)
            {
                IsBinding = true;
                radRadioButton1.IsChecked = CurrentEntity.AnswerA.IsAnswer;
                radRadioButton2.IsChecked = CurrentEntity.AnswerB.IsAnswer;
                radRadioButton3.IsChecked = CurrentEntity.AnswerC.IsAnswer;
                radRadioButton4.IsChecked = CurrentEntity.AnswerD.IsAnswer;
                chkRandomAnswer.IsChecked = CurrentEntity.IsAnswerRandom.GetValueOrDefault(false);
                IsBinding = false;
            }
        }
        protected override void SetDetailBindingSource()
        {
            base.SetDetailBindingSource();
            m_txtContent.DataBindings.Add("Rtf", BindingSource, "Content", true, DataSourceUpdateMode.OnValidation);
            m_cbxQuestionLevels.DataBindings.Add("SelectedValue", BindingSource, "Level", false, DataSourceUpdateMode.OnPropertyChanged);
            m_cbxPurposes.DataBindings.Add("SelectedValue", BindingSource, "Purpose", false,
                                           DataSourceUpdateMode.OnPropertyChanged);
            m_spinTime.DataBindings.Add("Value", BindingSource, "Time", false, DataSourceUpdateMode.OnPropertyChanged);

            //radRadioButton1.DataBindings.Add("IsChecked", BindingSource, "AnswerA.IsAnswer");
            //radRadioButton2.DataBindings.Add("IsChecked", BindingSource, "AnswerB.IsAnswer");
            //radRadioButton3.DataBindings.Add("IsChecked", BindingSource, "AnswerC.IsAnswer");
            //radRadioButton4.DataBindings.Add("IsChecked", BindingSource, "AnswerD.IsAnswer");

            m_txtAnswerA.DataBindings.Add("Text", BindingSource, "AnswerA.Content", true, DataSourceUpdateMode.OnPropertyChanged);
            m_txtAnswerB.DataBindings.Add("Text", BindingSource, "AnswerB.Content", false, DataSourceUpdateMode.OnPropertyChanged);
            m_txtAnswerC.DataBindings.Add("Text", BindingSource, "AnswerC.Content", false, DataSourceUpdateMode.OnPropertyChanged);
            m_txtAnswerD.DataBindings.Add("Text", BindingSource, "AnswerD.Content", false, DataSourceUpdateMode.OnPropertyChanged);
            BindingSource_CurrentChanged(null, null);
        }
        protected override void InternalLoadData()
        {
            if (m_cbxSubjects.SelectedItem != null)
            {
                var subject = (Subject)m_cbxSubjects.SelectedItem.DataBoundItem;
                var lstQuestions = Service.GetAllQuestionBySubject(subject.SubjectId, QuestionType.Choice);
                foreach (var item in lstQuestions)
                {
                    //item.ContentWithoutImage = RtfHelpers.ConvertRtfToText(item.Content);
                    item.Content = RtfHelpers.ConvertTextToRtf(item.Content);
                }
                EntitiesCollection = lstQuestions;
            }
            else
            {
                EntitiesCollection = new List<Question>();
            }
        }


        public override void LoadSecurityStatus()
        {
            if (m_cbxSubjects.SelectedItem != null)
            {
                var subject = m_cbxSubjects.SelectedItem.DataBoundItem as Subject;
                if (subject != null)
                {
                    bool isAddmin = UserService.CurrentUser.HasRole(UserRole.Administrator);
                    CanCreate = isAddmin || UserService.CurrentUser.HasRight(subject.SubjectId, RightType.Create);
                    CanDelete = isAddmin || UserService.CurrentUser.HasRight(subject.SubjectId, RightType.Delete);
                    CanEdit = isAddmin || UserService.CurrentUser.HasRight(subject.SubjectId, RightType.Edit);
                    m_txtContent.ReadOnly = !(CanCreate || CanEdit);
                    m_cbxQuestionLevels.Enabled = (CanCreate || CanEdit);
                    m_cbxPurposes.Enabled = (CanCreate || CanEdit);
                    m_spinTime.Enabled = (CanCreate || CanEdit);
                    NotifyStateChanged();
                }
            }
        }

        public override void Save()
        {
            if (string.IsNullOrEmpty(m_txtAnswerA.Text.Trim())
                || string.IsNullOrEmpty(m_txtAnswerB.Text.Trim())
                || string.IsNullOrEmpty(m_txtAnswerC.Text.Trim())
                || string.IsNullOrEmpty(m_txtAnswerD.Text.Trim())
                )
            {
                RadMessageBox.Show("Xin vui lòng nhập đầy đủ tất cả các câu trả lời!", "Lỗi", MessageBoxButtons.OK,
                                   RadMessageIcon.Error);
                return;
            }
            foreach (Question question in EntitiesCollection.Where(q => q.IsAddNew || q.HasChanged))
            {
                //foreach (Answer answer in question.Answers)
                //{
                //    string[] content = answer.Content.Split(' ');
                //    int a = content.Where(c => c.Trim().Equals("a", StringComparison.OrdinalIgnoreCase)).Count();
                //    int b = content.Where(c => c.Trim().Equals("b", StringComparison.OrdinalIgnoreCase)).Count();
                //    int c1 = content.Where(c => c.Trim().Equals("c", StringComparison.OrdinalIgnoreCase)).Count();
                //    if (a + b + c1 > 1)
                //    {
                //        question.IsAnswerRandom = false;
                //    }
                //}
                question.IsAnswerRandom = chkRandomAnswer.Checked;
            }
            base.Save();
        }

        public bool IsBinding { get; set; }

        private void m_btnImport_Click(object sender, EventArgs e)
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
            fileDialog.Filter = "Xml(*.xml)| *.xml";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportHelpers.ExportQuestion(fileDialog.FileName, EntitiesCollection);
            }
        }

        private void m_btnExport_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    IList<Subject> importedSubjects = ExportHelpers.ImportQuestion(dialog.FileName);
                    List<Guid> questionGuids = new List<Guid>();
                    foreach (var subject in importedSubjects)
                    {
                        questionGuids.AddRange(subject.Questions.Select(x => x.QuestionGuid));
                    }
                    var existedQuestionGuids = Service.GetExitsQuestionGuids(questionGuids);

                    //Remove all question from imported if it is existed in database (other word: don't import if it is existed)
                    foreach (var subject in importedSubjects)
                    {
                        var questions = subject.Questions.Where(x => existedQuestionGuids.Contains(x.QuestionGuid)).ToList();
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
                                          addNewSubjects[0].Name), "Confirmation", MessageBoxButtons.YesNo) ==
                            DialogResult.Yes)
                        {
                            m_subjectService.SaveAll(addNewSubjects);
                        }
                    }

                    // Add all question in imported to existed subject
                    foreach (var subject in existingSubjects)
                    {
                        var imSubject = importedSubjects.FirstOrDefault(x => x.SubjectGuid == subject.SubjectGuid);
                        if (imSubject != null)
                        {
                            foreach (var q in imSubject.Questions)
                            {
                                subject.Questions.Add(q);
                            }
                        }
                    }
                    m_subjectService.SaveAll(existingSubjects);

                }
                catch (Exception)
                {
                    RadMessageBox.Show("Có lỗi trong quá trình nhập từ file!", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }

        private void m_txtContent_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    //Point point = new Point(e.X, e.Y);
                    if (m_txtContent.SelectionType == RichTextBoxSelectionTypes.Object && m_txtContent.SelectedRtf.IndexOf(@"\pict\wmetafile") != -1)
                    {
                        _contextMenu.MenuItems.Clear();
                        //_contextMenu.MenuItems.Add("Chỉnh sửa", _menuHandler);
                        return;
                    }
                    _contextMenu.MenuItems.Clear(); // error here
                    _contextMenu.MenuItems.Add("Thêm hình ảnh", _menuHandler); //error here
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void m_txtContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                DataFormats.Format df = DataFormats.GetFormat(DataFormats.Bitmap);
                StringCollection strcollect = Clipboard.GetFileDropList();
                if (strcollect.Count > 0)
                {
                    Image image = Image.FromFile(strcollect[0]);
                    Clipboard.Clear();
                    Clipboard.SetImage(image);
                    if (Clipboard.ContainsImage())
                    {
                        m_txtContent.Paste(df);
                        e.Handled = true;
                        Clipboard.Clear();
                    }
                }

            }
        }

        //private void m_txtContent_Enter(object sender, EventArgs e)
        //{
        //    AcceptButton = null;
        //}
    }
}
