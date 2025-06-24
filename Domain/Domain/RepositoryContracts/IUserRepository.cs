using BankServicesContracts.RepositoryContracts;
using Core.Domain.Entities;

namespace ApplicationCore.Domain.RepositoryContracts
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        public Task<List<UserEntity>?> GetUsersListByBankId(int bankId);
    }
}
