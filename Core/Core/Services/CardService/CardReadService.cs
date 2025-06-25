using ApplicationCore.Core.Services.Mapping;
using ApplicationCore.Domain.RepositoryContracts;
using BankServices.BankService;
using BankServicesContracts.RepositoryContracts;
using BankServicesContracts.ServicesContracts.CardServiceContracts;
using DTO.BankDto;
using Entities.BanksEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.CardService
{
    public class CardReadService : ICardReadService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IBankRepository _bankRepository;
        private readonly ILogger<CardReadService> _logger;

        public CardReadService(ICardRepository cardRepository,
            IBankRepository bankRepository, ILogger<CardReadService> logger)
        {
            _cardRepository = cardRepository;
            _bankRepository = bankRepository;
            _logger = logger;
        }

        //Read
        public async Task<List<CardDto>?> GetCardsList()
        {
            return await CardMapping.ToDtoList(await _cardRepository.GetAllValuesAsync() as List<CardEntity>);
        }

        public async Task<CardDto> GetCardById(Guid cardId, Guid bankId)
        {
            CardEntity? card = await _cardRepository.GetValueByIdAsync(cardId);
            if (card == null || card.BankId != bankId)
            {
                _logger.LogWarning("GetCardById: Card with this id doesnt exist in this bank, bankId: {BankId}, " +
                    "cardId: {CardId}", bankId, cardId);
                throw new ArgumentException("This card doesnt exist in this bank!");
            }
            return await CardMapping.ToDto(card);
        }

        public async Task<string> GetCardBankName(Guid bankId)
        {
            return (await _bankRepository.GetValueByIdAsync(bankId)).BankName;
        }

        public async Task<List<CardDto>?> GetCardsListByBankId(Guid bankId)
        {
            return await CardMapping.ToDtoList(await _cardRepository.GetCardsListByBankId(bankId)); 
        }
    }
}
