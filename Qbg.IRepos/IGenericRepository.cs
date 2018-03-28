using Qbg.Data;
using Qbg.Data.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qbg.IRepos
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        T Get(long id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
