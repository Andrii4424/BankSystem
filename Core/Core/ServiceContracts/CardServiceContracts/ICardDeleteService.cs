using Entities.BanksEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.ServicesContracts.CardServiceContracts
{
    public interface ICardDeleteService
    {
        public Task DeleteCard(Guid cardId);
    }
}
