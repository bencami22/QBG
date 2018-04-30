using System.Collections.Generic;

namespace Qbg.ngWebApp.Models.User.Response
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
