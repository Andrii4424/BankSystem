﻿using ApplicationCore.Domain.RepositoryContracts;
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
    public class EmployeeUpdateService : IEmployeeUpdateService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeUpdateService> _logger;

        public EmployeeUpdateService(IEmployeeRepository employeeRepository, ILogger<EmployeeUpdateService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task UpdateEmployee(Guid userId, string jobTitle)
        {
            UserEntity? employee = await _employeeRepository.GetValueByIdAsync(userId);
            if (employee == null)
            {
                _logger.LogWarning("UpdateEmployee: Employee with id: {UserId} doesnt exist in this bank", userId);
                throw new ArgumentException("This employee doesnt exist in this bank!");
            }
            employee.JobTitle = jobTitle;
            _employeeRepository.UpdateObject(employee);
            await _employeeRepository.SaveAsync();
        }
    }
}
