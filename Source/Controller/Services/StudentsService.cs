using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Interfaces;
using Controller.Repositories;
using Model;
using Model.Exceptions;
using System.Transactions;
using Model.POCO;

namespace Controller.Services {
    public class StudentsService : IService<Student> {
        private static Student s_current;
        private DbContext m_context;
        public static Student CurrentStudent { get { return s_current; } }
        private IRepository<Subject> m_subjectRepository;
        private IRepository<Student> m_repository;
        private IRepository<StudentTest> m_studentTestRepository;
        public StudentsService()
            : this(new NganHangEntities()) {
        }
        public StudentsService(DbContext context) {
            m_context = context;
            m_repository = new Repository<Student>(context);
            m_subjectRepository = new Repository<Subject>(context);
            m_studentTestRepository = new Repository<StudentTest>(context);
        }
        public bool Login(string username, string password) {
            s_current = m_repository.GetAll().FirstOrDefault(x => x.UserName == username && x.PassWord == password);
            return s_current != null;
        }
        public bool Login(string username, string password, int subjectId) {
            var student = m_repository.GetAll().FirstOrDefault(x => x.UserName == username && x.PassWord == password);
            if (student != null) {
                var testId =
                    m_studentTestRepository.GetAll()
                                           .FirstOrDefault(
                                               x =>
                                               x.FK_StudenId == student.StudentId
                                               && x.Test.FK_SubjectId == subjectId &&
                                               !x.Score.HasValue);
                s_current = student;
                return testId != null;
            }
            return false;
        }
        public List<Subject> GetAllSubjects() {
            return m_subjectRepository.GetAll().ToList();
        }
        /// <summary>
        /// Gets all student.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotAuthorizedUser"></exception>
        public IList<Student> GetAllStudent() {
            if (UserService.CurrentUser == null) {
                throw new NotAuthorizedUser();
            }
            return m_repository.GetAll().ToList();
        }
        /// <summary>
        /// Gets all student.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <exception cref="NotAuthorizedUser"></exception>
        public Student GetStudentById(long id) {
            if (UserService.CurrentUser == null) {
                throw new NotAuthorizedUser();
            }
            return m_repository.GetById((object)id);
        }

        public void InsertStudent(Student entity) {
            m_repository.Insert(entity);
            m_repository.Commit();
        }

        public void DeleteStudent(long id) {
            var item = m_repository.GetById(id);
            if (item != null) {
                item.IsActive = false;
                m_repository.Delete(item);
                m_repository.Commit();
            }
        }

        public void UpdateStudent(Student entity) {
            m_repository.Update(entity);
            m_repository.Commit();
        }

        public bool SaveStudent(Student entity) {
            using (var trans = new TransactionScope()) {
                try {
                    if (entity.StudentId > 0) {
                        UpdateStudent(entity);
                        trans.Complete();
                        return true;
                    } else {
                        InsertStudent(entity);
                        trans.Complete();
                        return true;
                    }
                } catch (Exception) {
                    trans.Dispose();
                    return false;
                }

            }

        }

        public void Save(Student entity) {
            SaveStudent(entity);
        }

        public void Delete(Student entity) {
            DeleteStudent(entity.StudentId);
        }

        public List<Student> GetAll() {
            return GetAllStudent().ToList();
        }

        public void SaveAll(IEnumerable<Student> entities) {
            foreach (var student in entities)
            {
                if(student.StudentId >0)
                {
                    m_repository.Update(student);
                }else
                {
                    m_repository.Insert(student);
                }
            }
            m_repository.Commit();
        }

        public void Update(Student entity) {
            throw new NotImplementedException();
        }

        public DbContext Context {
            get { return m_context; }
        }
    }
}
