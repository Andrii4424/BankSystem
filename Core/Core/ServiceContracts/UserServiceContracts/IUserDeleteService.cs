using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.ServicesContracts.UserServiceContracts
{
    public interface IUserDeleteService
    {
        public Task DeleteUser(Guid userId);
    }
}
