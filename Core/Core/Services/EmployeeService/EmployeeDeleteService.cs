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
    public class EmployeeDeleteService : IEmployeeDeleteService
    {
        private readonly IGenericRepository<UserEntity> _employeeRepository;
        private readonly ILogger<EmployeeDeleteService> _logger;

        //Constructor
        public EmployeeDeleteService(IGenericRepository<UserEntity> genericRepository, ILogger<EmployeeDeleteService> logger)
        {
            _employeeRepository = genericRepository;
            _logger = logger;
        }

        public async Task FireEmployee(int userId)
        {
            UserEntity? employee = await _employeeRepository.GetValueByIdAsync(userId);
            if (employee == null)
            {
                _logger.LogWarning("FireEmployee: Employee with id: {UserId} doesnt exist in this bank", userId);
                throw new ArgumentException("This employee doesnt exist in this bank!");
            }
            employee.IsEmployed = false;
            employee.JobTitle = null;
            _employeeRepository.UpdateObject(employee);
            await _employeeRepository.SaveAsync();
        }
    }
}
