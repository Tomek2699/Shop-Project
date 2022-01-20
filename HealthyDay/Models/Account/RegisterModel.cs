using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyDay.Models.Account
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Proszę podać Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Proszę podać Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Hasło i potwierdzenie hasła różnią się od siebie")]
        public string ConfirmPassword { get; set; }
    }
}
