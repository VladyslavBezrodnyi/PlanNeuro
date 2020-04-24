using PlanNeuro.BLL.Interfaces;
using PlanNeuro.DAL.Context;
using PlanNeuro.DAL.Entities;
using PlanNeuro.DAL.Interfaces;
using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.BLL.Services
{
    public class CardsListService : ICardsListService
    {
        private readonly IUnitOfWork db;

        public CardsListService(IUnitOfWork db)
        {
            this.db = db;
        }

        public async Task<CardsListDTO> CreateCardsListAsync(CardsListDTO cardsListDTO)
        {
            return await db.CardsLists.CreateCardsListAsync(cardsListDTO);
        }

        public async Task DeleteCardsListAsync(int cardsListId)
        {
            await db.CardsLists.DeleteCardsListAsync(cardsListId);
        }
    }
}
