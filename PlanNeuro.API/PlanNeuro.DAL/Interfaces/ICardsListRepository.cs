using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.DAL.Interfaces
{
    public interface ICardsListRepository
    {
        Task<CardsListDTO> CreateCardsListAsync(CardsListDTO cardsListDTO);
        Task DeleteCardsListAsync(int cardsListId);
    }
}
