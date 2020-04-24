using Microsoft.EntityFrameworkCore;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.DAL.Context;
using PlanNeuro.DAL.Entities;
using PlanNeuro.Domain.DataObjects;
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
    public class BoardService : IBoardService
    {
        private readonly IUnitOfWork db;

        public BoardService(IUnitOfWork db)
        {
            this.db = db;
        }

        public async Task<BoardDTO> GetPersonalBoardAsync(UserData user)
        {
            return await db.Boards.GetPersonalBoardAsync(user);
        }

        public async Task<ICollection<BoardDTO>> GetShareBoardsAsync(UserData user)
        {
            return await db.Boards.GetShareBoardsAsync(user);
        }

        public async Task<BoardDTO> GetBoardAsync(int boardId)
        {
            return await db.Boards.GetBoardAsync(boardId);
        }

        public async Task<BoardDTO> CreateBoardAsync(BoardDTO boardDTO)
        {
            return await db.Boards.CreateBoardAsync(boardDTO);
        }

        public async Task DeleteBoardAsync(int boardId)
        {
            await db.Boards.DeleteBoardAsync(boardId);
        }
    }
}
