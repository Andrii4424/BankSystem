using Abstractions;
using Core.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BanksEntities
{
    public class BankEntity :IHasId
    {
        [Key]
        public int Id { get; init; }

        [StringLength(40)]
        public string BankName { get; set; }

        public double Rating { get; set; }

        public bool HasLicense { get; set; }

        [StringLength(40)]
        public string BankFounder { get; set; }

        //Internal bank information
        [StringLength(40)]
        public string BankDirector { get; set; }

        public double Capitalization { get; set; }

        public int EmployeesCount { get; set; }

        public int BlockedClientsCount { get; set; }

        public int ClientsCount { get; set; }

        [NotMapped]
        public int ActiveClientsCount
        {
            get => ClientsCount - BlockedClientsCount;
        }

        //Child elements
        public ICollection<CardEntity> Cards { get; set; }

        public ICollection<UserEntity> Users { get; set; }

        public BankEntity() { 
            Users = new List<UserEntity>();
            Cards = new List<CardEntity>();
        }

        public BankEntity(string bankName, double rating, bool hasLicense, string bankFounder, string bankDirector,
            double capitalization, int employeesCount, int clientsCount, int blockedClientsCount)
        {
            BankName = bankName;
            Rating = rating;
            HasLicense = hasLicense;
            BankFounder = bankFounder;
            BankDirector = bankDirector;
            Capitalization = capitalization;
            EmployeesCount = employeesCount;
            ClientsCount = clientsCount;
            BlockedClientsCount = blockedClientsCount;
            Users = new List<UserEntity>();
            Cards = new List<CardEntity>();
        }
    }
}
