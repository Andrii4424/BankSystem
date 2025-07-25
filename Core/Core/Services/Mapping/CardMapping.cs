﻿using DTO.BankDto;
using Entities.BanksEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Core.Services.Mapping
{
    public static class CardMapping
    {
        public static CardEntity ToEntity(CardDto cardDto)
        {
            CardEntity card = new CardEntity(cardDto.BankId, cardDto.CardType, cardDto.CardLevel, cardDto.CardName, cardDto.ValidityPeriod,
                cardDto.MaxCreditLimit, cardDto.PaymentSystem);
            return card;
        }

        public static async Task<CardDto> ToDto(CardEntity card)
        {
            CardDto cardDto = new CardDto()
            {
                BankId = card.BankId,
                CardName = card.CardName,
                CardLevel = card.CardLevel,
                CardType = card.CardType,
                ValidityPeriod = card.ValidityPeriod,
                MaxCreditLimit = card.MaxCreditLimit,
                PaymentSystem = card.PaymentSystem
            };
            return cardDto;
        }

        public static async Task<List<CardDto>> ToDtoList(List<CardEntity>? cardEntities)
        {
            List<CardDto> cardDtos = new List<CardDto>();
            foreach (CardEntity card in cardEntities)
            {
                cardDtos.Add(await ToDto(card));
            }
            return cardDtos;
        }
    }
}
