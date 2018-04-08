using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qbg.Data;

namespace Qbg.IServices
{
    public interface IQueueService
    {
        Task<QbgQueue> InsertQueueAsync();
        Task<QbgQueue> GetQueueAsync(long id);
        IQueryable<QbgQueue> GetAll();
        Task<bool> EnqueueAsync(long id, User user);
        Task<User> DequeueAsync(long id);
        void DeleteAsync(long id);

    }
}
