using BankDomainModels.PersonModels;
using BankProject.Models.BankModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDomainModels.WrapperModels
{
    public class BanksAndUsersAndEmployeesWrapper
    {
        public Bank Bank { get; set; }
        public List<User> Users { get; set; }
        public List<Employee> Employees { get; set; }
        public BanksAndUsersAndEmployeesWrapper() { }
        public BanksAndUsersAndEmployeesWrapper(Bank bank, List<User> users, List<Employee> employees)
        {
            Bank = bank;
            Users = users;
            Employees = employees;
        }
    }
}
