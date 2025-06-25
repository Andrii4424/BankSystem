using DTO.BankDto;
using Entities.BanksEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.ServicesContracts.BankService
{
    public interface IBankReadService
    {
        public Task<List<BankDto>?> GetAllBanksList();
        public Task<BankDto> GetBankModel(Guid bankId);
    }
}
