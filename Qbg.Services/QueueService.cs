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
        private IUserService userService;

        public QueueService(IGenericRepository<QbgQueue> queueRepository, IUserService userService)
        {
            this.queueRepository = queueRepository;
            this.userService = userService;
        }

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
            if ((queue?.Queue) != null)
            {
                var userId = queue.Queue.Dequeue().UserId;
                await queueRepository.UpdateAsync(queue);
                return await userService.GetUserAsync(userId);
            }
            return null;
        }

        public async Task<bool> EnqueueAsync(long id, string userName)
        {
            var user = await userService.GetUserAsync(userName);
            var queue = await GetQueueAsync(id);
            if (queue != null && user != null)
            {
                if (queue.Queue == null)
                {
                    queue.Queue = new Queue<QbgQueueUser>();
                }
                queue.Queue.Enqueue(new QbgQueueUser { QbgQueueId = id, UserId = user.Id });
                await queueRepository.UpdateAsync(queue);
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
