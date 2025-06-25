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
        public Task<List<UserEntity>?> GetUsersList();

        public Task<UserEntity> GetUserById(Guid userId, Guid bankId);

        public Task<List<UserEntity>?> GetUsersListByBankId(Guid bankId);

        public Task<string> GetUsersBankName(Guid bankId);

        public Task<UserDto> GetUserDto(Guid userId);
    }
}
