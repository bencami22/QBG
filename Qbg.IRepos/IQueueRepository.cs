using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Qbg.Data;
namespace Qbg.IRepos
{
    public interface IQueueRepository : IGenericRepository<QbgQueue>
    {
        Task<QbgQueue> GetQbgQueueAsync(long id);
    }
}
