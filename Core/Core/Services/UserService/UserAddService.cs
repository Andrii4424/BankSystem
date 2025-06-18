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
    public class UserAddService : IUserAddService
    {
        private readonly IGenericRepository<UserEntity> _usersRepository;
        public readonly IGenericRepository<BankEntity> _bankRepository;
        private readonly ILogger<UserAddService> _logger;

        //Constructor
        public UserAddService(IGenericRepository<UserEntity> userRepository,
            IGenericRepository<BankEntity> bankRepsitory, ILogger<UserAddService> logger)
        {
            _usersRepository = userRepository;
            _bankRepository = bankRepsitory;
            _logger = logger;
        }

        //Adding
        public async Task AddUser(UserDto userDto)
        {
            if (!await _bankRepository.IsObjectIdExists(userDto.BankId))
            {
                _logger.LogWarning("AddUser: User with id: {BankId} doesnt exist", userDto.BankId);
                throw new ArgumentException("Bank with this id doesnt exist");
            }
            await _usersRepository.AddAsync(UserMapping.ToEntity(userDto));
            await _usersRepository.SaveAsync();
        }
    }
}
