using Controller.Services;
using Model;
using Model.POCO;
using NganHangReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Telerik.Reporting;
using Telerik.WinControls.UI;

namespace NganHangDeThi {
    public partial class frmMultiTestReport : RadForm {
        private SchoolInfoService m_schoolInfoService;
        private MultiTestService m_testsService;
        private SubjectsService m_subjectService;
        private QuestionsService m_questionService;
        private List<Answer> AllAnswerList;

        private Random m_random;

        public frmMultiTestReport() {
            InitializeComponent();
            NganHangEntities context = new NganHangEntities();
            m_schoolInfoService = new SchoolInfoService();
            m_testsService = new MultiTestService(context);
            m_subjectService = new SubjectsService(context);
            m_questionService = new QuestionsService(context);
            m_random = new Random();
            AllAnswerList = new List<Answer>();
            AllAnswerList = m_questionService.GetAllAnswer();
        }

        public frmMultiTestReport(int testCopyId, int no)
            : this() {
            rpMultiTestQuestion rp = new rpMultiTestQuestion();
            var school = m_schoolInfoService.GetSchoolInfo();
            MultiTestCopy testCopy = m_testsService.GetMultiTestCopyById(testCopyId);
            MultiTest test = m_testsService.GetMultiTestById(testCopy.FK_MultiTestId);
            var schoolName = school == null ? string.Empty : school.SchoolName;
            rp.TestName = string.Format("{0} - Đề số: 0{1}", test.MultiTestName, no);
            rp.TestDate = test.MultiTestDate.ToString("dd/MM/yyyy");
            rp.TestTime = string.Format("{0} phút", test.Time);
            var multiTestDetails = GetTestDetails(testCopyId);

            if (test.LopHoc != null)
                rp.ClassName = string.Format("{0}{1}", "LỚP: ", test.LopHoc.ClassName);

            if (multiTestDetails.FirstOrDefault(x => x.Content.Contains(@"{\rtf1")) != null)
            {

                int i = 1;
                foreach (var questionModel in multiTestDetails)
                {
                    var rtfToText =
                        Common.RtfHelpers.ConvertRtfToText(
                            questionModel.Content.Replace(i.ToString() + ".", "").Trim());
                    questionModel.Content = i.ToString() + ". " + rtfToText;
                    i++;
                }
            }
            rp.DataSource = multiTestDetails;

            InstanceReportSource instanceReportSource = new InstanceReportSource();
            instanceReportSource.ReportDocument = rp;
            rpViewer.ReportSource = instanceReportSource;
            rpViewer.RefreshReport();
        }

        public frmMultiTestReport(int testCopyId, int no, object missing)
            : this() {
                rpMixedTestAnswer rp = new rpMixedTestAnswer();
            var school = m_schoolInfoService.GetSchoolInfo();
            MultiTestCopy testCopy = m_testsService.GetMultiTestCopyById(testCopyId);
            MultiTest test = m_testsService.GetMultiTestById(testCopy.FK_MultiTestId);
            var schoolName = school == null ? string.Empty : school.SchoolName;
            rp.SchoolName = schoolName;
            rp.TestName = string.Format("Đáp án {0} - Đề số: 0{1}", test.MultiTestName, no);
            rp.TestDate = test.MultiTestDate.ToString("dd/MM/yyyy");
            rp.TestTime = string.Format("{0} phút", test.Time);
            var multiTestDetails = GetTestAnswers(testCopyId);

            if (test.LopHoc != null)
                rp.ClassName = string.Format("{0}{1}", "LỚP: ", test.LopHoc.ClassName);

            if (multiTestDetails.FirstOrDefault(x => x.Content.Contains(@"{\rtf1")) != null)
            {

                int i = 1;
                foreach (var questionModel in multiTestDetails)
                {
                    var rtfToText =
                        Common.RtfHelpers.ConvertRtfToText(
                            questionModel.Content.Replace(i.ToString() + ".", "").Trim());
                    questionModel.Content = i.ToString() + ". " + rtfToText;
                    i++;
                }
            }
            rp.DataSource = multiTestDetails;

            InstanceReportSource instanceReportSource = new InstanceReportSource();
            instanceReportSource.ReportDocument = rp;
            rpViewer.ReportSource = instanceReportSource;
            rpViewer.RefreshReport();
        }

