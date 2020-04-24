using PlanNeuro.DAL.Entities;
using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanNeuro.DAL.Mappers
{
    public static class CardExtension
    {
        public static CardDTO ToCardDTO(this Card card)
        {
            CardDTO newCardDTO = new CardDTO
            {
                Id = card.Id,
                BoardId = card?.CardsList.BoardId,
                CardsListId = card.CardsListId,
                Discriminator = card.Discriminator,
                ItemNumber = card?.ItemNumber,
                Title = card.Title,
                Description = card.Description,
                Start = card.Start,
                End = card.End,
                Duration = card?.Duration,
                Complexity = card?.Complexity
            };
            if (card.Discriminator == "PlanCard")
            {
                PlanCardDTO planCardDTO = (PlanCardDTO)newCardDTO;
                planCardDTO.IsDone = ((PlanCard)card).IsDone;
                planCardDTO.DoneUserId = ((PlanCard)card).DoneUserId;
                planCardDTO.DoneUser = ((PlanCard)card).DoneUser.ToUserDTO();
                return planCardDTO;
            }
            else
            {
                HabitCardDTO habitCardDTO = (HabitCardDTO)newCardDTO;
                habitCardDTO.DoneCounter = ((HabitCard)card).DoneCounter;
                habitCardDTO.NotDoneCounter = ((HabitCard)card).NotDoneCounter;
                return habitCardDTO;
            }
        }
        
        public static Card ToCard(this CardDTO cardDTO)
        {
            Card newCard = new Card
            {
                ItemNumber = cardDTO.ItemNumber,
                Title = cardDTO.Title,
                Description = cardDTO.Description,
                Start = cardDTO.Start,
                End = cardDTO.End,
                Duration = cardDTO?.Duration,
                CardsListId = cardDTO.CardsListId,
                Complexity = cardDTO?.Complexity
            };
            if (cardDTO.Discriminator == "PlanCard")
            {
                PlanCard planCard = (PlanCard)newCard;
                planCard.IsDone = ((PlanCardDTO)cardDTO).IsDone;
                planCard.DoneUserId = ((PlanCardDTO)cardDTO).DoneUserId;
                return planCard;
            }
            else
            {
                HabitCard habitCard = (HabitCard)newCard;
                habitCard.DoneCounter = ((HabitCardDTO)cardDTO).DoneCounter;
                habitCard.NotDoneCounter = ((HabitCardDTO)cardDTO).NotDoneCounter;
                return habitCard;
            }
        }
        
    }
}
