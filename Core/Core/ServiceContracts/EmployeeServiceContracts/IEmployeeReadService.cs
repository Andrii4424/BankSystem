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
        public Task<List<UserEntity>?> GetAllBankEmployeesList(int bankId);

        public Task<UserEntity> GetEmployeeById(int userId, int bankId);

        public Task<string> GetEmployeesBankName(int bankId);

        public Task<UserDto> GetEmployeeDto(int userId);
    }
}
