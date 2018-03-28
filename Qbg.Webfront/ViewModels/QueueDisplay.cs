using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qbg.Webfront.ViewModels
{
    public class QueueDisplay
    {
        public DateTime CurrentTime { get; set; }
        public string Serving { get; set; }
        public List<string> NextUpList { get; set; }
    }
}
