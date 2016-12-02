using Controller.Interfaces;
using Controller.Repositories;
using Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Services
{
    public class SchoolInfoService
    {
        IRepository<SchoolInfo> m_repository;
        public SchoolInfoService()
        {
            m_repository = new Repository<SchoolInfo>();
        }

        public void Save(SchoolInfo info)
        {
            if (info.SchoolInfoId > 0)
            {
                m_repository.Update(info);
            }
            else
            {
                m_repository.Insert(info);
            }
            m_repository.Commit();
        }

        public SchoolInfo GetSchoolInfo()
        {
            return m_repository.GetAll().FirstOrDefault();
        }
    }
}
