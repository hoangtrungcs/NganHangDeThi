using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Controller.Interfaces;
using Controller.Repositories;
using Model;
using System.Data.Entity;
using Model.POCO;
using System.Xml.Linq;
using Telerik.WinControls;
using System.Windows.Forms;

namespace Controller.Services
{
    public class TestsService
    {
        private IRepository<Test> m_repository;
        private IRepository<Question> m_questionRepository;
        private IRepository<StudentTest> m_studentTest;
        private IRepository<StudentTestDetail> m_studentTestDetailRepository;
        private IRepository<TestCopy> m_testCopyRepository;
        private QuestionsService m_questionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestsService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TestsService(DbContext context)
        {
            m_repository = new Repository<Test>(context);
            m_questionRepository = new Repository<Question>(context);
            m_studentTest = new Repository<StudentTest>(context);
            m_studentTestDetailRepository = new Repository<StudentTestDetail>(context);
            m_testCopyRepository = new Repository<TestCopy>(context);
            m_questionService = new QuestionsService(context);
        }
        public TestsService()
            : this(new NganHangEntities())
        {
        }

        /// <summary>
        /// Saves the test.
        /// </summary>
        /// <param name="test">The test.</param>
        public void SaveTest(Test test)
        {
            m_repository.Insert(test);
            m_repository.Commit();
        }

        /// <summary>
        /// Deletes the test.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteTest(int id)
        {
            var item = m_repository.GetById(id);
            if (item != null)
            {
                m_repository.Delete(item);
                m_repository.Commit();
            }
        }

        /// <summary>
        /// Updates the test.
        /// </summary>
        /// <param name="test">The test.</param>
        public void UpdateTest(Test test)
        {
            m_repository.Update(test);
            m_repository.Commit();
        }

