using DTO.BankDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.ServicesContracts.BankService
{
    public interface IBankAddService
    {
        public Task AddBank(BankDto bankDto);
    }
}
