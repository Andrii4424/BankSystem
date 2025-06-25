using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.PersonDto
{
    public class UserDto : IValidatableObject
    {
        [Required(ErrorMessage = "{0} has to be provided")]
        [Display(Name = "Bank id")]
        public Guid BankId { get; init; }

        [Required(ErrorMessage = "{0} has to be provided")]
        [Phone(ErrorMessage = "Please enter a valid {0}")]
        [StringLength(20, ErrorMessage = "{0} must be up to {1} characters")]
        [Display(Name = "Financal number")]
        public string FinancalNumber { get; set; }

        [Required(ErrorMessage = "{0} has to be provided")]
        [EmailAddress(ErrorMessage = "Please enter a valid {0}")]
        [StringLength(40, ErrorMessage = "{0} must be up to {1} characters")]
        [Display(Name = "email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} has to be provided")]
        [StringLength(40, ErrorMessage = "{0} must be up to {1} characters")]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Range(14, 140, ErrorMessage = "{0} must be between {1} and {2}")]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "{0} has to be provided")]
        [StringLength(20, ErrorMessage = "{0} must be up to {1} characters")]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "{0} has to be provided")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        //Employee info
        [Required(ErrorMessage = "{0} has to be provided")]
        [Display(Name = "Is Employed")]
        public bool IsEmployed { get; set; }

        //Nullable values(employee values)
        [StringLength(80, ErrorMessage = "{0} must be up to {1} characters")]
        [Display(Name = "Job Title")]
        public string? JobTitle { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Gender.ToUpper() != "M" && Gender.ToUpper() != "F") { yield return new ValidationResult("Gender must be male or Female!"); }
            if(IsEmployed==true && Age < 18) { yield return new ValidationResult("Employees age must be 18 or higher"); }
        }
    }
}
