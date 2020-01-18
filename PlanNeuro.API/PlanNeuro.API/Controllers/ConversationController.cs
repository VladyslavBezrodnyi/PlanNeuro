using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanNeuro.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using PlanNeuro.Domain.DTOs;
using PlanNeuro.API.Extensions;

namespace PlanNeuro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationService _conversationService;

        public ConversationController(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        [HttpGet]
        [Route("get/{boardId}")]
        public async Task<List<MessageDTO>> GetMessages(int boardId)
        {
            return await _conversationService.GetMessages(boardId, User.ToUserData());
        }

        [HttpPost]
        [Route("add")]
        public async Task<MessageDTO> AddMessage([FromBody]MessageDTO message)
        {
            return await _conversationService.AddMessage(message);
        }
    }
}