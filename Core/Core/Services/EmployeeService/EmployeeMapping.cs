using Core.Domain.Entities;
using DTO.PersonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.EmployeeService
{
    public static class EmployeeMapping
    {
        public static async Task<UserDto> ToDto(UserEntity user)
        {
            UserDto userDto = new UserDto()
            {
                BankId = user.BankId,
                FinancalNumber = user.FinancalNumber,
                Email = user.Email,
                FullName = user.FullName,
                Age = user.Age,
                Nationality = user.Nationality,
                Gender = user.Gender,
                IsEmployed = user.IsEmployed,
                JobTitle = user.JobTitle,
            };
            return userDto;
        }
    }
}