        /// <summary>
        /// Creates the test.
        /// </summary>
        /// <param name="subjectId">The subject id.</param>
        /// <param name="numberOfQuestions">The number of questions.</param>
        public Test CreateTest(Test test, int subjectId, List<Tuple<QuestionLevel, int>> numberOfQuestions,
                                    int purpose, int subTest, double moreTime, out string message)
        {
            int totalQuestionForPerSubtest = numberOfQuestions.Sum(x => x.Item2);
            List<Question> questions = new List<Question>(totalQuestionForPerSubtest * subTest);
            foreach (Tuple<QuestionLevel, int> question in numberOfQuestions)
            {
                questions.AddRange(GetRandomQuestionForLevel(subjectId, question.Item1, purpose, question.Item2, subTest));
            }
            test.CreatedBy = UserService.CurrentUser.CurrentUser.Username;
            test.CreatedDate = DateTime.Now;
            test.UpdatedBy = test.CreatedBy;
            test.UpdatedDate = DateTime.Now;
            // create test copy
            foreach (Question q in questions)
            {
                var tq = new TestQuestion();
                tq.Question = q;
                tq.Test = test;
                test.TestQuestions.Add(tq);
            }

            IList<Question> tempQs = new List<Question>();

            for (int count = 0; count < subTest; count++)
            {
                XDocument structure = new XDocument(new XElement("TestCopy"));

                //New Requirement: 
                //1. Cau hoi trong cac de thi ko duoc trung nhau
                //2. Neu ko du cau hoi thi duoc trung nhung phai dao vi tri cau hoi va cau tra loi o cac de.

                //questionIdsPerSubtest with Id and Level
                var questionIdsPerSubtest = new Dictionary<long, int>();

                foreach (Tuple<QuestionLevel, int> question in numberOfQuestions)
                {
                    for (int j = questions.Count - 1; j >= 0; j--)
                    {
                        if (questions[j].Level == (int)question.Item1
                            && !questionIdsPerSubtest.Keys.ToList().Exists(x => x == questions[j].QuestionId)
                            && questionIdsPerSubtest.Count < totalQuestionForPerSubtest)
                        {
                            questionIdsPerSubtest.Add(questions[j].QuestionId, (int)question.Item1);
                            tempQs.Add(questions[j]);
                            questions.RemoveAt(j);

                            var countLevel = questionIdsPerSubtest.Values.Count(x => x == (int)question.Item1);
                            if (countLevel == question.Item2)
                            {
                                break;
                            }
                        }
                    }
                }
                
                //if (questionIdsPerSubtest.Count < totalQuestionForPerSubtest)
                //{
                //    for (int i = questions.Count - 1; i >= 0; i--)
                //    {
                //        for (int j = tempQs.Count - 1; j >= 0; j--)
                //        {
                //            if (questions[i].Level == tempQs[j].Level
                //                && !questionIdsPerSubtest.Keys.ToList().Exists(x => x == tempQs[j].QuestionId)
                //                && questionIdsPerSubtest.Count < totalQuestionForPerSubtest)
                //            {
                //                questionIdsPerSubtest.Add(tempQs[j].QuestionId, tempQs[j].Level);
                //            }
                //        }
                //    }
                //}

                for (int i = 0; i < totalQuestionForPerSubtest; i++)
                {
                    List<Answer> answers = m_questionService.GetAnswerOfQuestion(questionIdsPerSubtest.Keys.ElementAt(i));
                    List<XElement> answerList = new List<XElement>();
                    for (int j = 0; j < answers.Count; j++)
                    {
                        XElement answerElement = new XElement("A", new XAttribute("aOrder", j + 1), new XAttribute("aId", answers[j].AnswerId));
                        answerList.Add(answerElement);
                    }
                    structure.Element("TestCopy")
                             .Add(new XElement("Q", new XAttribute("qOrder", i + 1), new XAttribute("qId", questionIdsPerSubtest.Keys.ElementAt(i)),
                                        answerList));
                }
                TestCopy tc = new TestCopy();
                tc.Test = test;
                tc.TestCopyStructure = structure.ToString();
                test.TestCopies.Add(tc);
            }
            double timeStill = 0;
            if (questions.Count > 0)
            {
                timeStill = questions.Sum(x => x.Time);
            }
            double realTestTime = (tempQs.Sum(q => q.Time) + timeStill) / subTest;
            if (realTestTime > test.Time + moreTime)
            {
                message = "Thời gian chính xác để hoàn thành bài thi là: " + realTestTime +
                                       "\nThời gian thi do người dùng cài đặt là: " + test.Time +
                                       ".\nThời gian chênh lệch: " + Math.Abs(realTestTime - test.Time) +
                                       "\nBạn có muốn tiếp tục tạo đề thi không?";
            }
            else
            {
                message = "Thời gian chính xác để hoàn thành bài thi là: " + realTestTime +
                                       "\nThời gian thi do người dùng cài đặt là: " + test.Time +
                                       ".\nThời gian chênh lệch: " + Math.Abs(realTestTime - test.Time) +
                                       "\nBạn có muốn tiếp tục tạo đề thi không?";
            }
            test.TestQuestions.Clear();

            foreach (Question q in tempQs)
            {
                var tq = new TestQuestion();
                tq.Question = q;
                tq.Test = test;
                tq.QuestionId = q.QuestionId;
                if (!test.TestQuestions.ToList().Exists(x => x.QuestionId == q.QuestionId))
                {
                    test.TestQuestions.Add(tq);
                }

            }

            return test;
        }
        /// <summary>
        /// Gets the random question for level.
        /// </summary>
        /// <param name="subjectId">The subject id.</param>
        /// <param name="level">The level.</param>
        /// <param name="num">The num.</param>
        /// <returns></returns>
        private List<Question> GetRandomQuestionForLevel(int subjectId, QuestionLevel level, int purpose, int num, int subtest)
        {
            var result = new List<Question>(num * subtest);
            var questions = m_questionRepository
                .GetAll()
                .Where(x => x.FK_SubjectId == subjectId
                        && x.Level == (int)level
                        && ((purpose == (int)PurposeOverview.Total) || (x.Purpose == purpose))
                        && (x.Type == (int)QuestionType.Choice)
                        && !x.IsDelete)
                .ToList();
            int index = 0;
            if (questions.Count < num)
            {
                throw new NumberQuestionNotEnoughException(level, (PurposeOverview)purpose, questions.Count);
            }
            if (questions.Count < num * subtest)
            {
                int smaller = num * subtest - questions.Count;
                int count = 0;
                for (int i = 0; i < smaller; i++)
                {
                    if (count == num)
                    {
                        count = 0;
                    }
                    questions.Add(questions[count]);
                    count++;
                }
            }
            //Random ran;
            while (index < num * subtest)
            {
                //ran = new Random();
                var element = questions.ElementAt(RandomCommon.StaticRandom.Instance.Next(questions.Count()));
                questions.Remove(element);
                result.Add(element);
                index++;
            }
            return result;
        }

