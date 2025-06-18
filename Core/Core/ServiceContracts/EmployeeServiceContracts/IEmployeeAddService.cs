using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.ServicesContracts.EmployeeServiceContracts
{
    public interface IEmployeeAddService
    {
        public Task AddEmployee(int bankId, int userId, string jobTitle);
    }
}
