using BankServicesContracts.RepositoryContracts;
using BankServicesContracts.ServicesContracts.CardServiceContracts;
using Entities.BanksEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.CardService
{
    public class CardDeleteService : ICardDeleteService
    {
        private readonly IGenericRepository<CardEntity> _cardRepository;

        public CardDeleteService(IGenericRepository<CardEntity> cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task DeleteCard(int cardId)
        {
            CardEntity? card = await _cardRepository.GetValueByIdAsync(cardId);
            if (card != null) { _cardRepository.DeleteElement(card); }
            await _cardRepository.SaveAsync();
        }

    }
}
