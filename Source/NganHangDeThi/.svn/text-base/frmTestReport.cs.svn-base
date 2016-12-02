using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Common;
using Controller.Services;
using Microsoft.Office.Interop.Word;
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
using TextBox = System.Windows.Forms.TextBox;

namespace NganHangDeThi
{
    public partial class frmTestReport : RadForm
    {
        private SchoolInfoService m_schoolInfoService;
        private TestsService m_testsService;
        private SubjectsService m_subjectService;
        private QuestionModelService _questionModelService;
        RichTextBox rtbMerged = new RichTextBox();
        RichTextBox richTextBox1 = new RichTextBox();
        public bool IsShow { get; set; }
        //private QuestionsService m_questionService;
        //private List<Answer> AllAnswerList;

        private Random m_random;

        public frmTestReport()
        {
            InitializeComponent();
            IsShow = true;
            NganHangEntities context = new NganHangEntities();
            m_schoolInfoService = new SchoolInfoService();
            m_testsService = new TestsService(context);
            m_subjectService = new SubjectsService(context);
            //m_questionService = new QuestionsService(context);
            m_random = new Random();
            //AllAnswerList = new List<Answer>();
            //AllAnswerList = m_questionService.GetAllAnswer();

            _questionModelService = new QuestionModelService(context);
        }

        public frmTestReport(int testCopyId, int no)
            : this()
        {
            IsShow = true;
            rpTestQuestion rp = new rpTestQuestion();
            var school = m_schoolInfoService.GetSchoolInfo();
            TestCopy testCopy = m_testsService.GetTestCopy(testCopyId);
            Test test = m_testsService.GetTestById(testCopy.FK_TestId);
            var schoolName = school == null ? string.Empty : school.SchoolName;
            rp.SubjectName = m_subjectService.GetById(test.FK_SubjectId) != null ?
                                m_subjectService.GetById(test.FK_SubjectId).Name.ToUpper() : string.Empty;
            rp.SubjectHeader += rp.SubjectName;
            var subjectTestName = test.Name;
            rp.TestName = string.Format("ĐỀ SỐ 0{0}", no);
            rp.TestDate = test.TestDate.ToString("dd/MM/yyyy");
            rp.TestTime = string.Format("{0} phút", test.Time);
            if (test.LopHoc != null)
                rp.ClassName = string.Format("{0}{1}", "LỚP: ", test.LopHoc.ClassName);

            var testDetails = _questionModelService.GetTestDetails(testCopyId);


            //TODO: Check is rtf
            if (testDetails.FirstOrDefault(x => x.Content.Contains(@"{\rtf1") && x.Content.Contains(@"\pict\wmetafile")) != null)
            {

                LoadReportWithImage(testCopyId, no, school, rp.SubjectName, rp.TestName, rp.TestDate, rp.TestTime, subjectTestName, rp.ClassName);
                IsShow = false;
            }
            else
            {
                if (testDetails.FirstOrDefault(x => x.Content.Contains(@"{\rtf1")) != null)
                {

                    int i = 1;
                    foreach (var questionModel in testDetails)
                    {
                        var rtfToText =
                            Common.RtfHelpers.ConvertRtfToText(
                                questionModel.Content.Replace(i.ToString() + ".", "").Trim());
                        questionModel.Content = i.ToString() + ". " + rtfToText;
                        i++;
                    }
                }
                rp.DataSource = testDetails;
                var instanceReportSource = new InstanceReportSource();
                instanceReportSource.ReportDocument = rp;
                rpViewer.ReportSource = instanceReportSource;
                rpViewer.RefreshReport();
            }
        }

