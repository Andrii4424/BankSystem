using BankServicesContracts.RepositoryContracts;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.RepositoryContracts
{
    public interface IEmployeeRepository : IGenericRepository<UserEntity>
    {
        public Task<List<UserEntity>?> GetAllBankEmployeesList(int bankId);
    }
}
