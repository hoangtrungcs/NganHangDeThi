using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Controller.Interfaces;
using Controller.Repositories;
using Model;
using Model.POCO;

namespace Controller.Services {
    public class StudentTestService : IService<StudentTest> {
        private IRepository<StudentTest> m_repository;
        private IRepository<SubjectsClass> m_subjectClasses;
        private DbContext m_context;
        public StudentTestService()
            : this(new NganHangEntities()) {
        }
        public StudentTestService(DbContext context) {
            m_context = context;
            m_repository = new Repository<StudentTest>(context);
            m_subjectClasses = new Repository<SubjectsClass>(context);
        }

        public StudentTest GetObjectByStudentIdAndTestId(long studentId, long testId) {
            return m_repository.GetAll().FirstOrDefault(x => x.FK_TestId == testId && x.FK_StudenId == studentId);
        }

        public List<StudentTest> GetAllStudentTestByClass(int classId) {
            var classes = m_subjectClasses.GetAll()
                                            .Include(x=>x.Students)
                                            .FirstOrDefault(x => x.SubjectsClassId == classId);
            if (classes != null) {
                var stuIds = classes.Students.Select(x => x.StudentId).ToList();
                return m_repository.GetAll().Where(x => stuIds.Contains(x.FK_StudenId)).ToList();
            }

            return null;
        }

        /// <summary>
        /// Deletes the question.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <exception cref="System.InvalidOperationException">Your deleted item is not exist!</exception>
        public void Delete(StudentTest objStudentTest) {
            if (objStudentTest != null) {
                m_repository.Delete(objStudentTest);
                m_repository.Commit();
                return;
            }
            throw new InvalidOperationException("Your deleted item is not exist!");

        }
        public void Insert(StudentTest entity) {
            m_repository.Insert(entity);
            m_repository.Commit();
        }
        public void Save(StudentTest entity) {
            using (var trans = new TransactionScope()) {
                try {
                    var item = GetObjectByStudentIdAndTestId(entity.FK_StudenId, entity.FK_TestId);
                    if (item != null) {
                        Delete(item);
                    }
                    Insert(entity);
                    trans.Complete();

                } catch (Exception) {
                    trans.Dispose();
                }
            }

        }

        public void SaveAll(IEnumerable<StudentTest> entities) {
            foreach (StudentTest studentTest in entities) {
                Update(studentTest);
            }
            m_repository.Commit();
        }

        public void Update(StudentTest entity) {
            var item = m_repository.GetAll()
                                   .FirstOrDefault(x => x.FK_StudenId == entity.FK_StudenId && x.FK_TestId == entity.FK_TestId);
            if (item == null) {
                m_repository.Insert(entity);
            } else {
                item.CorrectNo = entity.CorrectNo;
                item.Description = entity.Description;
                item.DoneTime = entity.DoneTime;
                item.NotDone = entity.NotDone;
                item.QuestionStructure = entity.QuestionStructure;
                item.Score = entity.Score;
                item.WrongNo = entity.WrongNo;
            }
        }

        public List<StudentTest> GetAll() {
            return m_repository.GetAll()
                .Include(x => x.Student)
                .Include(x => x.Test)
                .ToList();
        }

        public DbContext Context {
            get { return m_context; }
        }
    }
}
