using System;
using System.Collections.Generic;
using Common;
using Controller.Interfaces;
using Controller.Repositories;
using Model;
using System.Data.Entity;
using System.Linq;
using Model.Exceptions;
using Model.POCO;

namespace Controller.Services {
    public class UserService : IService<Teacher> {
        private IRepository<Teacher> m_repository;
        private IRepository<TeacherOperation> m_teacherOperationRepository;
        private IRepository<UserSubjectRight> m_userSubjectService;
        private DbContext m_context;
        private static UserModel m_currentUser;
        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public static UserModel CurrentUser {
            get { return m_currentUser; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserService(DbContext context) {
            m_repository = new Repository<Teacher>(context);
            m_teacherOperationRepository = new Repository<TeacherOperation>(context);
            m_userSubjectService = new Repository<UserSubjectRight>(context);
            m_context = context;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        public UserService()
            : this(new NganHangEntities()) {

        }
        /// <summary>
        /// Determines whether this instance is login.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is login; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLogin() {
            return m_currentUser != null;
        }
        /// <summary>
        /// Logins the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="pass">The pass.</param>
        /// <returns></returns>
        public bool Login(string username, string pass) {
            var user = m_repository.GetAll().FirstOrDefault(x => x.Username == username && x.PassWord == pass);
            if (user != null) {
                var rights = user.UserSubjectRights.ToList();
                m_currentUser = new UserModel(user, rights);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Gets all user subject rights.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public IList<UserSubjectRight> GetAllUserSubjectRights(string username) {
            var user = m_repository.GetAll().FirstOrDefault(x => x.Username == username);
            if (user != null) {
                return user.UserSubjectRights.ToList();
            }
            return new List<UserSubjectRight>();
        }
        /// <summary>
        /// Logouts this instance.
        /// </summary>
        public void Logout() {
            m_currentUser = null;
        }

        /// <summary>
        /// Adds the right for user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="lstRight">The LST right.</param>
        public void AddRightForUser(int userId, List<Tuple<int, RightType>> lstRight) {
            var user = m_repository.GetById(userId);
            if (user != null) {
                foreach (Tuple<int, RightType> tuple in lstRight) {
                    var right = user.UserSubjectRights.FirstOrDefault(x => x.FK_SubjectId == tuple.Item1);
                    if (right == null) {
                        right = new UserSubjectRight();
                        user.UserSubjectRights.Add(right);
                    }
                    right.Right = (int)tuple.Item2;
                }
                m_repository.Commit();
            }
        }
        /// <summary>
        /// Gets the current user operations.
        /// </summary>
        /// <returns></returns>
        public List<string> GetCurrentUserOperations() {
            return
                m_teacherOperationRepository.GetAll()
                                            .Where(x => x.TeacherId == CurrentUser.CurrentUser.TeacherId && x.Enable)
                                            .Select(x => x.OperationName)
                                            .ToList();
        }
        public IList<Teacher> GetAllTeachers() {
            return m_repository.GetAll().Where(x => x.IsActive).Include(t => t.Department).ToList();
        }
        public int FindUserId(string username) {
            return m_repository.GetAll()
                .Where(x => x.Username == username)
                .Select(x => x.TeacherId)
                .FirstOrDefault();
        }

        public List<string> GetUserOperationsByUserId(int userId) {
            return m_teacherOperationRepository.GetAll().Where(t => t.TeacherId == userId && t.Enable)
                                                        .Select(t => t.OperationName).ToList();
        }

        public void SaveUserSubjectRight(IList<UserSubjectRight> rights) {
            foreach (UserSubjectRight right in rights) {
                var existed =
                    m_userSubjectService.GetAll()
                                        .FirstOrDefault(
                                            x =>
                                            x.FK_SubjectId == right.FK_SubjectId && x.FK_TeacherId == right.FK_TeacherId);
                if (existed != null) {
                    existed.Right = right.Right;
                } else {
                    m_userSubjectService.Insert(right);
                }
            }
            m_userSubjectService.Commit();
        }

        public void SaveUserOperation(IList<TeacherOperation> operations) {
            foreach (TeacherOperation operation in operations) {
                var existed = m_teacherOperationRepository.GetAll().FirstOrDefault(o => o.TeacherId == operation.TeacherId &&
                                                                                        o.OperationName == operation.OperationName);
                if (existed != null) {
                    existed.Enable = operation.Enable;
                } else {
                    m_teacherOperationRepository.Insert(operation);
                }
            }
            m_teacherOperationRepository.Commit();
        }

        /// <summary>
        /// Gets all Teacher.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <exception cref="NotAuthorizedUser"></exception>
        public Teacher GetById(int id) {
            if (UserService.CurrentUser == null) {
                throw new NotAuthorizedUser();
            }
            return m_repository.GetById((object)id);
        }

        #region CRUD
        public void Insert(Teacher entity) {
            m_repository.Insert(entity);
            m_repository.Commit();
        }

        public void Delete(int id) {
            var item = m_repository.GetById(id);
            if (item != null) {
                item.IsActive = false;
                m_repository.Update(item);
                m_repository.Commit();
            }
        }

        public void Update(Teacher entity) {
            if (entity.TeacherId > 0) {
                m_repository.Update(entity);
            } else {
                m_repository.Insert(entity);
            }

            m_repository.Commit();
        }
        #endregion

        public DbContext Context {
            get { return m_context; }
        }

        public void Save(Teacher entity) {
            if (entity.TeacherId > 0) {
                Update(entity);
            } else {
                Insert(entity);
            }

        }

        public void SaveAll(IEnumerable<Teacher> entities) {
            foreach (Teacher teacher in entities) {
                if (teacher.TeacherId > 0) {
                    m_repository.Update(teacher);
                } else {
                    m_repository.Insert(teacher);
                }
            }
            m_repository.Commit();
        }

        public void Delete(Teacher entity) {
            Delete(entity.TeacherId);
        }

        public List<Teacher> GetAll() {
            return m_repository.GetAll().Where(x => x.IsActive).ToList();
        }
    }
}
