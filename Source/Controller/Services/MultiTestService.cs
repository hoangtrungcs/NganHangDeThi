using Common;
using Controller.Interfaces;
using Controller.Repositories;
using Model.POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Telerik.WinControls;

namespace Controller.Services
{
    public class MultiTestService : BaseService<MultiTest>
    {

        private SubjectsService m_subjectService;
        private IRepository<SubjectsMultiTest> m_subjectsMultiTestRepository;
        private IRepository<Question> m_questionRepository;
        private IRepository<MultiTestCopy> m_multiTestCopyRepository;
        private QuestionsService m_questionService;

        public MultiTestService(NganHangEntities dbContext)
        {
            m_repository = new Repository<MultiTest>(dbContext);
            m_subjectService = new SubjectsService(dbContext);
            m_subjectsMultiTestRepository = new Repository<SubjectsMultiTest>(dbContext);
            m_questionRepository = new Repository<Question>(dbContext);
            m_multiTestCopyRepository = new Repository<MultiTestCopy>(dbContext);
            m_questionService = new QuestionsService(dbContext);
        }

        public MultiTestService()
            : this(new NganHangEntities())
        {

        }

        public override void SaveAll(IEnumerable<MultiTest> entities)
        {
            foreach (var test in entities)
            {
                if (test.MultiTestId > 0)
                {
                    m_repository.Update(test);
                }
                else
                {
                    m_repository.Insert(test);
                }
            }
            m_repository.Commit();
        }

        public List<SubjectsMultiTest> GetSubjectsMultiTestBySubjectIds(List<int> subjectIds, long multiTestId)
        {
            List<SubjectsMultiTest> result = new List<SubjectsMultiTest>();
            foreach (int id in subjectIds)
            {
                if (multiTestId > 0)
                {
                    SubjectsMultiTest item = m_subjectsMultiTestRepository.GetAll().Where(s => s.FK_SubjectId == id
                                                                                            && s.FK_MultiTestId == multiTestId).FirstOrDefault();
                    result.Add(item);
                }
                else
                {
                    SubjectsMultiTest s = new SubjectsMultiTest();
                    s.FK_MultiTestId = 0;
                    s.Subject = m_subjectService.GetById(id);
                    s.FK_SubjectId = id;
                    result.Add(s);
                }
            }
            return result;
        }

        public List<Subject> GetAllSubjects()
        {
            return m_subjectService.GetAllSubject().ToList();
        }

        public override List<MultiTest> GetAll()
        {
            var results = GetAllQueryable().Where(x => !x.IsDeleted).ToList();
            foreach (var multiTest in results)
            {
                if (multiTest.FK_ClassId != null)
                {
                    multiTest.ClassNameForMulti = multiTest.LopHoc.ClassName;
                }
            }
            return results;
        }
        public MultiTest CreateMultiTest(MultiTest test, object classForMultiTest, Dictionary<int, List<Tuple<QuestionLevel, int>>> questionsNo, int copyNos, int totalQuestion, int purpose, double moreTime, out string message)
        {
            List<Question> questions = new List<Question>();
            foreach (int subjectId in questionsNo.Keys)
            {
                foreach (var questionNo in questionsNo[subjectId])
                {
                    questions.AddRange(RandomQuestion(subjectId, questionNo.Item1, questionNo.Item2, purpose));
                }
            }
            test.CreatedBy = UserService.CurrentUser.CurrentUser.Username;
            test.CreatedDate = DateTime.Now;
            test.UpdatedBy = test.CreatedBy;
            test.UpdatedDate = DateTime.Now;
            test.IsMixedTest = false;
            if (classForMultiTest != null)
                test.FK_ClassId = (int)classForMultiTest;

            foreach (Question question in questions)
            {
                MultiTestQuestion mtq = new MultiTestQuestion();
                mtq.Question = question;
                //mtq.MultiTest = test;
                test.MultiTestQuestions.Add(mtq);
            }
            // create test copy
            List<long> questionIds = questions.Select(q => q.QuestionId).ToList();
            Random ran = new Random();
            int max = 1000;
            for (int count = 0; count < copyNos; count++)
            {
                XDocument structure = new XDocument(new XElement("MultiTestCopy"));
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
                    List<XElement> answerList = new List<XElement>();
                    for (int j = 0; j < answers.Count; j++)
                    {
                        XElement answerElement = new XElement("A", new XAttribute("aOrder", j + 1), new XAttribute("aId", answers[j].AnswerId));
                        answerList.Add(answerElement);
                    }
                    structure.Element("MultiTestCopy")
                             .Add(new XElement("Q", new XAttribute("qOrder", i + 1), new XAttribute("qId", questionIds[i]),
                                        answerList));

                }
                MultiTestCopy tc = new MultiTestCopy();
                //tc.MultiTest = test;
                tc.MultiTestCopyStructure = structure.ToString();
                test.MultiTestCopies.Add(tc);
            }
            double realTestTime = questions.Sum(q => q.Time);
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
            return test;
        }