        public frmMultiTestReport(int testCopyId, int no, object missing, object missing1)
            : this() {
            rpMixedTestQuestion rp = new rpMixedTestQuestion();
            var school = m_schoolInfoService.GetSchoolInfo();
            MultiTestCopy testCopy = m_testsService.GetMultiTestCopyById(testCopyId);
            MultiTest test = m_testsService.GetMultiTestById(testCopy.FK_MultiTestId);
            var schoolName = school == null ? string.Empty : school.SchoolName;
            rp.TestName = string.Format("{0} - Đề số: 0{1}", test.MultiTestName, no);
            rp.TestDate = test.MultiTestDate.ToString("dd/MM/yyyy");
            rp.TestTime = string.Format("{0} phút", test.Time);
            var mixedTestDetails = GetMixedTestDetails(testCopyId);

            if (test.LopHoc != null)
                rp.ClassName = string.Format("{0}{1}", "LỚP: ", test.LopHoc.ClassName);

            if (mixedTestDetails.FirstOrDefault(x => x.Content.Contains(@"{\rtf1")) != null)
            {

                int i = 1;
                foreach (var questionModel in mixedTestDetails)
                {
                    var rtfToText =
                        Common.RtfHelpers.ConvertRtfToText(
                            questionModel.Content.Replace(i.ToString() + ".", "").Trim());
                    questionModel.Content = i.ToString() + ". " + rtfToText;
                    i++;
                }
            }
            rp.DataSource = mixedTestDetails;

            InstanceReportSource instanceReportSource = new InstanceReportSource();
            instanceReportSource.ReportDocument = rp;
            rpViewer.ReportSource = instanceReportSource;
            rpViewer.RefreshReport();
        }

        private List<QuestionModel> GetTestDetails(int testCopyId) {
            MultiTestCopy multiTestCopy = m_testsService.GetMultiTestCopyById(testCopyId);
            MultiTest multiTest = m_testsService.GetMultiTestById(multiTestCopy.FK_MultiTestId);
            List<QuestionModel> questions = new List<QuestionModel>();

            XDocument multiTestCopyDocument = XDocument.Load(new StringReader(multiTestCopy.MultiTestCopyStructure));
            // Question list
            IEnumerable<XElement> questionElements = multiTestCopyDocument.Descendants("Q");
            foreach (MultiTestQuestion multiTestQuestion in multiTest.MultiTestQuestions) {
                XElement questionElement = questionElements.Where(q => Convert.ToInt64(q.Attribute("qId").Value)
                                                                    == multiTestQuestion.FK_QuestionId).FirstOrDefault();
                QuestionModel question = new QuestionModel();
                if (questionElement != null) {
                    question.Id = Convert.ToInt32(questionElement.Attribute("qOrder").Value);
                    question.Content = string.Format("{0}. {1}", question.Id, multiTestQuestion.Question.Content);
                    IEnumerable<XElement> answerElements = questionElement.Elements("A");
                    question.Answer1 = string.Format("A. {0}", AllAnswerList.Where(a => a.AnswerId ==
                                                                                        Convert.ToInt64(answerElements
                                                                                                        .ElementAt(0)
                                                                                                        .Attribute("aId")
                                                                                                        .Value))
                                                                            .FirstOrDefault().Content);
                    question.Answer2 = string.Format("B. {0}", AllAnswerList.Where(a => a.AnswerId ==
                                                                                        Convert.ToInt64(answerElements
                                                                                                        .ElementAt(1)
                                                                                                        .Attribute("aId")
                                                                                                        .Value))
                                                                            .FirstOrDefault().Content);
                    question.Answer3 = string.Format("C. {0}", AllAnswerList.Where(a => a.AnswerId ==
                                                                                        Convert.ToInt64(answerElements
                                                                                                        .ElementAt(2)
                                                                                                        .Attribute("aId")
                                                                                                        .Value))
                                                                            .FirstOrDefault().Content);
                    question.Answer4 = string.Format("D. {0}", AllAnswerList.Where(a => a.AnswerId ==
                                                                                        Convert.ToInt64(answerElements
                                                                                                        .ElementAt(3)
                                                                                                        .Attribute("aId")
                                                                                                        .Value))
                                                                            .FirstOrDefault().Content);
                    questions.Add(question);
                } else {
                    //question.Id = questions.Count + 1;
                    //question.Content = string.Format("{0}. {1}", question.Id, multiTestQuestion.Question.Content);
                }

                
            }

            return questions.OrderBy(x => x.Id).ToList();
        }

