using DTO.PersonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.ServicesContracts.UserServiceContracts
{
    public interface IUserUpdateService
    {
        public Task UpdateUser(int userId, UserDto userDto);
    }
}
