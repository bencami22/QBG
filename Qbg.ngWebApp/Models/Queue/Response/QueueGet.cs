using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qbg.ngWebApp.Models.Queue.Response
{
    public struct QueueGet
    {
        public long Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<QueueEntry> Queue { get; set; }
    }

    public struct QueueEntry
    {
        public string Username { get; set; }
        public DateTime TimeStamp { get; set; }
    }

}
