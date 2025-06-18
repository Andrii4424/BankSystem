using BankServicesContracts.RepositoryContracts;
using BankServicesContracts.ServicesContracts.UserServiceContracts;
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
    public class UserDeleteService : IUserDeleteService
    {
        private readonly IGenericRepository<UserEntity> _usersRepository;

        public UserDeleteService(IGenericRepository<UserEntity> userRepository)
        {
            _usersRepository = userRepository;
        }

        public async Task DeleteUser(int userId)
        {
            UserEntity? user = await _usersRepository.GetValueByIdAsync(userId);
            if (user != null) { _usersRepository.DeleteElement(user); }
            await _usersRepository.SaveAsync();
        }
    }
}
