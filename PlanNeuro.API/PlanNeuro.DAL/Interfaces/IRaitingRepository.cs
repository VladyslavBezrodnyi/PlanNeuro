﻿using PlanNeuro.Domain.DataObjects;
using PlanNeuro.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.DAL.Interfaces
{
    public interface IRatingRepository
    {
        Task<List<RatingDTO>> GetCommonRating();
        Task<RatingDTO> GetPersonalRating(UserData userData);
        Task<List<RatingDTO>> GetRatingInBoard(int boardId, UserData userData);
    }
}
