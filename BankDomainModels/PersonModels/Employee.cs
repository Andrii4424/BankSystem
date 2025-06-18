using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDomainModels.PersonModels
{
    public class Employee : User
    {
        public int EmployeeId { get; init; }

        public override int Age { get; set; }

        public string JobTitle { get; set; }

        // constructor
        public Employee() { }

        public Employee(int userId, int bankId, int employeeId, string financalNumber, string email, string fullName, int age, string nationality, string gender, string jobTitle)
            : base(userId, bankId, financalNumber, email, fullName, age, nationality, gender)
        {
            EmployeeId = employeeId;
            JobTitle = jobTitle;
        }
    }
}
