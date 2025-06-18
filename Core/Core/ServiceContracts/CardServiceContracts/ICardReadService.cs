using DTO.BankDto;
using Entities.BanksEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.ServicesContracts.CardServiceContracts
{
    public interface ICardReadService
    {
        public Task<List<CardEntity>?> GetCardsList();
        public Task<CardEntity> GetCardById(int cardId, int bankId);
        public Task<string> GetCardBankName(int bankId);
        public Task<List<CardEntity>?> GetCardsListByBankId(int bankId);
        public Task<CardDto> GetCardDto(int cardId);
    }
}
