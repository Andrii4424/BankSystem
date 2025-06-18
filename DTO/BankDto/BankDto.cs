using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BankDto
{
    public class BankDto : IValidatableObject
    {
        [Required(ErrorMessage = "{0} has to be provided")]
        [StringLength(40, ErrorMessage = "{0} must be up to {1} characters")]
        [Display(Name = "Bank name")]
        public string BankName { get; set; }

        [Range(1.0, 5.0, ErrorMessage = "{0} must be between {1} and {2}")]
        [Display(Name = "Bank Rating")]
        public double Rating { get; set; }

        [Required(ErrorMessage = "{0} has to be provided")]
        [Display(Name = "Has License")]
        public bool HasLicense { get; set; }

        [Required(ErrorMessage = "{0} has to be provided")]
        [StringLength(40, ErrorMessage = "{0} must be up to {1} characters")]
        [Display(Name = "Bank Founder")]
        public string BankFounder { get; set; }

        [Required(ErrorMessage = "{0} has to be provided")]
        [StringLength(40, ErrorMessage = "{0} must be up to {1} characters")]
        [Display(Name = "Bank Director")]
        public string BankDirector { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "{0} id cant be lesser than 0 or empty")]
        [Display(Name = "Capitalization")]
        public double Capitalization { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "{0} id cant be lesser than 0 or empty")]
        [Display(Name = "Employees Count")]
        public int EmployeesCount { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "{0} id cant be lesser than 0 or empty")]
        [Display(Name = "Blocked Clients Count")]
        public int BlockedClientsCount { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "{0} id cant be lesser than 0 or empty")]
        [Display(Name = "Clients Count")]
        public int ClientsCount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EmployeesCount > ClientsCount - BlockedClientsCount) { yield return new ValidationResult("Count of employees cant be more than count of users"); }
            if (ClientsCount < BlockedClientsCount) { yield return new ValidationResult("Count of blocked clients cant be more than count of users"); }
        }
    }

}
