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
    public class CardAddService : ICardAddService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IBankRepository _bankRepository;

        public CardAddService(ICardRepository cardRepository, IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
            _cardRepository = cardRepository;
        }

        public async Task AddCard(CardDto cardDto)
        {
            if (!await _bankRepository.IsObjectIdExists(cardDto.BankId))
            {
                throw new ArgumentException("Bank with this id doesnt exist");
            }
            await _cardRepository.AddAsync(CardMapping.ToEntity(cardDto));
            await _cardRepository.SaveAsync();
        }
    }
}
