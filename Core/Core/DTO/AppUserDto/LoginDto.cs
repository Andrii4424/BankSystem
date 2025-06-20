using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Core.DTO.AppUserDto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "{0} has to be provided")]
        [EmailAddress(ErrorMessage = "{0} has to be in email format")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} has to be provided")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
