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
        public Task<CardEntity> GetCardById(Guid cardId, Guid bankId);
        public Task<string> GetCardBankName(Guid bankId);
        public Task<List<CardEntity>?> GetCardsListByBankId(Guid bankId);
        public Task<CardDto> GetCardDto(Guid cardId);
    }
}
