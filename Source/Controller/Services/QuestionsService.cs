using System;
using System.Collections.Generic;
using System.Transactions;
using Common;
using Controller.Interfaces;
using Controller.Repositories;
using Model;
using System.Data.Entity;
using System.Linq;
using Model.POCO;

namespace Controller.Services {
    public class QuestionsService : BaseService<Question> {
        #region Fields
        private IRepository<Answer> m_answerRepository;
        private IRepository<TestQuestion> m_testQuestionRepository;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionsService"/> class.
        /// </summary>
        /// <param name="db">The db.</param>
        public QuestionsService(DbContext db) {
            m_repository = new Repository<Question>(db);
            m_answerRepository = new Repository<Answer>(db);
            m_testQuestionRepository = new Repository<TestQuestion>(db);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionsService"/> class.
        /// </summary>
        public QuestionsService()
            : this(new NganHangEntities()) {

        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Deletes the question.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <exception cref="System.InvalidOperationException">Your deleted item is not exist!</exception>
        public void DeleteQuestion(long questionId) {
            var item = m_repository.GetById(questionId);
            if (item != null) {
                if (item.Answers.Count > 0) {
                    foreach (var objAnswer in item.Answers) {
                        m_answerRepository.Delete(objAnswer);
                    }
                }
                m_repository.Delete(item);
                m_repository.Commit();
                return;
            }
            throw new InvalidOperationException("Your deleted item is not exist!");
        }

        /// <summary>
        /// Gets all question by test.
        /// </summary>
        /// <param name="testId">The test id.</param>
        /// <returns></returns>
        public List<Question> GetAllQuestionByTest(long testId) {
            return m_testQuestionRepository.GetAll().Where(x => x.TestId == testId).Select(x => x.Question).ToList();
        }

        /// <summary>
        /// Counts the questions in subject.
        /// </summary>
        /// <param name="subjectId">The subject id.</param>
        /// <returns></returns>
        public int CountQuestionsInSubject(int subjectId) {
            return m_repository.GetAll().Count(x => (x.FK_SubjectId == subjectId) && !x.IsDelete);
        }

        /// <summary>
        /// Counts the questions in subject.
        /// </summary>
        /// <param name="subjectIds">The subject id list.</param>
        /// <returns></returns>
        public int CountQuestionsInSubjects(List<int> subjectIds)
        {
            return subjectIds.Sum(id => m_repository.GetAll().Count(x => (x.FK_SubjectId == id) && !x.IsDelete));
        }

        /// <summary>
        /// Gets the answer of question.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <returns></returns>
        public List<Answer> GetAnswerOfQuestion(long questionId) {
            var question = m_repository.GetById(questionId);
            var answers = m_answerRepository.GetAll().Where(x => x.FK_QuestionId == questionId).Take(4).ToList();

            return question.IsAnswerRandom.GetValueOrDefault(false) ? RandomAnswerOrder(answers) : answers;
        }

        public List<Answer> GetAllAnswer() {
            return m_answerRepository.GetAll().ToList();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public override List<Question> GetAll() {
            return GetAllQueryable().Where(x => !x.IsDelete).ToList();
        }

        public List<Question> GetPurposeQuestions(int purpose)
        {
            return GetAllQueryable().Where(x => !x.IsDelete && ((purpose == (int)PurposeOverview.Total) || (x.Purpose == purpose))).ToList();
        } 

        /// <summary>
        /// Gets all question by subject.
        /// </summary>
        /// <param name="subjectId">The subject id.</param>
        /// <returns></returns>
        public List<Question> GetAllQuestionBySubject(int subjectId, QuestionType type) {
            return GetAllQueryable()
                .Where(x => x.FK_SubjectId == subjectId
                    && !x.IsDelete && x.Type == (int)type
                    ).ToList();
        }

        /// <summary>
        /// Gets all question by subject.
        /// </summary>
        /// <param name="subjectId">The subject id.</param>
        /// <param name="level">The question level.</param>
        /// <returns></returns>
        public int GetAllQuestionBySubjectAndLevel(int subjectId, int level, int type, int purpose) {
            if (purpose == (int)PurposeOverview.Total) {
                return GetAllQueryable()
                    .Where(x => x.FK_SubjectId == subjectId
                        && !x.IsDelete && x.Type == type && x.Level == level).Count();
            }
            return GetAllQueryable()
                    .Where(x => x.FK_SubjectId == subjectId
                        && !x.IsDelete && x.Type == type && x.Level == level && x.Purpose == purpose).Count();
        }

        public List<Question> GetQuestionsBySubjectAndPurpose(int subjectId, int type, int purpose) {
            if (purpose == (int)PurposeOverview.Total) {
                return GetAllQueryable()
                    .Where(x => x.FK_SubjectId == subjectId
                        && !x.IsDelete && x.Type == type).ToList();
            }
            return GetAllQueryable()
                    .Where(x => x.FK_SubjectId == subjectId
                        && !x.IsDelete && x.Type == type && x.Purpose == purpose).ToList();
        }

        public List<Question> GetQuestionsBySubjectsAndPurpose(List<int> subjectIds, int purpose) {
            if (purpose == (int)PurposeOverview.Total)
            {
                return GetAllQueryable()
                    .Where(x => subjectIds.Contains(x.FK_SubjectId)
                        && !x.IsDelete && x.Type == (int)QuestionType.Choice).ToList();
            }
            return GetAllQueryable()
                    .Where(x => subjectIds.Contains(x.FK_SubjectId)
                        && !x.IsDelete && x.Purpose == purpose && x.Type == (int)QuestionType.Choice).ToList();
        }

        public List<Question> GetMixedQuestionsBySubjectsAndPurpose(List<int> subjectIds, int purpose) {
            if (purpose == (int)PurposeOverview.Total) {
                return GetAllQueryable()
                    .Where(x => subjectIds.Contains(x.FK_SubjectId)
                        && !x.IsDelete).ToList();
            }
            return GetAllQueryable()
                    .Where(x => subjectIds.Contains(x.FK_SubjectId)
                        && !x.IsDelete && x.Purpose == purpose).ToList();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Delete(Question entity) {
            if (entity.QuestionId > 0) {
                entity.IsDelete = true;
                Update(entity);
            } else {
                base.Delete(entity);
            }
            m_repository.Commit();
        }

        /// <summary>
        /// Saves all.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public override void SaveAll(IEnumerable<Question> entities) {
            if (entities != null && entities.Any()) {
                List<Question> addNew = entities.Where(x => x.QuestionId <= 0).ToList();
                addNew.ForEach(x => m_repository.Insert(x));
                var updates = entities.Where(x => x.QuestionId > 0).ToList();
                updates.ForEach(x => m_repository.Update(x));
                m_repository.Commit();
            }
        }

        public List<Guid> GetExitsQuestionGuids(IEnumerable<Guid> qGuids) {
            return
                m_repository.GetAll().Where(x => qGuids.Contains(x.QuestionGuid)).Select(x => x.QuestionGuid).ToList();
        }

        public int Count(int subjectId, int purpose) {
            if (purpose == (int)PurposeOverview.Total) {
                return GetAllQueryable()
                    .Count(x => x.FK_SubjectId == subjectId
                        && !x.IsDelete && x.Type == (int)QuestionType.Choice);
            }
            return GetAllQueryable()
                    .Count(x => x.FK_SubjectId == subjectId
                        && !x.IsDelete && x.Type == (int)QuestionType.Choice && x.Purpose == purpose);
        }

        public int Count(List<int> subjectIds, int purpose) {
            if (purpose == (int)PurposeOverview.Total) {
                return GetAllQueryable()
                    .Count(x => subjectIds.Contains(x.FK_SubjectId)
                        && !x.IsDelete);
            }
            return GetAllQueryable()
                    .Count(x => subjectIds.Contains(x.FK_SubjectId)
                        && !x.IsDelete && x.Purpose == purpose);
        }

        /// <summary>
        /// Gets the random question for level.
        /// </summary>
        /// <param name="subjectId">The subject id.</param>
        /// <param name="level">The level.</param>
        /// <param name="num">The num.</param>
        /// <returns></returns>
        public List<Question> GetRandomQuestionForLevel(int subjectId, QuestionLevel level, int type, int purpose, int num) {
            var result = new List<Question>(num);
            List<Question> questions = new List<Question>();
            if (purpose != (int)PurposeOverview.Total) {
                questions = m_repository
                    .GetAll()
                    .Where(x => x.FK_SubjectId == subjectId
                            && x.Level == (int)level
                            && x.Type == type
                            && x.Purpose == purpose && !x.IsDelete)
                    .ToList();
            } else {
                questions = m_repository
                    .GetAll()
                    .Where(x => x.FK_SubjectId == subjectId
                            && x.Level == (int)level
                            && x.Type == type
                            && !x.IsDelete)
                    .ToList();
            }
            int index = 0;
            if (questions.Count < num) {
                throw new NumberQuestionNotEnoughException(level, (PurposeOverview)purpose, questions.Count);
            }
            //Random ran;
            while (index < num) {
                //ran = new Random();
                //Use RandomCommon.StaticRandom.Instance because vi dung random cũ không chính xác-nó tạo những câu hỏi liên tiếp nhau tại một thời điểm
                var element = questions.ElementAt(RandomCommon.StaticRandom.Instance.Next(questions.Count()));
                questions.Remove(element);
                result.Add(element);
                index++;
            }
            return result;
        }

        public List<Question> GetRandomQuestion(List<int> subjectIds, int purpose, int num) {
            var result = new List<Question>(num);
            List<Question> questions = new List<Question>();
            if (purpose != (int)PurposeOverview.Total) {
                questions = m_repository
                        .GetAll()
                        .Where(x => subjectIds.Contains(x.FK_SubjectId)
                                && x.Purpose == purpose && !x.IsDelete)
                        .ToList();
            } else {
                questions = m_repository
                        .GetAll()
                        .Where(x => subjectIds.Contains(x.FK_SubjectId))
                        .ToList();
            }
            int index = 0;
            if (questions.Count < num) {
                throw new Exception("Số lượng câu hỏi của các môn không đủ đáp ứng nhu cầu của bạn");
            }
            //Random ran;
            while (index < num) {
                //ran = new Random();
                var element = questions.ElementAt(RandomCommon.StaticRandom.Instance.Next(questions.Count()));
                questions.Remove(element);
                result.Add(element);
                index++;
            }
            return result;
        }

        private Random m_random = new Random();
        private List<Answer> RandomAnswerOrder(List<Answer> answers)
        {
            for (int i = 0; i < answers.Count; i++)
            {
                int idx = m_random.Next(4);
                int idx1 = m_random.Next(4);
                var tmp = answers[idx];
                answers[idx] = answers[idx1];
                answers[idx1] = tmp;
            }
            var answerList = answers.Where(a => a.Content.ToLower().Contains("tất cả") ||
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
                foreach (var answer in answerList)
                {
                    answers.Remove(answer);
                    answers.Add(answer);
                }
            }

            return answers;
        }

        #endregion Methods
    }
}
