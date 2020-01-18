using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanNeuro.API.Extensions;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.BLL.Services;
using PlanNeuro.Domain.DTOs;

namespace PlanNeuro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<RatingDTO>> GetCommonRating()
        {
            return await _ratingService.GetCommonRating();
        }

        [HttpGet]
        [Route("board/{boardId}")]
        public async Task<List<RatingDTO>> GetRatingInBoard(int boardId)
        {
            return await _ratingService.GetRatingInBoard(boardId, User.ToUserData());
        }

        [HttpGet]
        [Route("personal")]
        public async Task<RatingDTO> GetPersonalRating()
        {
            return await _ratingService.GetPersonalRating(User.ToUserData());
        }
    }
}