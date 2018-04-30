using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qbg.ngWebApp.Models.User.Response
{
    public class UserGet
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
