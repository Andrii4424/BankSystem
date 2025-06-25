using ApplicationCore.Core.Services.Mapping;
using ApplicationCore.Domain.RepositoryContracts;
using BankServicesContracts.RepositoryContracts;
using BankServicesContracts.ServicesContracts.UserServiceContracts;
using Core.Domain.Entities;
using DTO.PersonDto;
using Entities.BanksEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.UserService
{
    public class UserReadService: IUserReadService
    {
        private readonly IUserRepository _usersRepository;
        private readonly ILogger<UserReadService> _logger;
        private readonly IBankRepository _bankRepository;

        //Constructor
        public UserReadService(IUserRepository userRepository, 
            ILogger<UserReadService> logger, IBankRepository bankRepository)
        {
            _usersRepository = userRepository;
            _logger = logger;
            _bankRepository = bankRepository;
        }

        public async Task<List<UserDto>?> GetUsersList()
        {
            return await UserMapping.ToDtoList(await _usersRepository.GetAllValuesAsync() as List<UserEntity>);
        }

        public async Task<UserDto> GetUserById(Guid userId, Guid bankId)
        {
            UserEntity? user = await _usersRepository.GetValueByIdAsync(userId);
            if (user == null || user.BankId != bankId)
            {
                _logger.LogWarning("GetUserById: User with id: {UserId} doesnt exist in bank with id: " +
                    "{BankId}", userId, bankId);
                throw new ArgumentException("This user doesnt exist in this bank!");
            }
            return await UserMapping.ToDto(user); ;
        }

        public async Task<List<UserDto>?> GetUsersListByBankId(Guid bankId)
        {
            return await UserMapping.ToDtoList(await _usersRepository.GetUsersListByBankId(bankId));
        }

        public async Task<string> GetUsersBankName(Guid bankId)
        {
            return (await _bankRepository.GetValueByIdAsync(bankId)).BankName;
        }
    }
}
