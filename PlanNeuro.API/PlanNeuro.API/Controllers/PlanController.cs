using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.Domain.DTOs;

namespace PlanNeuro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlanController : ControllerBase
    {
        private readonly IPlanningService _planningService;

        public PlanController(IPlanningService planningService)
        {
            _planningService = planningService;
        }

        [HttpGet]
        [Route("plan/{cardsListId}")]
        public async Task<ICollection<CardDTO>> Plan(int cardsListId)
        {
            await _planningService.Plan(cardsListId);
            return null;
        }
    }
}