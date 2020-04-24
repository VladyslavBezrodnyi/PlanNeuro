using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.DAL.Interfaces
{
    public interface ICardRepository
    {
        Task<CardDTO> CreateCardAsync(CardDTO cardDTO);
        Task DeleteCardAsync(int cardId);
        Task<CardDTO> ChangeCardAsync(CardDTO cardDTO);
    }
}
