using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Account.Role
{
    public class RoleModel
    {
        public RoleModel()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Nazwa roli jest wymagana")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
