using System;
using System.Collections.Generic;
using System.Text;
using Qbg.Data.Bases;

namespace Qbg.Data
{
    public class QbgQueue : BaseEntity
    {
        public QbgQueue()
        {
        }

        public DateTime TimeStamp { get; set; }
        public ICollection<QbgQueueUser> Queue { get; set; }
    }
}
