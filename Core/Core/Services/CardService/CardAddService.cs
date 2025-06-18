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
        private readonly IGenericRepository<CardEntity> _cardRepository;
        private readonly IGenericRepository<BankEntity> _bankRepostory;

        public CardAddService(IGenericRepository<CardEntity> cardRepository, IGenericRepository<BankEntity> bankRepository)
        {
            _bankRepostory = bankRepository;
            _cardRepository = cardRepository;
        }

        public async Task AddCard(CardDto cardDto)
        {
            if (!await _bankRepostory.IsObjectIdExists(cardDto.BankId))
            {
                throw new ArgumentException("Bank with this id doesnt exist");
            }
            await _cardRepository.AddAsync(CardMapping.ToEntity(cardDto));
            await _cardRepository.SaveAsync();
        }
    }
}
