using ApplicationCore.Domain.RepositoryContracts;
using BankServicesContracts.RepositoryContracts;
using BankServicesContracts.ServicesContracts.BankService;
using Entities.BanksEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.BankService
{
    public class BankDeleteService: IBankDeleteService
    {
        private readonly IBankRepository _bankRepository;

        public BankDeleteService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        //Delete
        public async Task DeleteBank(Guid bankId)
        {
            BankEntity? bank = await _bankRepository.GetValueByIdAsync(bankId);
            if (bank != null) _bankRepository.DeleteElement(bank);
            await _bankRepository.SaveAsync();
        }
    }
}
