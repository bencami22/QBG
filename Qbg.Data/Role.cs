using Qbg.Data.Attributes;
using Qbg.Data.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Qbg.Data
{
    public enum RoleEnum : int
    {
        [Description("Somebody in a queue")]
        Queuer = 1,
        [Description("Somebody serving and in control of a queue.")]
        Server = 2,
    }
    
    public class Role : EnumBase<RoleEnum>
    {
        public Role(RoleEnum roleEnum)
        {
            base.Id = (int)roleEnum;
            base.Name = roleEnum.ToString();
            base.Description = roleEnum.ToString();
        }

        protected Role() { } //For EF

        public static implicit operator Role(RoleEnum roleEnum) => new Role(roleEnum);

        public static implicit operator RoleEnum(Role role) => (RoleEnum)role.Id;

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
