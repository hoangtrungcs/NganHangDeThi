using System.Linq;

namespace Controller.Interfaces {
    public interface IRepository<TEntity> where TEntity : class {
        IQueryable<TEntity> GetAll();
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Commit();
    }
}
