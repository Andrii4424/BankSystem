﻿using ApplicationCore.Domain.RepositoryContracts;
using BankServicesContracts.RepositoryContracts;
using BankServicesContracts.ServicesContracts.UserServiceContracts;
using Core.Domain.Entities;
using Entities.BanksEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.UserService
{
    public class UserDeleteService : IUserDeleteService
    {
        private readonly IUserRepository _usersRepository;

        public UserDeleteService(IUserRepository userRepository)
        {
            _usersRepository = userRepository;
        }

        public async Task DeleteUser(Guid userId)
        {
            UserEntity? user = await _usersRepository.GetValueByIdAsync(userId);
            if (user != null) { _usersRepository.DeleteElement(user); }
            await _usersRepository.SaveAsync();
        }
    }
}
