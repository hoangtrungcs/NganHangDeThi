using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common;
using Controller.Interfaces;
using Controller.Repositories;
using Model;
using Model.Exceptions;
using Model.POCO;

namespace Controller.Services {
    public class SubjectsService : IService<Subject> {
        private IRepository<Subject> m_repository;
        private DbContext m_context;
        public SubjectsService()
            : this(new NganHangEntities()) {
        }
        public SubjectsService(DbContext context) {
            m_context = context;
            m_repository = new Repository<Subject>(context);
        }
        /// <summary>
        /// Gets all subject.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotAuthorizedUser"></exception>
        public List<Subject> GetAllSubject() {
            if (UserService.CurrentUser == null) {
                throw new NotAuthorizedUser();
            }
            var listSubjectIds = UserService.CurrentUser.GetAllAvailableSubjectIds();
            return UserService.CurrentUser.HasRole(UserRole.Administrator) ? m_repository.GetAll().Where(x => !x.IsDel.HasValue || !x.IsDel.Value).ToList() :
                m_repository.GetAll().Where(x => listSubjectIds.Contains(x.SubjectId) && (!x.IsDel.HasValue || !x.IsDel.Value)).ToList();
        }
        /// <summary>
        /// Gets all Teacher.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <exception cref="NotAuthorizedUser"></exception>
        public Subject GetById(int id) {
            if (UserService.CurrentUser == null) {
                throw new NotAuthorizedUser();
            }
            return m_repository.GetById((object)id);
        }
        public List<Subject> GetSubjectsBySubjectGuid(IEnumerable<Guid> guids) {
            return m_repository.GetAll().Where(x => guids.Contains(x.SubjectGuid)).ToList();
        }
        #region CRUD
        public void Insert(Subject entity) {
            m_repository.Insert(entity);
            m_repository.Commit();
        }

        public void Update(Subject entity) {
            m_repository.Update(entity);
            m_repository.Commit();
        }

        public void SaveAll(IEnumerable<Subject> subjects) {
            foreach (var subject in subjects) {
                if (subject.SubjectId <= 0) {
                    m_repository.Insert(subject);
                } else {
                    m_repository.Update(subject);
                }
            }
            m_repository.Commit();
        }
        #endregion


        public DbContext Context {
            get { return m_context; }
        }

        public void Save(Subject entity) {
            if (entity.SubjectId > 0) {
                m_repository.Update(entity);
            } else {
                m_repository.Insert(entity);
            }
            m_repository.Commit();
        }

        public void Delete(Subject entity) {
            entity.IsDel = true;
            m_repository.Update(entity);
            m_repository.Commit();
        }

        public List<Subject> GetAll() {
            return m_repository.GetAll().Where(x => !x.IsDel.HasValue || !x.IsDel.Value).ToList();
        }
    }
}
