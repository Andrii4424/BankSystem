using Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BanksEntities
{
    public class CardEntity:IHasId
    {
        [Key]
        public Guid Id { get; init; } = Guid.NewGuid();

        public Guid BankId { get; init; }

        [ForeignKey("BankId")]
        public BankEntity Bank { get; set; }

        [StringLength(40)]
        public string CardName { get; set; }

        [StringLength(10)]
        public string CardType { get; set; }

        [StringLength(10)]
        public string CardLevel { get; set; }

        public double ValidityPeriod { get; set; }

        public int MaxCreditLimit { get; set; }

        public string PaymentSystem { get; set; }

        public CardEntity() { }

        public CardEntity(Guid bankId, string cardType, string cardLevel, string cardName, double validityPeriod, int maxCreditLimit, string paymentSystem)
        {
            BankId = bankId;
            CardName = cardName;
            CardType = cardType;
            CardLevel = cardLevel;
            ValidityPeriod = validityPeriod;
            MaxCreditLimit = maxCreditLimit;
            PaymentSystem = paymentSystem;
        }
    }
}
