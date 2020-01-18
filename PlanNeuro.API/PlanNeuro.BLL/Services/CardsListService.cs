using PlanNeuro.BLL.Interfaces;
using PlanNeuro.DAL.Context;
using PlanNeuro.DAL.Entities;
using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.BLL.Services
{
    public class CardsListService : ICardsListService
    {
        private readonly ApplicationDbContext db;

        public CardsListService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<CardsListDTO> CreateCardsListAsync(CardsListDTO cardsListDTO)
        {
            if (cardsListDTO.Type != "PlanCard" && cardsListDTO.Type != "HabitCard")
            {
                throw new Exception("Card type is not exist!");
            }
            var newCardsList = new CardsList
            {
                BoardId = cardsListDTO.BoardId,
                Type = cardsListDTO.Type
            };
            db.CardsLists.Add(newCardsList);
            await db.SaveChangesAsync();
            return new CardsListDTO
            {
                Id = newCardsList.Id,
                BoardId = newCardsList.BoardId,
                Type = newCardsList.Type
            };
        }

        public async Task DeleteCardsListAsync(int cardsListId)
        {
            var cardsList = db.CardsLists.Find(cardsListId);
            if (cardsList == null)
            {
                throw new Exception("Cards List is not exist!");
            }
            db.CardsLists.Remove(cardsList);
            await db.SaveChangesAsync();
        }
    }
}
