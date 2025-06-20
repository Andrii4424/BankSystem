using ApplicationCore.Domain.RepositoryContracts;
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
    public class CardUpdateService : ICardUpdateService
    {
        private readonly ICardRepository _cardRepository;
        private readonly ILogger<CardUpdateService> _logger;

        public CardUpdateService(ICardRepository cardRepository, ILogger<CardUpdateService> logger)
        {
            _cardRepository = cardRepository;
            _logger = logger;
        }

        public async Task UpdateCard(int cardId, CardDto cardDto)
        {
            CardEntity? card = await _cardRepository.GetValueByIdAsync(cardId);
            if (card == null)
            {
                _logger.LogWarning("UpdateCard: Card with this id doesnt exist in this bank, bankId: {BankId}, " +
        "cardId: {CardId}", cardDto.BankId, cardId);
                throw new ArgumentException("This card doesnt exist");
            }
            else if (card.BankId != cardDto.BankId)
            {
                _logger.LogWarning("UpdateCard: Bank id doesnt match with cards bankId, cards bankId: {BankId}, " +
"entered bankId: {BankId}", card.BankId, cardDto.BankId);
                throw new ArgumentException("Cards bank id before change and after are not the same");
            }
            card.CardName = cardDto.CardName;
            card.CardType = cardDto.CardType;
            card.CardLevel = cardDto.CardLevel;
            card.ValidityPeriod = cardDto.ValidityPeriod;
            card.MaxCreditLimit = cardDto.MaxCreditLimit;
            card.PaymentSystem = cardDto.PaymentSystem;
            _cardRepository.UpdateObject(card);
            await _cardRepository.SaveAsync();
        }
    }
}
