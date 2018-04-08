using Qbg.Data;
using Qbg.Data.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qbg.IRepos
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetAsync(long id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        void DeleteAsync(T entity);
        void SaveChangesAsync();
    }
}
