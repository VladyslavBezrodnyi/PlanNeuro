using Microsoft.EntityFrameworkCore;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.DAL.Context;
using PlanNeuro.DAL.Entities;
using PlanNeuro.Domain.DataObjects;
using PlanNeuro.Domain.DTOs;
using PlanNeuro.Domain.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.BLL.Services
{
    public class BoardService : IBoardService
    {
        private readonly ApplicationDbContext db;

        public BoardService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<BoardDTO> GetPersonalBoardAsync(UserData user)
        {
            var board = await db.Boards
                .Include(b => b.CardsLists)
                .ThenInclude(cl => cl.Cards)
                .FirstOrDefaultAsync(b => b.UserId == user.Id);
            return board?.ToBoardDTO(); 
        }

        public async Task<ICollection<BoardDTO>> GetShareBoardsAsync(UserData user)
        {
            var boardsList = await db.Boards
                .Include(b => b.UserBoards)
                .Where(b => b.UserBoards.Where(ub => ub.UserId == user.Id).Count() != 0)
                .OrderBy(b => b.Title)
                .Select(b => new BoardDTO
                {
                    Id = b.Id,
                    Title = b.Title
                })
                .ToListAsync();
            return boardsList;
        }

        public async Task<BoardDTO> GetBoardAsync(int boardId)
        {
            var query = await db.Boards
                .Include(b => b.UserBoards)
                .ThenInclude(ub => ub.User)
                .Include(b => b.CardsLists)
                .ThenInclude(cl => cl.Cards)
                .FirstOrDefaultAsync(b => b.Id == boardId);
            return query.ToBoardDTO();
        }

        public async Task<BoardDTO> CreateBoardAsync(BoardDTO boardDTO)
        {
            var board = new Board
            {
                Title = boardDTO.Title,
                Date = DateTime.UtcNow
        };
            db.Boards.Add(board);
            await db.SaveChangesAsync();

            foreach (UserDTO user in boardDTO.Participants)
            {
                var userBoard = new UserBoard
                {
                    UserId = user.Id,
                    BoardId = board.Id
                };
                db.UserBoards.Add(userBoard);
            }
            await db.SaveChangesAsync();

            return db.Boards
                .Include(b => b.UserBoards)
                .ThenInclude(ub => ub.User)
                .Where(b => b.Id == board.Id)
                .Select(b => new BoardDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Date = b.Date,
                    Participants = b.UserBoards.Select(ub => new UserDTO
                    {
                        Id = ub.UserId,
                        Name = ub.User.Name
                    })
                    .ToList()
                })
                .FirstOrDefault();
        }

        public async Task DeleteBoardAsync(int boardId)
        {
            var board = db.Boards.Find(boardId);
            if (board == null)
            {
                throw new Exception("Board is not exist!");
            }
            db.Boards.Remove(board);
            await db.SaveChangesAsync();
        }
    }
}
