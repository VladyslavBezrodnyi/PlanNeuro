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
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<CardDTO> CreateCardAsync([FromBody]CardDTO cardDTO)
        {
            return await _cardService.CreateCardAsync(cardDTO);
        }

        [HttpPut]
        [Route("change")]
        public async Task<CardDTO> ChangeCardAsync([FromBody]CardDTO cardDTO)
        {
            return await _cardService.ChangeCardAsync(cardDTO);
        }

        [HttpDelete]
        [Route("delete/{cardId}")]
        public async Task DaleteCardAsync(int cardId)
        {
            await _cardService.DeleteCardAsync(cardId);
        }
    }
}