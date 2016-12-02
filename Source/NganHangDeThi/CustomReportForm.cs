using System;
using System.Collections.Generic;
using Common;
using Controller.Services;
using Model;
using Model.POCO;
using NganHangReport;
using System.Linq;
using Telerik.Reporting;

namespace NganHangDeThi {
    public partial class CustomReportForm : Telerik.WinControls.UI.RadForm {
        private SchoolInfoService m_schoolInfoService;
        private MultiTestService m_testsService;
        private SubjectsService m_subjectService;
        private QuestionsService m_questionService;
        public CustomReportForm() {
            InitializeComponent();
            NganHangEntities context = new NganHangEntities();
            m_schoolInfoService = new SchoolInfoService();
            m_testsService = new MultiTestService(context);
            m_subjectService = new SubjectsService(context);
            m_questionService = new QuestionsService(context);
        }
        public CustomReportForm(int subjectId)
            : this() {
            rpCustomQuestionReport rp = new rpCustomQuestionReport();
            var school = m_schoolInfoService.GetSchoolInfo();
            var subject = m_subjectService.GetById(subjectId);
            var schoolName = school == null ? string.Empty : school.SchoolName;
            rp.SchoolName = schoolName;
            rp.TestName = subject.Name + " - Mã MH: " + subject.SubjectNo;
            rp.DataSource = GetQuestions(subjectId);

            InstanceReportSource instanceReportSource = new InstanceReportSource();
            instanceReportSource.ReportDocument = rp;
            reportViewer1.ReportSource = instanceReportSource;
            reportViewer1.RefreshReport();
        }
        private List<QuestionModel> GetQuestions(int subjectId) {
            int index = 1;
            return m_questionService.GetAllQuestionBySubject(subjectId, QuestionType.Custom)
                                    .Select(x => new QuestionModel() {
                                        Id = Convert.ToInt32(x.QuestionId),
                                        Content = (index++)+". " + x.Content
                                    }).ToList();
        }
    }
}
