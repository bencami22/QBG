using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qbg.Data;
using Qbg.IRepos;
using Qbg.IServices;

namespace Qbg.Services
{
    public class QueueService : IQueueService
    {
        private IGenericRepository<QbgQueue> queueRepository;

        public async Task<QbgQueue> InsertQueueAsync()
        {
            QbgQueue queue = new QbgQueue() { TimeStamp = DateTime.UtcNow };
            return await queueRepository.InsertAsync(queue);
        }

        public async void DeleteAsync(long id)
        {
            queueRepository.DeleteAsync(await GetQueueAsync(id));
        }

        public async Task<User> DequeueAsync(long id)
        {
            var queue = await GetQueueAsync(id);
            if (queue != null)
            {
                return queue.Queue?.Dequeue();
            }
            return null;
        }

        public async Task<bool> EnqueueAsync(long id, User user)
        {
            var queue = await GetQueueAsync(id);
            if (queue != null)
            {
                if (queue.Queue == null)
                {
                    queue.Queue = new Queue<User>();
                }
                queue.Queue.Enqueue(user);
                return true;
            }
            return false;
        }

        public async Task<QbgQueue> GetQueueAsync(long id)
        {
            return await queueRepository.GetAsync(id);
        }

        public IQueryable<QbgQueue> GetAll()
        {
            return queueRepository.GetAll();
        }
    }
}
