using BankServicesContracts.RepositoryContracts;
using BankServicesContracts.ServicesContracts.UserServiceContracts;
using DTO.PersonDto;
using Entities.BanksEntities;
using Entities.PersonsEntites;
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
        private readonly IGenericRepository<UserEntity> _usersRepository;
        private readonly ILogger<UserReadService> _logger;
        private readonly IGenericRepository<BankEntity> _bankRepository;

        //Constructor
        public UserReadService(IGenericRepository<UserEntity> userRepository, 
            ILogger<UserReadService> logger, IGenericRepository<BankEntity> bankRepository)
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
            List<UserEntity>? allUsersList = await GetUsersList();
            List<UserEntity>? bankUsers = allUsersList?
                .Where(u => u.BankId == bankId)
                .ToList();
            return bankUsers;
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
