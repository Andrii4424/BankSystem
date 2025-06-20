using ApplicationCore.Domain.RepositoryContracts;
using BankData.Repository;
using Entities;
using Entities.BanksEntities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository
{
    public class BankRepository : GenericRepository<BankEntity>, IBankRepository
    {
        public BankRepository(BankAppContext dbContext) : base(dbContext) { }
    }
}
