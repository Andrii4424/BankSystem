using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.BankDto
{
    public class CardDto : IValidatableObject
    {
        [Range(0, int.MaxValue, ErrorMessage ="{0} cant be lesser than 0 or empty")]
        [Display(Name ="Bank id")]
        public int BankId { get; init; }

        [Required(ErrorMessage = "{0} has to be provided")]
        [StringLength(40, ErrorMessage = "{0} must be up to {1} characters")]
        [Display(Name = "Card name")]
        public string CardName { get; set; }

        public string CardType { get; set; }

        public string CardLevel { get; set; } // must be premium or usual

        [Range(1, 99, ErrorMessage = "{0} must be between {1} and {2}")]
        [Display(Name = "Validity Period")]
        public double ValidityPeriod { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "{0} cant be lesser than 0 or empty")]
        [Display(Name = "Max Credit Limit")]
        public int MaxCreditLimit { get; set; }


        [Required(ErrorMessage = "{0} has to be provided")]
        [Display(Name = "Payment System")]
        public string PaymentSystem { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CardType.ToUpper() != "DEBIT" && CardType.ToUpper() != "CREDIT") yield return new ValidationResult("Card must be credit or debit");
            if (CardLevel.ToUpper() != "PREMIUM" && CardLevel.ToUpper() != "USUAL") yield return new ValidationResult("Card must be premium or usual");
            if (ValidityPeriod % 0.5 != 0) yield return new ValidationResult("The card validity period must be a multiple of 1 year or half a year (0.5)");
            if (MaxCreditLimit > 0 && CardType.ToUpper() == "DEBIT") yield return new ValidationResult("Debit card cant have credit limit");
        }
    }
}
