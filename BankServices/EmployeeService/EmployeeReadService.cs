using BankServicesContracts.RepositoryContracts;
using BankServicesContracts.ServicesContracts.EmployeeServiceContracts;
using DTO.PersonDto;
using Entities.BanksEntities;
using Entities.PersonsEntites;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.EmployeeService
{
    public class EmployeeReadService : IEmployeeReadService
    {
        private readonly IGenericRepository<UserEntity> _employeeRepository;
        public readonly IGenericRepository<BankEntity> _bankRepository;
        private readonly ILogger<EmployeeReadService> _logger;

        public EmployeeReadService(IGenericRepository<UserEntity> genericRepository,
            IGenericRepository<BankEntity> BankRepository, ILogger<EmployeeReadService> logger)
        {
            _employeeRepository = genericRepository;
            _bankRepository = BankRepository;
            _logger = logger;
        }

        public async Task<List<UserEntity>?> GetAllBankEmployeesList(int bankId)
        {
            var response = await _employeeRepository.GetAllValuesAsync();
            if (response == null) return null;
            return response.
                Where(u => u.IsEmployed == true && u.BankId == bankId)
                .ToList();
        }

        public async Task<UserEntity> GetEmployeeById(int userId, int bankId)
        {
            UserEntity? employee = await _employeeRepository.GetValueByIdAsync(userId);
            if (employee == null || employee.IsEmployed == false || employee.BankId != bankId)
            {
                _logger.LogWarning("GetEmployeeById: Employee with id: {UserId} doesnt exist in bank with id: " +
                    "{BankId}", userId, bankId);
                throw new ArgumentException("This employee doesnt exist in this bank!");
            }
            return employee;
        }

        public async Task<string> GetEmployeesBankName(int bankId)
        {
            return (await _bankRepository.GetValueByIdAsync(bankId)).BankName;
        }

        public async Task<UserDto> GetEmployeeDto(int userId)
        {
            UserEntity? user = await _employeeRepository.GetValueByIdAsync(userId);
            if (user == null) throw new ArgumentException("This employee doesnt exist in this bank!"); 
            return await EmployeeMapping.ToDto(user);
        }
    }
}
