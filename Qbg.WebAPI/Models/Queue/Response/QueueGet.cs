using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qbg.WebAPI.Models.Queue.Response
{
    public class QueueGet
    {
        public long Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public Queue<string> Queue { get; set; }
    }
}
