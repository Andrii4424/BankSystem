using DTO.BankDto;
using Entities.BanksEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Core.Services.Mapping
{
    public static class BankMapping
    {
        public static BankEntity ToEntity(BankDto bankDto)
        {
            BankEntity bank = new BankEntity(bankDto.BankName, bankDto.Rating, bankDto.HasLicense, bankDto.BankFounder,
                 bankDto.BankDirector, bankDto.Capitalization, bankDto.EmployeesCount, bankDto.ClientsCount, bankDto.BlockedClientsCount);
            return bank;
        }

        public static BankDto ToDto(BankEntity bankEntity)
        {
            BankDto bankDto = new BankDto()
            {
                BankName = bankEntity.BankName,
                Rating = bankEntity.Rating,
                HasLicense = bankEntity.HasLicense,
                BankFounder = bankEntity.BankFounder,
                BankDirector = bankEntity.BankDirector,
                Capitalization = bankEntity.Capitalization,
                EmployeesCount = bankEntity.EmployeesCount,
                BlockedClientsCount = bankEntity.BlockedClientsCount,
                ClientsCount = bankEntity.ClientsCount,
            };
            return bankDto;
        }
    }
}