        private List<QuestionMixedModel> GetMixedTestDetails(int testCopyId) {
            MultiTestCopy multiTestCopy = m_testsService.GetMultiTestCopyById(testCopyId);
            MultiTest multiTest = m_testsService.GetMultiTestById(multiTestCopy.FK_MultiTestId);
            List<QuestionMixedModel> questions = new List<QuestionMixedModel>();

            XDocument multiTestCopyDocument = XDocument.Load(new StringReader(multiTestCopy.MultiTestCopyStructure));
            // Question list
            IEnumerable<XElement> questionElements = multiTestCopyDocument.Descendants("Q");
            int cusNo = 1;
            foreach (MultiTestQuestion multiTestQuestion in multiTest.MultiTestQuestions) {
                XElement questionElement = questionElements.Where(q => Convert.ToInt64(q.Attribute("qId").Value)
                                                                    == multiTestQuestion.FK_QuestionId).FirstOrDefault();
                QuestionMixedModel question = new QuestionMixedModel();
                if (questionElement != null) {
                    question.Id = Convert.ToInt32(questionElement.Attribute("qOrder").Value);
                    question.Content = string.Format("{0}. {1}", question.Id, multiTestQuestion.Question.Content);
                    IEnumerable<XElement> answerElements = questionElement.Elements("A");
                    question.Answer1 = string.Format("A. {0}", AllAnswerList.Where(a => a.AnswerId ==
                                                                                        Convert.ToInt64(answerElements
                                                                                                        .ElementAt(0)
                                                                                                        .Attribute("aId")
                                                                                                        .Value))
                                                                            .FirstOrDefault().Content);
                    question.Answer2 = string.Format("B. {0}", AllAnswerList.Where(a => a.AnswerId ==
                                                                                        Convert.ToInt64(answerElements
                                                                                                        .ElementAt(1)
                                                                                                        .Attribute("aId")
                                                                                                        .Value))
                                                                            .FirstOrDefault().Content);
                    question.Answer3 = string.Format("C. {0}", AllAnswerList.Where(a => a.AnswerId ==
                                                                                        Convert.ToInt64(answerElements
                                                                                                        .ElementAt(2)
                                                                                                        .Attribute("aId")
                                                                                                        .Value))
                                                                            .FirstOrDefault().Content);
                    question.Answer4 = string.Format("D. {0}", AllAnswerList.Where(a => a.AnswerId ==
                                                                                        Convert.ToInt64(answerElements
                                                                                                        .ElementAt(3)
                                                                                                        .Attribute("aId")
                                                                                                        .Value))
                                                                            .FirstOrDefault().Content);
                    question.GroupName = "A. Trắc nghiệm";
                } else {
                    question.Id = questions.Count + 1;
                    question.Content = string.Format("{0}. {1}", cusNo++, multiTestQuestion.Question.Content);
                    question.GroupName = "B. Tự luận";
                }

                questions.Add(question);
            }

            return questions.OrderBy(x => x.GroupName).OrderBy(x => x.Id).ToList();
        }

        private List<QuestionMixedModel> GetTestAnswers(int testCopyId) {

            MultiTestCopy multiTestCopy = m_testsService.GetMultiTestCopyById(testCopyId);
            MultiTest multiTest = m_testsService.GetMultiTestById(multiTestCopy.FK_MultiTestId);
            List<QuestionMixedModel> questions = new List<QuestionMixedModel>();

            XDocument multiTestCopyDocument = XDocument.Load(new StringReader(multiTestCopy.MultiTestCopyStructure));
            // Question list
            IEnumerable<XElement> questionElements = multiTestCopyDocument.Descendants("Q");
            int cusNo = 1;
            foreach (MultiTestQuestion multiTestQuestion in multiTest.MultiTestQuestions) {
                XElement questionElement = questionElements.Where(q => Convert.ToInt64(q.Attribute("qId").Value)
                                                                    == multiTestQuestion.FK_QuestionId).FirstOrDefault();
                QuestionMixedModel question = new QuestionMixedModel();
                if (questionElement != null) {
                    
                    question.Id = Convert.ToInt32(questionElement.Attribute("qOrder").Value);
                    question.Content = string.Format("{0}. {1}", question.Id, multiTestQuestion.Question.Content);
                    long questionId = Convert.ToInt64(questionElement.Attribute("qId").Value);
                    Answer answer =
                        AllAnswerList.Where(a => a.FK_QuestionId == questionId && a.IsAnswer == true).FirstOrDefault();
                    int order = Convert.ToInt32(questionElement.Elements("A")
                                                               .Where(
                                                                   ao =>
                                                                   Convert.ToInt64(ao.Attribute("aId").Value) ==
                                                                   answer.AnswerId)
                                                               .FirstOrDefault()
                                                               .Attribute("aOrder")
                                                               .Value);
                    string answerOrder = order == 1 ? "A" : (order == 2 ? "C" : (order == 3 ? "C" : "D"));
                    question.Answer1 = answer != null
                                           ? string.Format("Đáp án: {0}. {1}", answerOrder, answer.Content)
                                           : "Đáp án: ";
                    question.GroupName = "A. Trắc Nghiệm";
                   
                } else {
                    question.Id = questions.Count + 1;
                    question.Content = string.Format("{0}. {1}", cusNo++, multiTestQuestion.Question.Content);
                    question.Answer1 = multiTestQuestion.Question.AnswerA.Content;
                    question.GroupName = "B. Tự luận";
                }
                questions.Add(question);
            }
            return questions.OrderBy(x => x.GroupName).OrderBy(x => x.Id).ToList();
        }
    }
}
