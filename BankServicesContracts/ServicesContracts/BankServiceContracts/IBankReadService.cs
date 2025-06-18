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
        public Task<List<BankEntity>?> GetAllBanksList();
        public Task<BankEntity> GetBankModel(int bankId);
        public Task<BankDto> GetBankDto(int bankId);
    }
}
