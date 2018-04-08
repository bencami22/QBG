using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qbg.WebAPI.Models.User.Request
{
    public class UserPost
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