        /// <summary>
        /// Gets all tests by subject.
        /// </summary>
        /// <param name="subjectId">The subject id.</param>
        /// <returns></returns>
        public IList<Test> GetAllTestsBySubject(int subjectId)
        {
            var results = m_repository.GetAll().Where(x => !x.IsDeleted && x.FK_SubjectId == subjectId).ToList();
            foreach (var result in results)
            {
                if (result.FK_ClassId != null)
                    result.ClassName = result.LopHoc.ClassName;
            }
            return results;
        }
        public List<Test> GetLimitedTests()
        {
            return m_repository.GetAll().Where(x => !x.IsDeleted && x.IsLimited.HasValue && x.IsLimited.Value).ToList();
        }
        public Test GetTestById(long testId)
        {
            return m_repository.GetById(testId);
        }
        public Test GetTestForStudent(long studentId, int subjectId)
        {
            var studentTest =
                m_studentTest.GetAll()
                             .FirstOrDefault(
                                 x =>
                                 x.FK_StudenId == studentId && x.Test.FK_SubjectId == subjectId && !x.Score.HasValue);
            return m_repository.GetAll().Where(x => !x.IsDeleted).FirstOrDefault(x => x.TestId == studentTest.FK_TestId);
        }
        public void SaveStudentTestStructure(long studenId, long testId, string structure)
        {
            var item = m_studentTest.GetAll().FirstOrDefault(x => x.FK_StudenId == studenId && x.FK_TestId == testId);
            if (item != null)
            {
                item.QuestionStructure = structure;
                item.Score = 0;
            }
            m_studentTest.Update(item);
            m_studentTest.Commit();
        }
        public List<TestCopy> GetAllTestCopyOf(long testId)
        {
            return m_testCopyRepository.GetAll().Where(x => x.FK_TestId == testId).ToList();
        }
        public void SaveStudentTest(long studenId, long testId, float score, int rightNo, int wrongNo, int doNotWork, int time)
        {
            var item = m_studentTest.GetAll().FirstOrDefault(x => x.FK_StudenId == studenId && x.FK_TestId == testId);
            if (item != null)
            {
                item.Score = score;
                item.WrongNo = wrongNo;
                item.CorrectNo = rightNo;
                item.NotDone = doNotWork;
                item.DoneTime = time;
            }
            m_studentTest.Update(item);
            m_studentTest.Commit();
        }
        public void SaveStudentTestDetail(List<StudentTestDetail> details)
        {
            foreach (StudentTestDetail studentTestDetail in details)
            {
                m_studentTestDetailRepository.Insert(studentTestDetail);
            }
            m_studentTestDetailRepository.Commit();
        }

        public List<TestCopy> GetTestCopiesByTestId(long testId)
        {
            return m_testCopyRepository.GetAll().Where(tc => tc.FK_TestId == testId).ToList();
        }

        public TestCopy GetTestCopy(int id)
        {
            return m_testCopyRepository.GetById(id);
        }
        public List<Test> GetAllTests()
        {
            return m_repository.GetAll().Where(x => !x.IsDeleted).ToList();
        }
        public Test GetTestByTestCopyId(int testCopyId)
        {
            return m_repository.GetAll().Where(x => !x.IsDeleted).FirstOrDefault(x => x.TestCopies.Any(y => y.TestCopyId == testCopyId));
        }

