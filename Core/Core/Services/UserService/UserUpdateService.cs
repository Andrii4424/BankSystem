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
    public class UserUpdateService : IUserUpdateService
    {
        private readonly IGenericRepository<UserEntity> _usersRepository;
        private readonly ILogger<UserUpdateService> _logger;

        public UserUpdateService(IGenericRepository<UserEntity> userRepository, ILogger<UserUpdateService> logger)
        {
            _usersRepository = userRepository;
            _logger = logger;
        }

        public async Task UpdateUser(int userId, UserDto userDto)
        {
            UserEntity? user = await _usersRepository.GetValueByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("UpdateUser: User with id: {UserId} doesnt exist in this bank", userId);
                throw new ArgumentException("This user doesnt exist");
            }
            else if (user.BankId != userDto.BankId)
            {
                _logger.LogWarning("GetUserById: User with id: {UserId} doesnt exist in bank with id: " +
                    "{BankId}", userId, user.BankId);
                throw new ArgumentException("Users bank id before change and after are not the same");
            }
            user.FinancalNumber = userDto.FinancalNumber;
            user.Email = userDto.Email;
            user.FullName = userDto.FullName;
            user.Age = userDto.Age;
            user.Nationality = userDto.Nationality;
            user.Gender = userDto.Gender;
            user.IsEmployed = userDto.IsEmployed;
            user.JobTitle = userDto.JobTitle;
            _usersRepository.UpdateObject(user);
            await _usersRepository.SaveAsync();
        }
    }
}
