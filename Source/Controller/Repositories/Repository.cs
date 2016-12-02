using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Controller.Interfaces;
using Model;
using Model.POCO;

namespace Controller.Repositories {
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
        private DbContext m_context;
        public Repository()
            : this(new NganHangEntities()) {
            
        } 
        public Repository(DbContext context) {
            m_context = context;
        }
        private IDbSet<TEntity> Entities {
            get { return this.m_context.Set<TEntity>(); }
        }


        public IQueryable<TEntity> GetAll() {
            return Entities.AsQueryable();
        }

        public TEntity GetById(object id) {
            return Entities.Find(id);
        }

        public void Insert(TEntity entity) {
            Entities.Add(entity);
        }

        public void Update(TEntity entity) {
            m_context.Entry(entity).CurrentValues.SetValues(entity); 
        }

        public void Delete(TEntity entity) {
            //Entities.Remove(entity);
            Update(entity);
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                if (this.m_context != null) {
                    this.m_context.Dispose();
                    this.m_context = null;
                }
            }
        }

        public void Commit() {
            m_context.SaveChanges();
        }
    }
}
