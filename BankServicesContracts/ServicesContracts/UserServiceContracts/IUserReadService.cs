using DTO.PersonDto;
using Entities.PersonsEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.ServicesContracts.UserServiceContracts
{
    public interface IUserReadService
    {
        public Task<List<UserEntity>?> GetUsersList();

        public Task<UserEntity> GetUserById(int userId, int bankId);

        public Task<List<UserEntity>?> GetUsersListByBankId(int bankId);

        public Task<string> GetUsersBankName(int bankId);

        public Task<UserDto> GetUserDto(int userId);
    }
}
