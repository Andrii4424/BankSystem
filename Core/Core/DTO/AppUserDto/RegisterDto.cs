using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Core.DTO.AppUserDto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "{0} has to be provided")]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="{0} has to be provided")]
        [EmailAddress(ErrorMessage ="{0} has to be in email format")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} has to be provided")]
        [Phone(ErrorMessage ="{0} has to be in phone format")]
        [Display(Name ="Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} has to be provided")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} has to be provided")]
        [Compare("Password", ErrorMessage = "{0} and password must match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
