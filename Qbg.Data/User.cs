using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Qbg.Data.Bases;

namespace Qbg.Data
{
    public class User : BaseEntity
    {
        public User() { }

        public User(string username, string password, string email, List<RoleEnum> roles)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.UserRoles = new List<UserRole>();
            roles.ForEach(p => this.UserRoles.Add(new UserRole(this, new Role(p))));
        }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        public Role AssignRole(Role role)
        {
            if(this.UserRoles==null)
            {
                UserRoles = new List<UserRole>();
            }
            this.UserRoles.Add(new UserRole(this, role));
            return role;
        }
    }
}
