using ApplicationCore.Core.Services.Mapping;
using ApplicationCore.Domain.RepositoryContracts;
using BankServicesContracts.RepositoryContracts;
using BankServicesContracts.ServicesContracts.BankService;
using DTO.BankDto;
using Entities.BanksEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.BankService
{
    public class BankAddService : IBankAddService
    {
        private readonly IBankRepository _bankRepository;

        public BankAddService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        //Add
        public async Task AddBank(BankDto bankDto)
        {
            await _bankRepository.AddAsync(BankMapping.ToEntity(bankDto));
            await _bankRepository.SaveAsync();
        }
    }
}
