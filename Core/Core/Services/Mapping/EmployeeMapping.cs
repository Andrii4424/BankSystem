using Core.Domain.Entities;
using DTO.BankDto;
using DTO.PersonDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Core.Services.Mapping
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

        public static async Task<List<UserDto>> ToDtoList(List<UserEntity>? users)
        {
            List<UserDto> employeesDtos = new List<UserDto>();
            foreach (UserEntity employee in users) {
                employeesDtos.Add(await ToDto(employee));
            }
            return employeesDtos;
        }
    }
}
