using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qbg.Data
{
    public class QbgQueueUser
    {
        public QbgQueueUser()
        {
        }

        public QbgQueueUser(long qbgQueueId, QbgQueue qbgQueue, long userId, User user)
        {
            QbgQueueId = qbgQueueId;
            QbgQueue = qbgQueue;
            UserId = userId;
            User = user;
        }

        [Key]
        public long QbgQueueId { get; set; }
        public QbgQueue QbgQueue { get; set; }
        [Key]
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
