using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.BLL.Interfaces
{
    public interface ICardService
    {
        Task<CardDTO> CreateCardAsync(CardDTO cardDTO);
        Task DeleteCardAsync(int cardId);
        Task<CardDTO> ChangeCardAsync(CardDTO cardDTO);
    }
}
