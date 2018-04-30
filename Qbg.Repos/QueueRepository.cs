using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Qbg.Data;
using Qbg.IRepos;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Qbg.MySqlEfRepos
{
    public class QueueRepository : GenericRepository<QbgQueue>, IQueueRepository
    {
        public QueueRepository(ApplicationContext context) : base(context)
        {
        }
       
        public Task<QbgQueue> GetQbgQueueAsync(long id)
        {
            var temp= base.entities
                .Include(p=>p.Queue)
                .ThenInclude(u=>u.User)
                
                .SingleOrDefaultAsync(p => p.Id == id);
            return temp;
               
        }
    }
}
