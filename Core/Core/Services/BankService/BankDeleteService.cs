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
        private readonly IGenericRepository<BankEntity> _bankRepository;

        public BankDeleteService(IGenericRepository<BankEntity> genericRepository)
        {
            _bankRepository = genericRepository;
        }

        //Delete
        public async Task DeleteBank(int bankId)
        {
            BankEntity? bank = await _bankRepository.GetValueByIdAsync(bankId);
            if (bank != null) _bankRepository.DeleteElement(bank);
            await _bankRepository.SaveAsync();
        }
    }
}