        private Random m_random = new Random();
        public List<Answer> RandomAnswerOrder(List<Answer> answers)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                int idx = m_random.Next(4);
                int idx1 = m_random.Next(4);
                Answer tmp = answers[idx];
                answers[idx] = answers[idx1];
                answers[idx1] = tmp;
            }
            List<Answer> answerList = answers.Where(a => a.Content.ToLower().Contains("tất cả") ||
                                               a.Content.ToLower().Contains("cả") ||
                                               a.Content.ToLower().Contains("đều đúng") ||
                                               a.Content.ToLower().Contains("đều sai") ||
                                               a.Content.ToLower().Contains("a,b") ||
                                               a.Content.ToLower().Contains("a,c") ||
                                               a.Content.ToLower().Contains("b,c") ||
                                               a.Content.ToLower().Contains("a,b,c") ||
                                               a.Content.ToLower().Contains("a, b, c") ||
                                               a.Content.ToLower().Contains("a, b") ||
                                               a.Content.ToLower().Contains("a, c") ||
                                               a.Content.ToLower().Contains("b, c") ||
                                               a.Content.ToLower().Contains("a hoặc b") ||
                                               a.Content.ToLower().Contains("a hoặc c") ||
                                               a.Content.ToLower().Contains("b hoặc c") ||
                                               a.Content.ToLower().Contains("a và c") ||
                                               a.Content.ToLower().Contains("b và c") ||
                                               a.Content.ToLower().Contains("a và b")).ToList();
            if (answerList.Count > 0)
            {
                for (int i = 0; i < answerList.Count; i++)
                {
                    Answer answer = answerList[i];
                    answers.Remove(answer);
                    answers.Add(answer);
                }
            }
            return answers;
        }

        public Test CreateLimitedTest(Test test, List<Question> questions, int subTest, double moreTime, out string message)
        {
            test.CreatedBy = UserService.CurrentUser.CurrentUser.Username;
            test.CreatedDate = DateTime.Now;
            test.UpdatedBy = test.CreatedBy;
            test.UpdatedDate = DateTime.Now;
            foreach (Question q in questions)
            {
                var tq = new TestQuestion();
                tq.Question = q;
                tq.Test = test;
                test.TestQuestions.Add(tq);
            }
            // create test copy
            List<long> questionIds = questions.Select(q => q.QuestionId).ToList();
            Random ran = new Random();
            //Toi da 1000 cau
            int max = 1000;
            for (int count = 0; count < subTest; count++)
            {
                XDocument structure = new XDocument(new XElement("TestCopy"));
                for (int i = 0; i < max; i++)
                {
                    int index = ran.Next(questionIds.Count - 1);
                    long item = questionIds[i % questionIds.Count];
                    questionIds[i % questionIds.Count] = questionIds[index];
                    questionIds[index] = item;
                }
                for (int i = 0; i < questionIds.Count; i++)
                {
                    List<Answer> answers = m_questionService.GetAnswerOfQuestion(questionIds[i]);
                    answers = RandomAnswerOrder(answers);
                    List<XElement> answerList = new List<XElement>();
                    for (int j = 0; j < answers.Count; j++)
                    {
                        XElement answerElement = new XElement("A", new XAttribute("aOrder", j + 1), new XAttribute("aId", answers[j].AnswerId));
                        answerList.Add(answerElement);
                    }
                    structure.Element("TestCopy")
                             .Add(new XElement("Q", new XAttribute("qOrder", i + 1), new XAttribute("qId", questionIds[i]),
                                        answerList));
                }
                TestCopy tc = new TestCopy();
                tc.Test = test;
                tc.TestCopyStructure = structure.ToString();
                test.TestCopies.Add(tc);
            }
            double realTestTime = questions.Sum(q => q.Time);
            if (realTestTime > test.Time + moreTime)
            {
                message = "Thời gian chính xác để hoàn thành bài thi là: " + realTestTime +
                                       "\nThời gian thi do người dùng cài đặt + cấu hình (" + moreTime + " phút): " + (test.Time + moreTime) +
                                       ".\nThời gian chênh lệch: " + Math.Abs(realTestTime - (test.Time + moreTime)) +
                                       "\nBạn có muốn tiếp tục tạo đề thi không?";
            }
            else
            {
                message = "Thời gian chính xác để hoàn thành bài thi là: " + realTestTime +
                                       "\nThời gian thi do người dùng cài đặt + cấu hình (" + moreTime + " phút): " + (test.Time + moreTime) +
                                       ".\nThời gian chênh lệch: " + Math.Abs(realTestTime - (test.Time + moreTime)) +
                                       "\nBạn có muốn tiếp tục tạo đề thi không?";
            }
            return test;
        }

    }
}
