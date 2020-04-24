using PlanNeuro.BLL.Interfaces;
using PlanNeuro.DAL.Context;
using PlanNeuro.DAL.Entities;
using PlanNeuro.Domain.DTOs;
using PlanNeuro.DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanNeuro.DAL.Interfaces;

namespace PlanNeuro.BLL.Services
{
    public class CardService : ICardService
    {
        private readonly IUnitOfWork db;

        public CardService(IUnitOfWork db)
        {
            this.db = db;
        }

        public async Task<CardDTO> CreateCardAsync(CardDTO cardDTO)
        {
            return await db.Cards.CreateCardAsync(cardDTO);
        }

        public async Task<CardDTO> ChangeCardAsync(CardDTO cardDTO)
        {
            return await db.Cards.ChangeCardAsync(cardDTO);
        }

        public async Task DeleteCardAsync(int cardId)
        {
            await db.Cards.DeleteCardAsync(cardId);
        }
    }
}
