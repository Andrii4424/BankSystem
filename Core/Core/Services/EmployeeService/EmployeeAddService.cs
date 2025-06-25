using ApplicationCore.Domain.RepositoryContracts;
using BankServicesContracts.RepositoryContracts;
using BankServicesContracts.ServicesContracts.EmployeeServiceContracts;
using Core.Domain.Entities;
using Entities.BanksEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.EmployeeService
{
    public class EmployeeAddService : IEmployeeAddService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeAddService> _logger;

        public EmployeeAddService(IEmployeeRepository employeeRepository, ILogger<EmployeeAddService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task AddEmployee(Guid bankId, Guid userId, string jobTitle)
        {
            UserEntity? employee = await _employeeRepository.GetValueByIdAsync(userId);
            if (employee == null)
            {
                _logger.LogWarning("AddEmployee: Employee with id: {UserId} doesnt exist in bank with id: " +
        "{BankId}", userId, bankId);
                throw new NullReferenceException("This user doesnt exist in this bank!" +
                "Employee must be a bank user");
            }
            else if (employee.BankId != bankId)
            {
                _logger.LogWarning("AddEmployee: Employee with id: {UserId} doesnt exist in bank with id: " +
                    "{BankId}", userId, bankId);
                throw new ArgumentException("This user doesnt exist in this bank! Employee must be a bank user!");
            }
            else if(employee.Age<18) throw new ArgumentException("The employee must be of legal age!");
            employee.IsEmployed = true;
            employee.JobTitle = jobTitle;
            _employeeRepository.UpdateObject(employee);
            await _employeeRepository.SaveAsync();
        }
    }
}
