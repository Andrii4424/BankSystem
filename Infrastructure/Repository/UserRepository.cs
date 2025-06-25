using ApplicationCore.Domain.RepositoryContracts;
using BankServicesContracts.RepositoryContracts;
using Core.Domain.Entities;
using Entities.BanksEntities;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankData.Repository;

namespace Infrastructure.Repository
{
    public class UserRepository :GenericRepository<UserEntity>, IUserRepository
    {
        private readonly DbSet<UserEntity> _dbSet;

        public UserRepository(BankAppContext context) : base(context)
        {
            _dbSet = context.Set<UserEntity>();
        }

        public async Task<List<UserEntity>?> GetUsersListByBankId(Guid bankId)
        {
            return await _dbSet.Where(user => user.BankId == bankId).ToListAsync();
        }
    }
}
