using System;
using System.Collections.Generic;
using System.Text;
using Qbg.IRepos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Qbg.Data;
using Qbg.Data.Bases;
using System.Threading.Tasks;

namespace Qbg.MySqlEfRepos
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext dbContext;
        protected DbSet<T> entities;
        string errorMessage = string.Empty;

        public GenericRepository(ApplicationContext context)
        {
            this.dbContext = context;
            entities = context.Set<T>();
        }

        public async Task<T> GetAsync(long id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return entities.AsQueryable<T>();
        }

        public async Task<T> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            await dbContext.SaveChangesAsync();
            
            return entity;
        }

        public async void SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async void DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
