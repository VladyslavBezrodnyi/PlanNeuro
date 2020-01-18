using Microsoft.EntityFrameworkCore;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.DAL.Context;
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
    public class RatingService : IRatingService
    {
        private readonly ApplicationDbContext db;

        public RatingService(ApplicationDbContext db)
        {
            this.db = db;
        }
        
        public async Task<List<RatingDTO>> GetCommonRating()
        {
            int numberOfUsers = 10;
            var query = await db.Users.Include(u => u.DoneCards)
                .OrderBy(u => u.DoneCards.Sum(c => c.Complexity))
                .Take(numberOfUsers)
                .Select(u => new RatingDTO
                {
                    User = u.ToUserDTO(),
                    Rating = (int)u.DoneCards.Sum(c => c.Complexity)
                })
                .ToListAsync();
            for(int i = 1; i < query.Count(); i++)
            {
                query[i].Id = i;
            }
            return query;
                        
        }

        public async Task<RatingDTO> GetPersonalRating(UserData userData)
        {
            var user = db.Users
                .Include(u => u.DoneCards)
                .FirstOrDefault(u => u.Id == userData.Id);
            if(user == null)
            {
                throw new Exception("User is not exist!");
            }
            return await Task.Run(() => new RatingDTO
            {
                Id = 1,
                User = user.ToUserDTO(),
                Rating = (int)user.DoneCards.Sum(c => c.Complexity)
            });
        }

        public async Task<List<RatingDTO>> GetRatingInBoard(int boardId, UserData userData)
        {
            var board = db.Boards
                .Include(b => b.UserBoards)
                .FirstOrDefault(b => b.Id == boardId);
            if (board == null)
            {
                throw new Exception("Board is not exist!");
            }
            if(board.UserBoards.Where(ub => ub.UserId == userData.Id).Count() != 0)
            {
                throw new Exception("User do not have premission!");
            }
            var query = await db.Users
                .Include(u => u.UserBoards)
                .Include(u => u.DoneCards)
                .Where(u => u.UserBoards.Where(ub => ub.BoardId == boardId).Count() != 0)
                .OrderBy(u => u.DoneCards.Sum(c => c.Complexity))
                .Select(u => new RatingDTO
                {
                    User = u.ToUserDTO(),
                    Rating = (int)u.DoneCards.Sum(c => c.Complexity)
                })
                .ToListAsync();
            for (int i = 1; i < query.Count(); i++)
            {
                query[i].Id = i;
            }
            return query;
        }
    }
}
