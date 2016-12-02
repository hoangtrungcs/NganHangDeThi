using Common;
using Controller.Services;
using Model.POCO;
using NganHangDeThi.Form_Popup;
using NganHangDeThi.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace NganHangDeThi {

    public partial class frmSharingQuestion : BaseForm {

        private QuestionsService m_questionService;
        private SubjectsService m_subjectService;
        private BindingList<Subject> m_allSubject;
        private List<SubjectsMultiTest> m_selectedSubject;
        private List<Question> m_exportQuestions;

        public frmSharingQuestion() {
            InitializeComponent();

            m_questionService = new QuestionsService();
            m_subjectService = new SubjectsService();
            m_allSubject = new BindingList<Subject>();
            m_selectedSubject = new List<SubjectsMultiTest>();
            m_exportQuestions = new List<Question>();

            lstSelectedSubject.MultiSelect = false;
            lstAllSubject.DisplayMember = "SubjectNoName";
            lstAllSubject.DataSource = m_allSubject;

            // register control event handler
            btnNext.Click += btnNext_Click;
            btnPre.Click += btnPre_Click;
            //speTotalQuestion.ValueChanged += OnQuestionNoChanged;
            //speEasyQuestion.ValueChanged += OnQuestionNoChanged;
            //speNormalQuestion.ValueChanged += OnQuestionNoChanged;
            //speHardQuestion.ValueChanged += OnQuestionNoChanged;
            //speEasyQuestion1.ValueChanged += OnQuestionNoChanged;
            //speNormalQuestion1.ValueChanged += OnQuestionNoChanged;
            //speHardQuestion1.ValueChanged += OnQuestionNoChanged;

            radManual.Click += OnRadioButtonChanged;
            radAuto.Click += OnRadioButtonChanged;
            radRandom.Click += OnRadioButtonChanged;
            this.Load += OnLoad;
        }

        private void OnRadioButtonChanged(object sender, EventArgs e) {
            RadRadioButton radButton = sender as RadRadioButton;
            switch (radButton.Name) {
                case "radManual":
                    SharingManual();
                    break;
                case "radAuto":
                    SharingAuto();
                    break;
                case "radRandom":
                    SharingRandom();
                    break;
            }
        }

        private void OnLoad(object sender, EventArgs e) {
            DisableControl();
            foreach (Subject subject in m_subjectService.GetAllSubject()) {
                m_allSubject.Add(subject);
            }

            BindingSource bds = new BindingSource() { DataSource = m_selectedSubject };
            lstSelectedSubject.DataSource = bds;
            lstSelectedSubject.DisplayMember = "Subject.SubjectNoName";
            lstSelectedSubject.ValueMember = "Subject.SubjectId";

            ddlPurpose.DataSource = EnumHelpers.GetAllQuestionPurpose();
            ddlPurpose.DisplayMember = "DisplayText";
            ddlPurpose.ValueMember = "Value";

            speEasyQuestion.DataBindings.Add("Value", bds, "EasyNo");
            speNormalQuestion.DataBindings.Add("Value", bds, "NormalNo");
            speHardQuestion.DataBindings.Add("Value", bds, "HardNo");

            speEasyQuestion1.DataBindings.Add("Value", bds, "EasyNo1");
            speNormalQuestion1.DataBindings.Add("Value", bds, "NormalNo1");
            speHardQuestion1.DataBindings.Add("Value", bds, "HardNo1");

            //bds.CurrentItemChanged += bds_CurrentItemChanged;
        }

        void bds_CurrentItemChanged(object sender, EventArgs e) {
            BindingSource bds = sender as BindingSource;
            SubjectsMultiTest sm = bds.Current as SubjectsMultiTest;
            speTotalQuestion.Value = sm.EasyNo + sm.EasyNo1 + sm.NormalNo + sm.NormalNo1 + sm.HardNo + sm.HardNo1;
        }

        private void btnNext_Click(object sender, EventArgs e) {
            List<Subject> removes = new List<Subject>();
            foreach (var item in lstAllSubject.SelectedItems) {
                removes.Add(item.DataBoundItem as Subject);
            }
            foreach (Subject subject in removes) {
                m_allSubject.Remove(subject);
                SubjectsMultiTest sm = new SubjectsMultiTest();
                sm.Subject = subject;
                m_selectedSubject.Add(sm);
            }
            (lstSelectedSubject.DataSource as BindingSource).ResetBindings(true);
        }

        private void btnPre_Click(object sender, EventArgs e) {
            List<SubjectsMultiTest> removes = new List<SubjectsMultiTest>();
            foreach (var item in lstSelectedSubject.SelectedItems) {
                removes.Add(item.DataBoundItem as SubjectsMultiTest);
            }
            foreach (SubjectsMultiTest sm in removes) {
                m_selectedSubject.Remove(sm);
                m_allSubject.Add(sm.Subject);
            }
            (lstSelectedSubject.DataSource as BindingSource).ResetBindings(true);
        }

        private void OnQuestionNoChanged(object sender, EventArgs e) {
            RadSpinEditor spe = sender as RadSpinEditor;
            if (lstSelectedSubject.SelectedItem == null) {
                RadMessageBox.Show("Bạn chưa chọn môn học để chia sẻ");
                return;
            }
            SubjectsMultiTest subject = (lstSelectedSubject.SelectedItem.DataBoundItem as SubjectsMultiTest);
            int subjectId = subject.Subject.SubjectId;
            string subjectName = subject.Subject.Name;
            switch (spe.Name) {
                case "speTotalQuestion":
                    int totalNo = m_questionService.Count(subjectId, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (totalNo < spe.Value) {
                        RadMessageBox.Show(string.Format("Tổng số câu hỏi hiện có của môn {0} là {1}, nhỏ hơn số câu hỏi bạn vừa chọn.\n{2}", subjectName, totalNo,
                                           "chương trình sẽ tự động cập nhật lại số câu hỏi bạn chọn bằng với số câu hỏi hiện có trong csdl."),
                                           "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        spe.Value = totalNo;

                    }
                    break;
                case "speEasyQuestion":
                    int easyNo = m_questionService.GetAllQuestionBySubjectAndLevel(subjectId, (int)QuestionLevel.Easy, (int)QuestionType.Choice, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (easyNo < spe.Value) {
                        RadMessageBox.Show(string.Format("Số câu hỏi dễ hiện có của môn {0} la {1}, nhỏ hơn số câu hỏi dễ bạn vừa chọn.\n{2}", subjectName, easyNo,
                                           "chương trình sẽ tự động cập nhật lại số câu hỏi bạn chọn bằng với số câu hỏi hiện có trong csdl."),
                                           "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        spe.Value = easyNo;
                    }
                    break;
                case "speNormalQuestion":
                    int normalNo = m_questionService.GetAllQuestionBySubjectAndLevel(subjectId, (int)QuestionLevel.Normal, (int)QuestionType.Choice, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (normalNo < spe.Value) {
                        RadMessageBox.Show(string.Format("Số câu hỏi trung bình hiện có của môn {0} la {1}, nhỏ hơn số câu hỏi trung bình bạn vừa chọn.\n{2}", subjectName, normalNo,
                                           "chương trình sẽ tự động cập nhật lại số câu hỏi bạn chọn bằng với số câu hỏi hiện có trong csdl."),
                                           "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        spe.Value = normalNo;
                    }
                    break;
                case "speHardQuestion":
                    int hardNo = m_questionService.GetAllQuestionBySubjectAndLevel(subjectId, (int)QuestionLevel.Hard, (int)QuestionType.Choice, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (hardNo < spe.Value) {
                        RadMessageBox.Show(string.Format("Số câu hỏi khó hiện có của môn {0} la {1}, nhỏ hơn số câu hỏi khó bạn vừa chọn.\n{2}", subjectName, hardNo,
                                           "chương trình sẽ tự động cập nhật lại số câu hỏi bạn chọn bằng với số câu hỏi hiện có trong csdl."),
                                           "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        spe.Value = hardNo;
                    }
                    break;
                case "speEasyQuestion1":
                    int easyNo1 = m_questionService.GetAllQuestionBySubjectAndLevel(subjectId, (int)QuestionLevel.Easy, (int)QuestionType.Custom, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (easyNo1 < spe.Value) {
                        RadMessageBox.Show(string.Format("Số câu hỏi dễ hiện có của môn {0} la {1}, nhỏ hơn số câu hỏi dễ bạn vừa chọn.\n{2}", subjectName, easyNo1,
                                           "chương trình sẽ tự động cập nhật lại số câu hỏi bạn chọn bằng với số câu hỏi hiện có trong csdl."),
                                           "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        spe.Value = easyNo1;
                    }
                    break;
                case "speNormalQuestion1":
                    int normalNo1 = m_questionService.GetAllQuestionBySubjectAndLevel(subjectId, (int)QuestionLevel.Normal, (int)QuestionType.Custom, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (normalNo1 < spe.Value) {
                        RadMessageBox.Show(string.Format("Số câu hỏi trung bình hiện có của môn {0} la {1}, nhỏ hơn số câu hỏi trung bình bạn vừa chọn.\n{2}", subjectName, normalNo1,
                                           "chương trình sẽ tự động cập nhật lại số câu hỏi bạn chọn bằng với số câu hỏi hiện có trong csdl."),
                                           "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        spe.Value = normalNo1;
                    }
                    break;
                case "speHardQuestion1":
                    int hardNo1 = m_questionService.GetAllQuestionBySubjectAndLevel(subjectId, (int)QuestionLevel.Hard, (int)QuestionType.Custom, Convert.ToInt32(ddlPurpose.SelectedValue));
                    if (hardNo1 < spe.Value) {
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

        private void OnSharing(object sender, EventArgs e) {
            string saveFilePath = FileHelper.GetSaveFilePath();
            if (string.IsNullOrEmpty(saveFilePath)) {
                return;
            }
            if (lstSelectedSubject.SelectedItem == null) {
                RadMessageBox.Show("Xin vui lòng chọn môn học để xuất câu hỏi!", "Lỗi", MessageBoxButtons.OK,
                                   RadMessageIcon.Error);
                return;
            }
            //if ((lstSelectedSubject.SelectedItem.DataBoundItem as SubjectsMultiTest).Subject.Questions.Count == 0) {
            //    RadMessageBox.Show("Môn học hiện tại không có câu hỏi nào bạn không thể xuất ra file.\nXin vui lòng chọn môn học khác!", "Lỗi", MessageBoxButtons.OK,
            //                       RadMessageIcon.Error);
            //    return;
            //}
            
            if (radRandom.IsChecked) {
                if (m_selectedSubject.Count > 0) {
                    List<int> subjectIds = m_selectedSubject.Select(s => s.Subject.SubjectId).ToList();
                    if (speTotalQuestion.Value > m_questionService.Count(subjectIds, (ddlPurpose.SelectedItem.DataBoundItem as EnumDisplay).Value)) {
                        RadMessageBox.Show("Số câu hỏi hiện có không đủ để chia sẻ theo nhu cầu của bạn!", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                        return;
                    }
                    m_exportQuestions = m_questionService.GetRandomQuestion(subjectIds, (ddlPurpose.SelectedItem.DataBoundItem as EnumDisplay).Value, (int)speTotalQuestion.Value);
                } else {
                    RadMessageBox.Show("Vui lòng chọn môn học cần chia sẻ", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
                    return;
                }
            } else if (radAuto.IsChecked) {
                m_exportQuestions = new List<Question>();
                foreach (SubjectsMultiTest sm in m_selectedSubject) {
                    m_exportQuestions.AddRange(m_questionService.GetRandomQuestionForLevel(sm.Subject.SubjectId, 
                        QuestionLevel.Easy, (int)QuestionType.Choice, (ddlPurpose.SelectedItem.DataBoundItem as EnumDisplay).Value, sm.EasyNo));
                    m_exportQuestions.AddRange(m_questionService.GetRandomQuestionForLevel(sm.Subject.SubjectId,
                        QuestionLevel.Normal, (int)QuestionType.Choice, (ddlPurpose.SelectedItem.DataBoundItem as EnumDisplay).Value, sm.NormalNo));
                    m_exportQuestions.AddRange(m_questionService.GetRandomQuestionForLevel(sm.Subject.SubjectId,
                        QuestionLevel.Hard, (int)QuestionType.Choice, (ddlPurpose.SelectedItem.DataBoundItem as EnumDisplay).Value, sm.HardNo));
                    m_exportQuestions.AddRange(m_questionService.GetRandomQuestionForLevel(sm.Subject.SubjectId,
                        QuestionLevel.Easy, (int)QuestionType.Custom, (ddlPurpose.SelectedItem.DataBoundItem as EnumDisplay).Value, sm.EasyNo1));
                    m_exportQuestions.AddRange(m_questionService.GetRandomQuestionForLevel(sm.Subject.SubjectId,
                        QuestionLevel.Normal, (int)QuestionType.Custom, (ddlPurpose.SelectedItem.DataBoundItem as EnumDisplay).Value, sm.NormalNo1));
                    m_exportQuestions.AddRange(m_questionService.GetRandomQuestionForLevel(sm.Subject.SubjectId,
                        QuestionLevel.Hard, (int)QuestionType.Custom, (ddlPurpose.SelectedItem.DataBoundItem as EnumDisplay).Value, sm.HardNo1));
                }
            }
            if (m_exportQuestions.Count == 0)
            {
                RadMessageBox.Show("Không có câu hỏi nào được chọn để chia sẻ. Vui lòng chọn câu hỏi!", "Lỗi", MessageBoxButtons.OK,
                                   RadMessageIcon.Error);
                return;
            }
            try {
                ExportHelpers.ExportQuestion(saveFilePath, m_exportQuestions);
                string successMessage = string.Empty;
                var groups = m_exportQuestions.GroupBy(q => q.Subject);
                foreach (var group in groups) {
                    successMessage += string.Format("- Môn {0}: {1} câu.\n", group.Key.Name, group.Count());
                }
                RadMessageBox.Show(successMessage, "Thành công", MessageBoxButtons.OK);
            } catch {
                RadMessageBox.Show("Lỗi");
            }
        }

        private void SharingManual() {
            if (m_selectedSubject.Count > 0) {
                DisableControl();
                List<int> subjectIds = m_selectedSubject.Select(s => s.Subject.SubjectId).ToList();
                frmSelectQuestions selectQuestions = new frmSelectQuestions(m_questionService, subjectIds, (ddlPurpose.SelectedItem.DataBoundItem as EnumDisplay).Value, null);
                if (selectQuestions.ShowDialog() == DialogResult.OK) {
                    m_exportQuestions = selectQuestions.SelectedQuestions;
                    UpdateControl();
                }
            } else {
                RadMessageBox.Show("Vui lòng chọn một (hoặc nhiều) môn học để chia sẻ câu hỏi.", "Lỗi", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void SharingAuto() {
            EnableControl();
            speTotalQuestion.Enabled = false;
        }

        private void SharingRandom() {
            DisableControl();
            speTotalQuestion.Enabled = true;
        }

        private void DisableControl() {
            speTotalQuestion.Enabled = false;
            speEasyQuestion.Enabled = false;
            speEasyQuestion1.Enabled = false;
            speNormalQuestion.Enabled = false;
            speNormalQuestion1.Enabled = false;
            speHardQuestion.Enabled = false;
            speHardQuestion1.Enabled = false;
        }
        private void EnableControl() {
            speTotalQuestion.Enabled = true;
            speEasyQuestion.Enabled = true;
            speEasyQuestion1.Enabled = true;
            speNormalQuestion.Enabled = true;
            speNormalQuestion1.Enabled = true;
            speHardQuestion.Enabled = true;
            speHardQuestion1.Enabled = true;
        }

        private void UpdateControl() {
            speTotalQuestion.Value = m_exportQuestions.Count;
            speEasyQuestion.Value = m_exportQuestions.Count(q => q.Level == (int)QuestionLevel.Easy &&
                                                                 q.Type == (int)QuestionType.Choice);
            speNormalQuestion.Value = m_exportQuestions.Count(q => q.Level == (int)QuestionLevel.Normal &&
                                                                 q.Type == (int)QuestionType.Choice);
            speHardQuestion.Value = m_exportQuestions.Count(q => q.Level == (int)QuestionLevel.Hard &&
                                                                 q.Type == (int)QuestionType.Choice);
            speEasyQuestion1.Value = m_exportQuestions.Count(q => q.Level == (int)QuestionLevel.Easy &&
                                                                 q.Type == (int)QuestionType.Custom);
            speNormalQuestion1.Value = m_exportQuestions.Count(q => q.Level == (int)QuestionLevel.Normal &&
                                                                 q.Type == (int)QuestionType.Custom);
            speHardQuestion1.Value = m_exportQuestions.Count(q => q.Level == (int)QuestionLevel.Hard &&
                                                                 q.Type == (int)QuestionType.Custom);
        }
    }
}
