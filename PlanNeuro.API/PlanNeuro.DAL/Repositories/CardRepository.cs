using PlanNeuro.DAL.Context;
using PlanNeuro.DAL.Entities;
using PlanNeuro.DAL.Interfaces;
using PlanNeuro.DAL.Mappers;
using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.DAL.Repositories
{
    public class CardRepository: ICardRepository
    {
        private ApplicationDbContext db;

        public CardRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<CardDTO> ChangeCardAsync(CardDTO cardDTO)
        {
            var card = db.Cards.FirstOrDefault(c => c.Id == cardDTO.Id);
            if (card == null)
            {
                throw new Exception("Card is not exist!");
            }
            card.CardsListId = cardDTO.CardsListId;
            card.ItemNumber = cardDTO.ItemNumber;
            card.Title = cardDTO.Title;
            card.Description = cardDTO.Description;
            card.Start = cardDTO.Start;
            card.End = cardDTO.End;
            card.Duration = cardDTO.Duration;
            if (cardDTO.Discriminator == "PlanCard")
            {
                PlanCard planCard = ((PlanCard)card);
                if (planCard.IsDone != (planCard.DoneUserId != null))
                {
                    throw new Exception("Error!");
                }
                planCard.IsDone = ((PlanCardDTO)cardDTO).IsDone;
                planCard.DoneUserId = ((PlanCardDTO)cardDTO).DoneUserId;
            }
            if (cardDTO.Discriminator == "HabitCard")
            {
                ((HabitCard)card).DoneCounter = ((HabitCardDTO)cardDTO).DoneCounter;
                ((HabitCard)card).NotDoneCounter = ((HabitCardDTO)cardDTO).NotDoneCounter;
            }
            await db.SaveChangesAsync();
            return db.Cards.FirstOrDefault(c => c.Id == cardDTO.Id).ToCardDTO();
        }

        public async Task<CardDTO> CreateCardAsync(CardDTO cardDTO)
        {
            if (cardDTO.Discriminator != "PlanCard" && cardDTO.Discriminator != "HabitCard")
            {
                throw new Exception("Card type is not exist!");
            }
            if (cardDTO.Discriminator != "PlanCard")
            {
                PlanCard planCard = (PlanCard)cardDTO.ToCard();
                db.PlanCards.Add(planCard);
                await db.SaveChangesAsync();
                return db.PlanCards.FirstOrDefault(pc => pc.Id == planCard.Id).ToCardDTO();
            }
            if (cardDTO.Discriminator != "HabitCard")
            {
                HabitCard habitCard = (HabitCard)cardDTO.ToCard();
                db.HabitCards.Add(habitCard);
                await db.SaveChangesAsync();
                return db.HabitCards.FirstOrDefault(pc => pc.Id == habitCard.Id).ToCardDTO();

            }
            return null;
        }

        public async Task DeleteCardAsync(int cardId)
        {
            var card = db.Cards.Find(cardId);
            if (card == null)
            {
                throw new Exception("Card is not exist!");
            }
            db.Cards.Remove(card);
            await db.SaveChangesAsync();
        }
    }
}
