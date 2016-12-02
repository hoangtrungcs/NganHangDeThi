using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Interfaces;
using Controller.Repositories;
using Model.Exceptions;
using Model.POCO;

namespace Controller.Services
{
    public class ClassService : IService<LopHoc>
    {
        #region Properties
        private IRepository<LopHoc> _repository;
        private readonly DbContext _context;

        public ClassService()
            : this(new NganHangEntities())
        {
        }

        public ClassService(DbContext context)
        {
            _context = context;
            _repository = new Repository<LopHoc>(context);
        }
        #endregion

        public System.Data.Entity.DbContext Context
        {
            get { return _context; }
        }

        public void Save(LopHoc entity)
        {
            if (entity.ClassId > 0)
            {
                _repository.Update(entity);
            }
            else
            {
                _repository.Insert(entity);
            }
            _repository.Commit();
        }

        public void SaveAll(IEnumerable<LopHoc> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.ClassId > 0)
                {
                    _repository.Update(entity);
                }
                else
                {
                    _repository.Insert(entity);
                }
            }
            _repository.Commit();
        }

        public void Update(LopHoc entity)
        {
            if (entity.ClassId > 0)
            {
                _repository.Update(entity);
            }
            else
            {
                _repository.Insert(entity);
            }
            _repository.Commit();
        }

        public void Delete(LopHoc entity)
        {
            if (entity != null)
            {
                _repository.Delete(entity);
                _repository.Commit();
            }
           // throw new NotImplementedException();
        }

        public List<LopHoc> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        /// <summary>
        /// Gets all class.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotAuthorizedUser"></exception>
        public IList<LopHoc> GetAllClass()
        {
            if (UserService.CurrentUser == null)
            {
                throw new NotAuthorizedUser();
            }
            return _repository.GetAll().ToList();
        }
    }
}