        public MultiTest CreateMixedTest(MultiTest test, object classForMultiTest, Dictionary<int, List<Tuple<QuestionLevel, int>>> questionsNo, Dictionary<int, List<Tuple<QuestionLevel, int>>> questionsNo1, int copyNos, int totalQuestion, int purpose, double moreTime, out string message)
        {
            List<Question> questions = new List<Question>();
            List<Question> questions1 = new List<Question>();
            foreach (int subjectId in questionsNo.Keys)
            {
                foreach (var questionNo in questionsNo[subjectId])
                {
                    questions.AddRange(RandomQuestion(subjectId, questionNo.Item1, questionNo.Item2, purpose));
                }
                foreach (var questionNo in questionsNo1[subjectId])
                {
                    questions1.AddRange(RandomCusQuestion(subjectId, questionNo.Item1, questionNo.Item2, purpose));
                }
            }

            test.CreatedBy = UserService.CurrentUser.CurrentUser.Username;
            test.CreatedDate = DateTime.Now;
            test.UpdatedBy = test.CreatedBy;
            test.UpdatedDate = DateTime.Now;
            test.IsMixedTest = true;
            if (classForMultiTest != null)
                test.FK_ClassId = (int)classForMultiTest;

            foreach (Question question in questions)
            {
                MultiTestQuestion mtq = new MultiTestQuestion();
                mtq.Question = question;
                //mtq.MultiTest = test;
                test.MultiTestQuestions.Add(mtq);
            }
            foreach (Question question in questions1)
            {
                MultiTestQuestion mtq = new MultiTestQuestion();
                mtq.Question = question;
                //mtq.MultiTest = test;
                test.MultiTestQuestions.Add(mtq);
            }
            // create test copy
            List<long> questionIds = questions.Select(q => q.QuestionId).ToList();
            Random ran = new Random();
            int max = 1000;
            for (int count = 0; count < copyNos; count++)
            {
                XDocument structure = new XDocument(new XElement("MultiTestCopy"));
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
                    List<XElement> answerList = new List<XElement>();
                    for (int j = 0; j < answers.Count; j++)
                    {
                        XElement answerElement = new XElement("A", new XAttribute("aOrder", j + 1), new XAttribute("aId", answers[j].AnswerId));
                        answerList.Add(answerElement);
                    }
                    structure.Element("MultiTestCopy")
                             .Add(new XElement("Q", new XAttribute("qOrder", i + 1), new XAttribute("qId", questionIds[i]),
                                        answerList));
                }
                MultiTestCopy tc = new MultiTestCopy();
                //tc.MultiTest = test;
                tc.MultiTestCopyStructure = structure.ToString();
                test.MultiTestCopies.Add(tc);
            }
            double realTestTime = questions.Sum(q => q.Time);
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
            return test;
        }

        public List<MultiTestCopy> GetTestCopiesByTestId(long multiTestId)
        {
            return m_multiTestCopyRepository.GetAll().Where(tc => tc.FK_MultiTestId == multiTestId).ToList();
        }

        public MultiTest GetMultiTestById(long id)
        {
            return m_repository.GetById(id);
        }

        public MultiTestCopy GetMultiTestCopyById(int testCopyId)
        {
            return m_multiTestCopyRepository.GetById(testCopyId);
        }

        private List<Question> RandomQuestion(int subjectId, QuestionLevel level, int questionNo, int purpose)
        {
            List<Question> result = new List<Question>();
            List<Question> questions = new List<Question>();
            questions = m_questionRepository.GetAll().Where(x => (x.FK_SubjectId == subjectId)
                                                                && (x.Level == (int)level)
                                                                && ((purpose == (int)PurposeOverview.Total) || (x.Purpose == purpose))
                                                                && (x.Type == (int)QuestionType.Choice)).ToList();

            if (questions.Count < questionNo)
            {
                throw new NumberQuestionNotEnoughException(level, (PurposeOverview)purpose, questions.Count);
            }

            int index = 0;
            while (index < questionNo)
            {
                var element = questions.ElementAt(RandomCommon.StaticRandom.Instance.Next(questions.Count()));
                questions.Remove(element);
                result.Add(element);
                index++;
            }
            return result;
        }

        private List<Question> RandomCusQuestion(int subjectId, QuestionLevel level, int questionNo, int purpose)
        {
            List<Question> result = new List<Question>(questionNo);
            List<Question> questions = new List<Question>();
            if (purpose != (int)PurposeOverview.Total)
            {
                questions = m_questionRepository.GetAll().Where(x => x.FK_SubjectId == subjectId
                    && x.Level == (int)level && x.Purpose == purpose && x.Type == (int)QuestionType.Custom).ToList();
            }
            else
            {
                questions = m_questionRepository.GetAll().Where(x => x.FK_SubjectId == subjectId
                    && x.Level == (int)level && x.Type == (int)QuestionType.Custom).ToList();
            }
            int index = 0;
            Random ran = new Random();
            while (index < questionNo)
            {
                var element = questions.ElementAt(ran.Next(questions.Count()));
                questions.Remove(element);
                result.Add(element);
                index++;
            }
            return result;
        }

        public void SaveTest(MultiTest test)
        {
            m_repository.Insert(test);
            m_repository.Commit();
        }

        public MultiTest CreateNoSameMultiTest(MultiTest test, object classForMultiTest, Dictionary<int, List<Tuple<QuestionLevel, int>>> questionsNo, int copyNos, int totalQuestion, int purpose, double moreTime, out string message)
        {
            test.CreatedBy = UserService.CurrentUser.CurrentUser.Username;
            test.CreatedDate = DateTime.Now;
            test.UpdatedBy = test.CreatedBy;
            test.UpdatedDate = DateTime.Now;
            test.IsMixedTest = false;
            if (classForMultiTest != null) test.FK_ClassId = (int)classForMultiTest;

            var allQuestions = m_questionService.GetPurposeQuestions(purpose);

            var questionsTmp = new List<Question>();

            for (int i = 0; i < copyNos; i++)
            {
                var questionsPerSubTest = GetRandomQuestionPerSubTest(questionsNo, allQuestions);
                questionsTmp.AddRange(questionsPerSubTest);

                var structure = new XDocument(new XElement("MultiTestCopy"));

                int k = 0;
                foreach (var question in questionsPerSubTest)
                {
                    var answers = m_questionService.GetAnswerOfQuestion(question.QuestionId);
                    var answerList = new List<XElement>();
                    for (int j = 0; j < answers.Count; j++)
                    {
                        var answerElement = new XElement("A", new XAttribute("aOrder", j + 1), new XAttribute("aId", answers[j].AnswerId));
                        answerList.Add(answerElement);
                    }
                    structure.Element("MultiTestCopy")
                             .Add(new XElement("Q", new XAttribute("qOrder", ++k), new XAttribute("qId", question.QuestionId),
                                        answerList));

                }
                MultiTestCopy tc = new MultiTestCopy();
                //tc.MultiTest = test;
                tc.MultiTestCopyStructure = structure.ToString();
                test.MultiTestCopies.Add(tc);
            }

            foreach (Question question in questionsTmp)
            {
                var mtq = new MultiTestQuestion();
                mtq.Question = question;
                //mtq.MultiTest = test;
                test.MultiTestQuestions.Add(mtq);
            }

            message = string.Empty;
            return test;
        }

        private List<Question> GetRandomQuestionPerSubTest(Dictionary<int, List<Tuple<QuestionLevel, int>>> questionsNo, List<Question> allQuestions)
        {
            var result = new List<Question>();

            foreach (var subjectId in questionsNo.Keys)
            {
                foreach (var questionNo in questionsNo[subjectId])
                {
                    var questions = allQuestions.Where(item => (item.FK_SubjectId == subjectId)
                                                            && (item.Level == (int)questionNo.Item1));
                    for (int i = 0; i < questionNo.Item2; i++)
                    {
                        var question = questions.ElementAt(RandomCommon.StaticRandom.Instance.Next(questions.Count()));
                        result.Add(question);
                        allQuestions.Remove(question);
                    }
                }
            }

            return result;
        } 
    }
}
