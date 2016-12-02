using Controller.Interfaces;
using Controller.Repositories;
using Model.POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Services
{
    public class SubjectsClassService : IService<SubjectsClass>
    {
        private IRepository<SubjectsClass> m_subjectsClassRepository;
        private DbContext m_dbContext;
        private IRepository<Student> m_studentRepository;
        private SubjectsService m_subjectService;
        private DepartmentService m_departmentService;
        private UserService m_teacherService;

        public SubjectsClassService()
            : this(new NganHangEntities())
        {

        }
        public SubjectsClassService(DbContext context)
        {
            m_dbContext = context;
            m_subjectsClassRepository = new Repository<SubjectsClass>(m_dbContext);
            m_studentRepository = new Repository<Student>(m_dbContext);
            m_subjectService = new SubjectsService(context);
            m_departmentService = new DepartmentService(context);
            m_teacherService = new UserService(context);
        }
        public void Save(SubjectsClass entity)
        {
            if (entity.SubjectsClassId > 0)
            {
                m_subjectsClassRepository.Update(entity);
            }
            else
            {
                m_subjectsClassRepository.Insert(entity);
            }
            m_subjectsClassRepository.Commit();
        }

        public void SaveAll(IEnumerable<SubjectsClass> entities)
        {
            foreach (SubjectsClass item in entities)
            {
                if (item.SubjectsClassId > 0)
                {
                    m_subjectsClassRepository.Update(item);
                }
                else
                {
                    m_subjectsClassRepository.Insert(item);
                }
            }
            m_subjectsClassRepository.Commit();
        }

        public List<Student> GetAllStudentsByClass(int classId)
        {
            var @class = m_subjectsClassRepository.GetAll().FirstOrDefault(x => x.SubjectsClassId == classId && !x.IsDelete);
            if (@class != null)
            {
                var lstStudentIds = @class.Students.Select(x => x.StudentId).ToList();
                return m_studentRepository.GetAll().Where(x => lstStudentIds.Contains(x.StudentId)).ToList();
            }
            return null;
        }

        public List<SubjectsClass> GetAllSubjecClassBySubject(int subjectId)
        {
            var subjectClassList = GetAll();
            if (subjectClassList.Count > 0)
            {
                return subjectClassList.Where(x => x.FK_SubjectId == subjectId).ToList();
            }
            return null;
        }

        public void Delete(SubjectsClass entity)
        {
            entity.IsDelete = true;
            m_subjectsClassRepository.Delete(entity);
        }

        public List<SubjectsClass> GetAll()
        {
            return m_subjectsClassRepository.GetAll().Where(x => !x.IsDelete).ToList();
        }

        /// <summary>
        /// Get all students
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllStudent()
        {
            return m_studentRepository.GetAll().ToList();
        }

        public void Update(SubjectsClass entity)
        {
            throw new NotImplementedException();
        }

        public DbContext Context
        {
            get { return m_dbContext; }
        }

        public Subject GetSubjectById(int subjectId)
        {
            return m_subjectService.GetById(subjectId);
        }

        public Department GetDepartmentById(long departmentId)
        {
            return m_departmentService.GetDepartmentById(departmentId);
        }

        public Teacher GetTeacherById(int teacherId)
        {
            return m_teacherService.GetById(teacherId);
        }
    }
}
