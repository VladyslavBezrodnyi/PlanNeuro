using PlanNeuro.DAL.Entities;
using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanNeuro.Domain.Mappers
{
    public static class BoardExtension
    {
        public static BoardDTO ToBoardDTO(this Board board)
        {
            return new BoardDTO
            {
                Id = board.Id,
                Title = board.Title,
                CardsLists = board?.CardsLists.Select(c => c.ToCardsListDTO()).ToList(),
                Participants = board?.UserBoards.Select(ub => ub?.User.ToUserDTO()).ToList()
            };
        }
    }
}
