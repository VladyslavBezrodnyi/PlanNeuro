using PlanNeuro.Domain.DataObjects;
using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.BLL.Interfaces
{
    public interface IBoardService
    {
        Task<BoardDTO> GetPersonalBoardAsync(UserData user);
        Task<ICollection<BoardDTO>> GetShareBoardsAsync(UserData user);
        Task<BoardDTO> GetBoardAsync(int boardId);
        Task<BoardDTO> CreateBoardAsync(BoardDTO boardDTO);
        Task DeleteBoardAsync(int boardId);
    }
}
