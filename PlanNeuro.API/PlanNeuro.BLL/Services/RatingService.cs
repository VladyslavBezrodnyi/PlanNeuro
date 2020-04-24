using Microsoft.EntityFrameworkCore;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.DAL.Context;
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
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork db;

        public RatingService(IUnitOfWork db)
        {
            this.db = db;
        }

        public async Task<List<RatingDTO>> GetCommonRating()
        {
            return await db.Raitings.GetCommonRating();           
        }

        public async Task<RatingDTO> GetPersonalRating(UserData userData)
        {
            return await db.Raitings.GetPersonalRating(userData);
        }

        public async Task<List<RatingDTO>> GetRatingInBoard(int boardId, UserData userData)
        {
            return await db.Raitings.GetRatingInBoard(boardId, userData);
        }
    }
}
