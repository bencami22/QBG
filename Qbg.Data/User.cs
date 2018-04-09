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
        }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<QbgQueueUser> QbgQueues { get; set; }
    }
}
