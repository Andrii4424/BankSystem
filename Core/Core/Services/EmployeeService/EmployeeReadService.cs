using ApplicationCore.Core.Services.Mapping;
using ApplicationCore.Domain.RepositoryContracts;
using BankServicesContracts.RepositoryContracts;
using BankServicesContracts.ServicesContracts.EmployeeServiceContracts;
using Core.Domain.Entities;
using DTO.PersonDto;
using Entities.BanksEntities;
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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IBankRepository _bankRepository;
        private readonly ILogger<EmployeeReadService> _logger;

        public EmployeeReadService(IEmployeeRepository employeeRepository,
            IBankRepository bankRepository, ILogger<EmployeeReadService> logger)
        {
            _employeeRepository = employeeRepository;
            _bankRepository = bankRepository;
            _logger = logger;
        }

        public async Task<List<UserDto>?> GetAllBankEmployeesList(Guid bankId)
        {
            return await EmployeeMapping.ToDtoList(await _employeeRepository.GetAllBankEmployeesList(bankId));
        }

        public async Task<UserDto> GetEmployeeById(Guid userId, Guid bankId)
        {
            UserEntity? employee = await _employeeRepository.GetValueByIdAsync(userId);
            if (employee == null || employee.IsEmployed == false || employee.BankId != bankId)
            {
                _logger.LogWarning("GetEmployeeById: Employee with id: {UserId} doesnt exist in bank with id: " +
                    "{BankId}", userId, bankId);
                throw new ArgumentException("This employee doesnt exist in this bank!");
            }
            return await EmployeeMapping.ToDto(employee); ;
        }

        public async Task<string> GetEmployeesBankName(Guid bankId)
        {
            return (await _bankRepository.GetValueByIdAsync(bankId)).BankName;
        }
    }
}
