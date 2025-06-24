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

        public async Task<List<UserEntity>?> GetUsersList()
        {
            return await _usersRepository.GetAllValuesAsync() as List<UserEntity>;
        }

        public async Task<UserEntity> GetUserById(int userId, int bankId)
        {
            UserEntity? user = await _usersRepository.GetValueByIdAsync(userId);
            if (user == null || user.BankId != bankId)
            {
                _logger.LogWarning("GetUserById: User with id: {UserId} doesnt exist in bank with id: " +
                    "{BankId}", userId, bankId);
                throw new ArgumentException("This user doesnt exist in this bank!");
            }
            return user;
        }

        public async Task<List<UserEntity>?> GetUsersListByBankId(int bankId)
        {
            return await _usersRepository.GetUsersListByBankId(bankId);
        }
        public async Task<UserDto> GetUserDto(int userId)
        {
            UserEntity? user = await _usersRepository.GetValueByIdAsync(userId);
            if(user == null) throw new ArgumentException("This user doesnt exist in this bank!");
            return await UserMapping.ToDto(user);
        }

        public async Task<string> GetUsersBankName(int bankId)
        {
            return (await _bankRepository.GetValueByIdAsync(bankId)).BankName;
        }
    }
}
