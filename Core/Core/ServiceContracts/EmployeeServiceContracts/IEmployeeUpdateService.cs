using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.ServicesContracts.EmployeeServiceContracts
{
    public interface IEmployeeUpdateService
    {
        public Task UpdateEmployee(int userId, string jobTitle);
    }
}
