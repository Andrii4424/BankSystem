using System.ComponentModel.DataAnnotations;

namespace BankProject.Models.BankModels
{
    public class Card
    {
        public int CardId { get; init; }

        public string CardName { get; init; }

        public string CardType { get; set; }

        public string CardLevel { get; set; } // must be premium or usual

        public double ValidityPeriod { get; set; }

        public int MaxCreditLimit { get; set; }

        public string PaymentSystem { get; set; }

        public Card() { }

        public Card(int id, string cardType, string cardLevel, string cardName, double validityPeriod, int maxCreditLimit, string paymentSystem)
        {
            CardId = id;
            CardName = cardName;
            CardType = cardType;
            CardLevel = cardLevel;
            ValidityPeriod = validityPeriod;
            MaxCreditLimit = maxCreditLimit;
            PaymentSystem = paymentSystem;
        }
    }
}
