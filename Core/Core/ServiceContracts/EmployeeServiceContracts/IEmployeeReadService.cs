using Core.Domain.Entities;
using DTO.PersonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.ServicesContracts.EmployeeServiceContracts
{
    public interface IEmployeeReadService
    {
        public Task<List<UserDto>?> GetAllBankEmployeesList(Guid bankId);

        public Task<UserDto> GetEmployeeById(Guid userId, Guid bankId);

        public Task<string> GetEmployeesBankName(Guid bankId);
    }
}
