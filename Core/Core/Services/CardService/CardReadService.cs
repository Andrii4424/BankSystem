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
        private readonly IGenericRepository<CardEntity> _cardRepository;
        private readonly IGenericRepository<BankEntity> _bankRepository;
        private readonly ILogger<CardReadService> _logger;

        public CardReadService(IGenericRepository<CardEntity> cardRepository,
            IGenericRepository<BankEntity> bankRepository, ILogger<CardReadService> logger)
        {
            _cardRepository = cardRepository;
            _bankRepository = bankRepository;
            _logger = logger;
        }

        //Read
        public async Task<List<CardEntity>?> GetCardsList()
        {
            return await _cardRepository.GetAllValuesAsync() as List<CardEntity>;
        }

        public async Task<CardEntity> GetCardById(int cardId, int bankId)
        {
            CardEntity? card = await _cardRepository.GetValueByIdAsync(cardId);
            if (card == null || card.BankId != bankId)
            {
                _logger.LogWarning("GetCardById: Card with this id doesnt exist in this bank, bankId: {BankId}, " +
                    "cardId: {CardId}", bankId, cardId);
                throw new ArgumentException("This card doesnt exist in this bank!");
            }
            return card;
        }

        public async Task<string> GetCardBankName(int bankId)
        {
            return (await _bankRepository.GetValueByIdAsync(bankId)).BankName;
        }

        public async Task<List<CardEntity>?> GetCardsListByBankId(int bankId)
        {
            List<CardEntity>? allCardsList = await GetCardsList();
            List<CardEntity>? bankCards = allCardsList?
                .Where(u => u.BankId == bankId)
                .ToList();
            return bankCards;
        }


        public async Task<CardDto> GetCardDto(int cardId)
        {
            CardEntity? cardEntity = await _cardRepository.GetValueByIdAsync(cardId);
            if (cardEntity == null) throw new ArgumentException("This Card doesnt exist!");
            return await CardMapping.ToDto(cardEntity);
        }
    }
}