        public string Merge(string s1, string answer1, string answer2, string answer3, string answer4, string s2, int count)
        {
            const string tab = "\t ";
            rtbMerged.SelectionFont = new System.Drawing.Font("Arial", 10);

            rtbMerged.AppendText(count.ToString() + ". ");
            RichTextBox rtbTemp = new RichTextBox();
            if (s1.Contains(@"\rtf1"))
                rtbTemp.Rtf = s1;
            else
                rtbTemp.Text = s1;

            rtbTemp.AppendText(Environment.NewLine);
            rtbTemp.AppendText(tab + answer1);
            rtbTemp.AppendText(Environment.NewLine);
            rtbTemp.AppendText(tab + answer2);
            rtbTemp.AppendText(Environment.NewLine);
            rtbTemp.AppendText(tab + answer3);
            rtbTemp.AppendText(Environment.NewLine);
            rtbTemp.AppendText(tab + answer4);

            rtbTemp.SelectAll();
            rtbTemp.Cut();
            rtbMerged.Paste();

            rtbMerged.AppendText(Environment.NewLine);
            rtbMerged.AppendText(Environment.NewLine);

            //rtbTemp.Rtf = s2;
            //rtbTemp.SelectAll();
            //rtbTemp.Cut();
            //rtbMerged.Paste();

            return rtbMerged.Rtf;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetOpenClipboardWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int GetWindowText(int hwnd, StringBuilder text, int count);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetWindowTextLength(int hwnd);

        private static string GetOpenClipboardWindowText()
        {
            var hwnd = GetOpenClipboardWindow();
            if (hwnd == IntPtr.Zero)
            {
                return "Unknown";
            }
            var int32Handle = hwnd.ToInt32();
            var len = GetWindowTextLength(int32Handle);
            var sb = new StringBuilder(len);
            GetWindowText(int32Handle, sb, len);
            return sb.ToString();
        }

        private void LoadReportWithImage(int testCopyId, int no, SchoolInfo school, string subjectName, string testName, string testDate, string testTime, string subjectTestName, string className)
        {
            try
            {
                const string testNameField = "«TESTNAME»";
                const string subjectField = "«SUBJECT»";
                const string classNameField = "«CLASSNAME»";
                const string testDateField = "«testDate»";
                const string testTimeField = "«testTime»";

                var testDetails = _questionModelService.GetTestDetails(testCopyId);

                //clear rtbMerged before add text 
                rtbMerged.Clear();

                int i = 1;
                foreach (var questionModel in testDetails)
                {
                    if (questionModel.Content.Contains(i.ToString() + "."))
                    {
                        richTextBox1.AppendText(i.ToString() + ".");
                        var content = questionModel.Content.Replace(i.ToString() + ".", "").Trim();
                        var answer1 = questionModel.Answer1;
                        var answer2 = questionModel.Answer2;
                        var answer3 = questionModel.Answer3;
                        var answer4 = questionModel.Answer4;

                        Merge(content, answer1, answer2, answer3, answer4, richTextBox1.Rtf, i);
                        i++;
                    }

                }
                richTextBox1.Rtf = rtbMerged.Rtf;

                //change font to arial and font size from 8.5 to 10
                richTextBox1.Rtf = richTextBox1.Rtf.Replace("Microsoft Sans Serif", "Arial").Replace("fs17", "fs20");

                richTextBox1.SelectAll();

                // string p = GetOpenClipboardWindowText();

                Clipboard.Clear();
                Clipboard.SetText(richTextBox1.SelectedRtf, TextDataFormat.Rtf);

                var wordApp = new Microsoft.Office.Interop.Word.Application();

                object filename = string.Format(@"{0}", Environment.CurrentDirectory + "\\" +
                                  ConfigurationManager.AppSettings["ReportTemplate"]);
                object newFileName = string.Format(@"{0}", Environment.CurrentDirectory + "\\Reports\\" + subjectName.Replace(" ", "_") + "_" +
                                     subjectTestName.Replace(" ", "_") + "_" + testName.Replace(" ", "_") + ".doc");

                object missing = Type.Missing;
                Document doc = wordApp.Documents.Add(filename);

                //Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref filename, ref missing, ref missing, ref missing, ref missing,
                //    ref missing, ref missing, ref missing, ref missing, ref missing,
                //    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                var sel = wordApp.Selection;
                object end = doc.Content.End;
                object start = (int)end - 11;
                doc.Range(ref start, ref end).Select();
                sel.Paste();

                var range = doc.Range();

                range.Find.Execute(FindText: classNameField, Replace: WdReplace.wdReplaceAll, ReplaceWith: className);
                range.Find.Execute(FindText: subjectField, Replace: WdReplace.wdReplaceAll, ReplaceWith: subjectName);
                range.Find.Execute(FindText: testNameField, Replace: WdReplace.wdReplaceAll, ReplaceWith: testName);
                range.Find.Execute(FindText: testDateField, Replace: WdReplace.wdReplaceAll, ReplaceWith: testDate);
                range.Find.Execute(FindText: testTimeField, Replace: WdReplace.wdReplaceAll, ReplaceWith: testTime);

                //doc.SaveAs(ref newFileName,
                //           ref missing, ref missing, ref missing, ref missing, ref missing,
                //           ref missing, ref missing, ref missing, ref missing, ref missing,
                //           ref missing, ref missing, ref missing, ref missing, ref missing);
                doc.SaveAs2000(newFileName);

                object doNotSaveChanges = WdSaveOptions.wdDoNotSaveChanges;
                doc.Close(ref doNotSaveChanges, ref missing, ref missing);
                wordApp.Quit(); //This is used to quit the Word application.
                GC.Collect(); //T
                GC.WaitForPendingFinalizers();

                Common.Logs.WriteLog(newFileName.ToString());
                string a = string.Format("'{0}'", newFileName.ToString());

                string nn = "\"" + newFileName.ToString() + "\"";

                Process.Start("WINWORD.EXE", nn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + " _ " + ex.InnerException);
            }
            //finally
            //{
            //    // Release all Interop objects.
            //    if (doc != null)
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
            //    if (wordApp != null)
            //        System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            //    doc = null;
            //    wordApp = null;
            //    GC.Collect();
            //}

        }

        public frmTestReport(int testCopyId, int no, object missing)
            : this()
        {
            rpTestAnswer rp = new rpTestAnswer();
            var school = m_schoolInfoService.GetSchoolInfo();
            TestCopy testCopy = m_testsService.GetTestCopy(testCopyId);
            Test test = m_testsService.GetTestById(testCopy.FK_TestId);
            var schoolName = school == null ? string.Empty : school.SchoolName;
            rp.SchoolName = schoolName;
            rp.AnswerName = string.Format("Đáp án {0} - Đề số: 0{1}", test.Name, no);
            rp.TestDate = test.TestDate.ToString("dd/MM/yyyy");
            rp.TestTime = string.Format("{0} phút", test.Time);
            var listQuestionMode = _questionModelService.GetTestAnswers(testCopyId);

            if (test.LopHoc != null)
                rp.ClassName = string.Format("{0}{1}", "LỚP: ", test.LopHoc.ClassName);
            //Convert rtf to text for answer report 


            int i = 1;
            foreach (QuestionModel itemModel in listQuestionMode)
            {
                if (itemModel.Content.StartsWith(i.ToString() + "."))
                {
                    var rtfToText = Common.RtfHelpers.ConvertRtfToText(itemModel.Content.Replace(i.ToString() + ".", "").Trim());
                    itemModel.Content = i.ToString() + ". " + rtfToText;
                }

                i++;
            }
            rp.DataSource = listQuestionMode;

            InstanceReportSource instanceReportSource = new InstanceReportSource();
            instanceReportSource.ReportDocument = rp;
            rpViewer.ReportSource = instanceReportSource;
            rpViewer.RefreshReport();
        }

        //25/5/2014 : MOVE TO QUESTIONMODELSERVICE
        //private List<QuestionModel> GetTestDetails(int testCopyId) {
        //    TestCopy testCopy = m_testsService.GetTestCopy(testCopyId);
        //    Test test = m_testsService.GetTestById(testCopy.FK_TestId);
        //    List<QuestionModel> questions = new List<QuestionModel>();

        //    XDocument testCopyDocument = XDocument.Load(new StringReader(testCopy.TestCopyStructure));
        //    // Question list
        //    IEnumerable<XElement> questionElements = testCopyDocument.Descendants("Q");
        //    foreach (TestQuestion testQuestion in test.TestQuestions) {
        //        XElement questionElement = questionElements.Where(q => Convert.ToInt64(q.Attribute("qId").Value)
        //                                                            == testQuestion.QuestionId).FirstOrDefault();
        //        QuestionModel question = new QuestionModel();
        //        question.Id = Convert.ToInt32(questionElement.Attribute("qOrder").Value);
        //        question.Content = string.Format("{0}. {1}", question.Id, testQuestion.Question.Content);
        //        IEnumerable<XElement> answerElements = questionElement.Elements("A");
        //        question.Answer1 = string.Format("A. {0}", AllAnswerList.Where(a => a.AnswerId ==
        //                                                                            Convert.ToInt64(answerElements
        //                                                                                            .ElementAt(0)
        //                                                                                            .Attribute("aId")
        //                                                                                            .Value))
        //                                                                .FirstOrDefault().Content);
        //        question.Answer2 = string.Format("B. {0}", AllAnswerList.Where(a => a.AnswerId ==
        //                                                                            Convert.ToInt64(answerElements
        //                                                                                            .ElementAt(1)
        //                                                                                            .Attribute("aId")
        //                                                                                            .Value))
        //                                                                .FirstOrDefault().Content);
        //        question.Answer3 = string.Format("C. {0}", AllAnswerList.Where(a => a.AnswerId ==
        //                                                                            Convert.ToInt64(answerElements
        //                                                                                            .ElementAt(2)
        //                                                                                            .Attribute("aId")
        //                                                                                            .Value))
        //                                                                .FirstOrDefault().Content);
        //        question.Answer4 = string.Format("D. {0}", AllAnswerList.Where(a => a.AnswerId ==
        //                                                                            Convert.ToInt64(answerElements
        //                                                                                            .ElementAt(3)
        //                                                                                            .Attribute("aId")
        //                                                                                            .Value))
        //                                                                .FirstOrDefault().Content);
        //        questions.Add(question);
        //    }

        //    return questions.OrderBy(x => x.Id).ToList();
        //}

        //private List<QuestionModel> GetTestAnswers(int testCopyId) {

        //    TestCopy testCopy = m_testsService.GetTestCopy(testCopyId);
        //    Test test = m_testsService.GetTestById(testCopy.FK_TestId);
        //    List<QuestionModel> questions = new List<QuestionModel>();

        //    XDocument multiTestCopyDocument = XDocument.Load(new StringReader(testCopy.TestCopyStructure));
        //    // Question list
        //    IEnumerable<XElement> questionElements = multiTestCopyDocument.Descendants("Q");
        //    foreach (TestQuestion testQuestion in test.TestQuestions) {
        //        XElement questionElement = questionElements.Where(q => Convert.ToInt64(q.Attribute("qId").Value)
        //                                                            == testQuestion.QuestionId).FirstOrDefault();
        //        QuestionModel question = new QuestionModel();
        //        question.Id = Convert.ToInt32(questionElement.Attribute("qOrder").Value);
        //        question.Content = string.Format("{0}. {1}", question.Id, testQuestion.Question.Content);
        //        long questionId = Convert.ToInt64(questionElement.Attribute("qId").Value);
        //        Answer answer = AllAnswerList.Where(a => a.FK_QuestionId == questionId && a.IsAnswer == true).FirstOrDefault();
        //        int order = Convert.ToInt32(questionElement.Elements("A")
        //                                            .Where(ao => Convert.ToInt64(ao.Attribute("aId").Value) == answer.AnswerId)
        //                                            .FirstOrDefault()
        //                                            .Attribute("aOrder")
        //                                            .Value);
        //        string answerOrder = order == 1 ? "A" : (order == 2 ? "B" : (order == 3 ? "C" : "D"));
        //        question.Answer1 = answer != null ? string.Format("Đáp án: {0}. {1}", answerOrder, answer.Content) : "Đáp án: ";
        //        questions.Add(question);
        //    }
        //    return questions.OrderBy(x => x.Id).ToList();
        //}
    }
}
