using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qbg.WebAPI.Models.Queue.Request
{
    public class QueueEnqueue
    {
        public long Id { get; set; }
        public string UserName { get; set; }
    }
}
