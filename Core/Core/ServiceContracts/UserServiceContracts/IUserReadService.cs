using Core.Domain.Entities;
using DTO.PersonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.ServicesContracts.UserServiceContracts
{
    public interface IUserReadService
    {
        public Task<List<UserDto>?> GetUsersList();

        public Task<UserDto> GetUserById(Guid userId, Guid bankId);

        public Task<List<UserDto>?> GetUsersListByBankId(Guid bankId);

        public Task<string> GetUsersBankName(Guid bankId);
    }
}
