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
    public class DepartmentService : IService<Department> {
        private IRepository<Department> m_repository;
        private DbContext m_context;
        public DepartmentService()
            : this(new NganHangEntities()) {
        }
        public DepartmentService(DbContext context) {
            m_context = context;
            m_repository = new Repository<Department>(context);
        }
        /// <summary>
        /// Gets all department.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotAuthorizedUser"></exception>
        public IList<Department> GetAllDepartment() {
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
        public Department GetDepartmentById(long id) {
            if (UserService.CurrentUser == null) {
                throw new NotAuthorizedUser();
            }
            return m_repository.GetById((object)id);
        }

        public void Delete(long id) {
            var item = m_repository.GetById(id);
            if (item != null) {
                m_repository.Delete(item);
                m_repository.Commit();
            }
        }

        public DbContext Context {
            get { return m_context; }
        }

        public void Save(Department entity) {
            if (entity.DepartmentId > 0) {
                m_repository.Update(entity);
            } else {
                m_repository.Insert(entity);
            }
            m_repository.Commit();
        }

        public void SaveAll(IEnumerable<Department> entities) {
            foreach (var entity in entities) {
                if (entity.DepartmentId > 0) {
                    m_repository.Update(entity);
                } else {
                    m_repository.Insert(entity);
                }
            }
            m_repository.Commit();
        }

        public void Update(Department entity) {
            if (entity.DepartmentId > 0) {
                m_repository.Update(entity);
            } else {
                m_repository.Insert(entity);
            }
            m_repository.Commit();
        }

        public void Delete(Department entity) {
          
            if (entity != null)
            {
                m_repository.Delete(entity);
                m_repository.Commit();
            }
           // throw new NotImplementedException();
        }

        public List<Department> GetAll() {
            return m_repository.GetAll().ToList();
        }
    }
}
