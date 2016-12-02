using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace Controller.Interfaces {
    public interface IService<T> where T : BaseEntity {
        DbContext Context { get; }
        void Save(T entity);
        void SaveAll(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
    }
}
