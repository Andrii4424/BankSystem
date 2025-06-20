using ApplicationCore.Domain.RepositoryContracts;
using BankData.Repository;
using Core.Domain.Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class EmployeeRepository :GenericRepository<UserEntity>, IEmployeeRepository
    {
        private readonly DbSet<UserEntity> _dbSet;

        public EmployeeRepository(BankAppContext context) : base(context)
        {
            _dbSet = context.Set<UserEntity>();
        }

        public async Task<List<UserEntity>?> GetAllBankEmployeesList(int bankId)
        {
            return await _dbSet.Where(user => user.BankId == bankId && user.IsEmployed == true).ToListAsync();
        }
    }
}
