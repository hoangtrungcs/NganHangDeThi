using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Model;
using Model.POCO;

namespace Controller.Services
{
    public class QuestionModelService
    {
        private TestsService m_testsService=new TestsService();
        private QuestionsService m_questionService=new QuestionsService();
        private List<Answer> AllAnswerList=new List<Answer>();

        public QuestionModelService(DbContext context)
        {
            AllAnswerList = m_questionService.GetAllAnswer();
        }

        /// <summary>
        /// Gets the test details.
        /// </summary>
        /// <param name="testCopyId">The test copy id.</param>
        /// <returns></returns>
        public List<QuestionModel> GetTestDetails(int testCopyId)
        {
            TestCopy testCopy = m_testsService.GetTestCopy(testCopyId);
            Test test = m_testsService.GetTestById(testCopy.FK_TestId);
            List<QuestionModel> questions = new List<QuestionModel>();

            XDocument testCopyDocument = XDocument.Load(new StringReader(testCopy.TestCopyStructure));
            // Question list
            IEnumerable<XElement> questionElements = testCopyDocument.Descendants("Q");
            
            //Yeu cau moi:
            //Nhung bai testCopy trong 1 bai test ko duoc trung nhau
            //Neu trung thi random cau hoi va cau tra loi do.
            foreach (var questionElement in questionElements)
	        {
                TestQuestion testQuestion = test.TestQuestions.FirstOrDefault(x => x.QuestionId == Convert.ToInt64(questionElement.Attribute("qId").Value));
                                                            

                QuestionModel question = new QuestionModel();
                question.Id = Convert.ToInt32(questionElement.Attribute("qOrder").Value);
                question.Content = string.Format("{0}. {1}", question.Id, testQuestion.Question.Content);
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
	        }
          
            

            //foreach (TestQuestion testQuestion in test.TestQuestions)
            //{
            //    XElement questionElement = questionElements.Where(q => Convert.ToInt64(q.Attribute("qId").Value)
            //                                                        == testQuestion.QuestionId).FirstOrDefault();
            //    if (questionElement != null)
            //    {
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
            //}
            return questions.OrderBy(x => x.Id).ToList();
        }

        /// <summary>
        /// Gets the test answers.
        /// </summary>
        /// <param name="testCopyId">The test copy id.</param>
        /// <returns></returns>
        public List<QuestionModel> GetTestAnswers(int testCopyId)
        {

            TestCopy testCopy = m_testsService.GetTestCopy(testCopyId);
            Test test = m_testsService.GetTestById(testCopy.FK_TestId);
            List<QuestionModel> questions = new List<QuestionModel>();

            XDocument multiTestCopyDocument = XDocument.Load(new StringReader(testCopy.TestCopyStructure));
            // Question list
            IEnumerable<XElement> questionElements = multiTestCopyDocument.Descendants("Q");
            foreach (TestQuestion testQuestion in test.TestQuestions)
            {
                XElement questionElement = questionElements.Where(q => Convert.ToInt64(q.Attribute("qId").Value)
                                                                    == testQuestion.QuestionId).FirstOrDefault();
                if (questionElement != null)
                {
                    QuestionModel question = new QuestionModel();
                    question.Id = Convert.ToInt32(questionElement.Attribute("qOrder").Value);
                    question.Content = string.Format("{0}. {1}", question.Id, testQuestion.Question.Content);
                    long questionId = Convert.ToInt64(questionElement.Attribute("qId").Value);
                    Answer answer = AllAnswerList.Where(a => a.FK_QuestionId == questionId && a.IsAnswer == true).FirstOrDefault();
                    int order = Convert.ToInt32(questionElement.Elements("A")
                                                        .Where(ao => Convert.ToInt64(ao.Attribute("aId").Value) == answer.AnswerId)
                                                        .FirstOrDefault()
                                                        .Attribute("aOrder")
                                                        .Value);
                    string answerOrder = order == 1 ? "A" : (order == 2 ? "B" : (order == 3 ? "C" : "D"));
                    question.Answer1 = answer != null ? string.Format("Đáp án: {0}. {1}", answerOrder, answer.Content) : "Đáp án: ";
                    questions.Add(question);
                }
            }
            return questions.OrderBy(x => x.Id).ToList();
        }
    }
}
