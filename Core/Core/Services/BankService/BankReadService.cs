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
    public class BankReadService : IBankReadService
    {
        private readonly IBankRepository _bankRepository;
        private readonly ILogger<BankReadService> _logger;

        public BankReadService(IBankRepository bankRepository, ILogger<BankReadService> logger)
        {
            _bankRepository = bankRepository;
            _logger = logger;
        }

        public async Task<List<BankDto>?> GetAllBanksList()
        {
            return BankMapping.ToDtoList(await _bankRepository.GetAllValuesAsync() as List<BankEntity>);
        }


        public async Task<BankDto> GetBankModel(Guid bankId)
        {
            using (SerilogTimings.Operation.Time("Time for GetBankModel for bankId: {BankId}", bankId))
            {
                BankEntity? bank = await _bankRepository.GetValueByIdAsync(bankId);
                if (bank == null)
                {
                    _logger.LogWarning("GetBankModel: Bank with this id doesnt exist, bankId: {BankId}", bankId);
                    throw new ArgumentException("This bank doesnt exist!");
                }
                return BankMapping.ToDto(bank);
            }
        }
    }
}
