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
    public class BankUpdateService : IBankUpdateService
    {
        private readonly IBankRepository _bankRepository;

        public BankUpdateService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task UpdateBank(int bankId, BankDto bankDto)
        {
            BankEntity? bank = await _bankRepository.GetValueByIdAsync(bankId);
            if (bank == null) throw new ArgumentException("This bank doesnt exist!"); 
            bank.BankName = bankDto.BankName;
            bank.Rating = bankDto.Rating;
            bank.HasLicense = bankDto.HasLicense;
            bank.BankFounder = bankDto.BankFounder;
            bank.BankDirector = bankDto.BankDirector;
            bank.Capitalization = bankDto.Capitalization;
            bank.EmployeesCount = bankDto.EmployeesCount;
            bank.ClientsCount = bankDto.ClientsCount;
            bank.BlockedClientsCount = bankDto.BlockedClientsCount;

            _bankRepository.UpdateObject(bank);
            await _bankRepository.SaveAsync();
        }
    }
}
