using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Interfaces;
using Controller.Repositories;
using Model;

namespace Controller.Services {
    public abstract class BaseService<T> : IService<T> where T : BaseEntity {
        private DbContext m_context;
        protected IRepository<T> m_repository;
        public BaseService() {
            m_repository = new Repository<T>();
        }
        public BaseService(DbContext context) {
            m_context = context;
            m_repository = new Repository<T>(context);
        }
        public void Save(T entity) {
            m_repository.Insert(entity);
        }

        public abstract void SaveAll(IEnumerable<T> entities);

        public virtual void Delete(T entity) {
            m_repository.Delete(entity);
        }

        public virtual List<T> GetAll() {
            return GetAllQueryable().ToList();
        }

        protected IQueryable<T> GetAllQueryable() {
            return m_repository.GetAll();
        } 
        public void Update(T entity) {
            m_repository.Update(entity);
            
        }

        public DbContext Context {
            get { return m_context; }
        }
    }
}
