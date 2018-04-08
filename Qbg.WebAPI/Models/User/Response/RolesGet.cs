using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Qbg.Data;

namespace Qbg.WebAPI.Models.User.Response
{
    public class RolesGet
    {
        public List<RoleGet> Roles { get; set; }
    }

    public class RoleGet
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
