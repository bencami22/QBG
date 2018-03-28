using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Qbg.Data;

namespace Qbg.Webfront.ViewModels
{
    public class UserLogin
    {
        public List<RoleEnum> RoleTypesList { get; set; }

        [Required]
        public RoleEnum SelectedRoleType { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }        
    }
}
