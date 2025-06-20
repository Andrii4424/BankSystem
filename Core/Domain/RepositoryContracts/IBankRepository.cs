using BankServicesContracts.RepositoryContracts;
using Entities.BanksEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.RepositoryContracts
{
    public interface IBankRepository :IGenericRepository<BankEntity>
    {
    }
}
