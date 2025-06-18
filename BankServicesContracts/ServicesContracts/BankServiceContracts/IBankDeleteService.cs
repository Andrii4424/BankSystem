using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.ServicesContracts.BankService
{
    public interface IBankDeleteService
    {
        public Task DeleteBank(int bankId);
    }
}
