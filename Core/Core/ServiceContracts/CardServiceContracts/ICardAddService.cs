using DTO.BankDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.ServicesContracts.CardServiceContracts
{
    public interface ICardAddService
    {
        public Task AddCard(CardDto cardDto);
    }
}
