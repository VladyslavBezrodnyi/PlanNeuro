using PlanNeuro.DAL.Entities;
using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanNeuro.Domain.Mappers
{
    public static class CardsListExtension
    {
        public static CardsListDTO ToCardsListDTO(this CardsList cardsList)
        {
            return new CardsListDTO
            {
                Id = cardsList.Id,
                BoardId = cardsList.BoardId,
                Type = cardsList.Type,
                Cards = cardsList?.Cards.Select(c => c.ToCardDTO()).ToList()

            };
        }
    }
}
