using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.BLL.Interfaces
{
    public interface ICardsListService
    {
        Task<CardsListDTO> CreateCardsListAsync(CardsListDTO cardsListDTO);
        Task DeleteCardsListAsync(int cardsListId);
    }
}
