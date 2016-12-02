using Controller.Services;
using Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace NganHangDeThi.Form_Popup {
    public partial class frmSelectQuestions : RadForm {
        public List<Question> SelectedQuestions { get; set; }

        private QuestionsService m_questionsService;
        private int m_subjectId;
        private int m_type;
        private int m_purpose;

        public frmSelectQuestions(List<Question> selectedQuestions, QuestionsService questionsService,
                                   int subjectId, int type, int purpose) {
            InitializeComponent();
            m_subjectId = subjectId;
            m_type = type;
            m_purpose = purpose;
            // Add header checkbox column
            CustomCheckBoxColumn column = new CustomCheckBoxColumn();
            column.FieldName = "Checked";
            column.Name = "colChecked";
            column.HeaderText = "All";
            grvQuestions.Columns.Insert(0, column);
            m_questionsService = questionsService;
            // Refresh selected questions on gridview
            SelectedQuestions = selectedQuestions;

            List<Question> allQuestions = m_questionsService.GetQuestionsBySubjectAndPurpose(m_subjectId, m_type, m_purpose);
            if (SelectedQuestions != null) {
                foreach (Question question in SelectedQuestions) {
                    allQuestions.First(s => s.QuestionId == question.QuestionId).Checked = true;
                }
            }
            grvQuestions.DataSource = allQuestions;
        }

        public frmSelectQuestions(QuestionsService questionsService, List<int> subjectIds, int purpose) {
            InitializeComponent();
            m_purpose = purpose;
            // Add header checkbox column
            CustomCheckBoxColumn column = new CustomCheckBoxColumn();
            column.FieldName = "Checked";
            column.Name = "colChecked";
            column.HeaderText = "All";
            grvQuestions.Columns.Insert(0, column);
            m_questionsService = questionsService;

            List<Question> allQuestions = m_questionsService.GetQuestionsBySubjectsAndPurpose(subjectIds, m_purpose);
            grvQuestions.DataSource = allQuestions;
        }

        public frmSelectQuestions(QuestionsService questionsService, List<int> subjectIds, int purpose, object missing) {
            InitializeComponent();
            m_purpose = purpose;
            // Add header checkbox column
            CustomCheckBoxColumn column = new CustomCheckBoxColumn();
            column.FieldName = "Checked";
            column.Name = "colChecked";
            column.HeaderText = "All";
            grvQuestions.Columns.Insert(0, column);
            m_questionsService = questionsService;

            List<Question> allQuestions = m_questionsService.GetMixedQuestionsBySubjectsAndPurpose(subjectIds, m_purpose);
            grvQuestions.DataSource = allQuestions;
        }

        private void OnAccept(object sender, EventArgs e) {
            SelectedQuestions = (grvQuestions.DataSource as List<Question>).Where(s => s.Checked).ToList();
            DialogResult = DialogResult.OK;
        }

        private void OnCancel(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OnLoad(object sender, EventArgs e) {
            
        }                
    }

    public class CustomQuestionCheckBoxColumn : GridViewCheckBoxColumn {
        public override Type GetCellType(GridViewRowInfo row) {
            if (row is GridViewTableHeaderRowInfo) {
                return typeof(CheckBoxHeaderCell);
            }
            return base.GetCellType(row);
        }
    }
}
