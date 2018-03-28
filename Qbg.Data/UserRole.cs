using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qbg.Data
{
    public class UserRole
    {
        public UserRole(User user, Role role)
        {
            this.User = user;
            this.Role = role;
            this.UserId = user.Id;
            this.RoleId = role.Id;
        }

        [Key]
        public long UserId { get; set; }
        public User User { get; set; }
        [Key]
        public long RoleId { get; set; }
        public Role Role { get; set; }

    }
}
