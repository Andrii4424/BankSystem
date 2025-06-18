using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace BankProject.Models.BankModels
{
    public class Bank
    {
        public int BankId { get; set; }

        public Dictionary<int, Card> BankCards { get; set; }     // Bank Cards List 

        public string BankName { get; set; }
        public double Rating { get; set; }
        public bool HasLicense { get; set; }
        public string BankFounder { get; set; }

        //Internal bank information
        public string BankDirector { get; set; }
        public double Capitalization { get; set; }
        public int EmployeesCount { get; set; }
        public int BlockedClientsCount { get; set; }
        public int ClientsCount { get; set; }

        public int ActiveClientsCount
        {
            get => ClientsCount - BlockedClientsCount;
        }

        public Bank() { BankCards = new Dictionary<int, Card>(); }

        public Bank(int id, string bankName, double rating, bool hasLicense, string bankFounder, string bankDirector,
            double capitalization, int employeesCount, int clientsCount, int blockedClientsCount)
        {
            BankId = id;
            BankName = bankName;
            Rating = rating;
            HasLicense = hasLicense;
            BankFounder = bankFounder;
            BankDirector = bankDirector;
            Capitalization = capitalization;
            EmployeesCount = employeesCount;
            ClientsCount = clientsCount;
            BlockedClientsCount = blockedClientsCount;
            BankCards = new Dictionary<int, Card>();

        }

        public void addBankCard(Card card)
        {
            BankCards.Add(card.CardId, card);
        }

        public void DeleteBankCard(int cardId)
        {
            BankCards.Remove(cardId);
        }
    }
}
