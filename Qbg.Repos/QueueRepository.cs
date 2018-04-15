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
            return base.entities.Include(queue => queue.Queue).SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
