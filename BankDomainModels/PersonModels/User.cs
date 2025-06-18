using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankDomainModels.PersonModels
{
    public class User : IPerson
    {
        public int Id { get; init; }

        public int BankId { get; set; }

        public string FinancalNumber { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public virtual int Age { get; set; }

        public string Nationality { get; set; }

        public string Gender { get; set; }

        //constructors
        public User() { }

        public User(int id, int bankId, string financalNumber, string email, string fullName, int age, string nationality, string gender)
        {
            Id = id;
            BankId = bankId;
            FinancalNumber = financalNumber;
            Email = email;
            FullName = fullName;
            Age = age;
            Gender = gender;
            Nationality = nationality;
        }


        //Overiding methods
        public void ChangeFinancalNumber(string newFinancalNumber)
        {
            FinancalNumber = newFinancalNumber;
        }

        public void CreateCard()
        {

        }
        public void DeleteCard()
        {

        }
    }
}
