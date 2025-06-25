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
        public Task<List<CardDto>?> GetCardsList();
        public Task<CardDto> GetCardById(Guid cardId, Guid bankId);
        public Task<string> GetCardBankName(Guid bankId);
        public Task<List<CardDto>?> GetCardsListByBankId(Guid bankId);
    }
}
