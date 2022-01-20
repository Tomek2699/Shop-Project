using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Błędny Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Błędne hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}
