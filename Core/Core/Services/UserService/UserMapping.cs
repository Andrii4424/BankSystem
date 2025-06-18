using BankServicesContracts.RepositoryContracts;
using Core.Domain.Entities;
using DTO.PersonDto;
using Entities.BanksEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServices.UserService
{
    public static class UserMapping
    {
        public static UserEntity ToEntity(UserDto userDto)
        {
            UserEntity user = new UserEntity(userDto.BankId, userDto.FinancalNumber, userDto.Email, userDto.FullName, userDto.Age,
                userDto.Nationality, userDto.Gender, false, null);
            return user;
        }

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
