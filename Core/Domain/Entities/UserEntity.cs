using Abstractions;
using Entities.BanksEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class UserEntity : IHasId
    {
        [Key]
        public int Id { get; init; }

        public int BankId { get; init; }

        [ForeignKey("BankId")]
        public BankEntity Bank { get; init; }

        [StringLength(20)]
        public string FinancalNumber { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(40)]
        public string FullName { get; set; }

        public int Age { get; set; }

        [StringLength(20)]
        public string Nationality { get; set; }

        public string Gender { get; set; }

        //Employee info
        public bool IsEmployed { get; set; }

        //Nullable values(employee values)
        [StringLength(80)]
        public string? JobTitle { get; set; }

        public UserEntity() { }

        public UserEntity(int bankId, string financalNumber, string email, string fullName, int age, string nationality, string gender,
            bool isEmployeed, string? jobTitle)
        {
            BankId = bankId;
            FinancalNumber = financalNumber;
            Email = email;
            FullName = fullName;
            Age = age;
            Nationality = nationality;
            Gender = gender;
            IsEmployed = isEmployeed;
        }
    }
}
