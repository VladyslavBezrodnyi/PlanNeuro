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
    public class CardsListController : ControllerBase
    {
        private readonly ICardsListService _cardsListService;

        public CardsListController(ICardsListService cardsListService)
        {
            _cardsListService = cardsListService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<CardsListDTO> CreateCardsListAsync([FromBody]CardsListDTO cardsListDTO)
        {
            return await _cardsListService.CreateCardsListAsync(cardsListDTO);
        }

        [HttpDelete]
        [Route("delete/{cardsListId}")]
        public async Task DeleteCardsListAsync(int cardsListId)
        {
            await _cardsListService.DeleteCardsListAsync(cardsListId);
        }
    }
}