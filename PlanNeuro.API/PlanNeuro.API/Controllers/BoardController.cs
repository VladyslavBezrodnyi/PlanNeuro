using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanNeuro.API.Extensions;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.Domain.DTOs;

namespace PlanNeuro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet]
        [Route("personal")]
        public async Task<BoardDTO> GetPersonalBoard()
        {
            return await _boardService.GetPersonalBoardAsync(User.ToUserData());
        }

        [HttpGet]
        [Route("share")]
        public async Task<ICollection<BoardDTO>> GetShareBoardsAsync()
        {
            return await _boardService.GetShareBoardsAsync(User.ToUserData());
        }

        [HttpGet]
        [Route("board/{boardId}")]
        public async Task<BoardDTO> GetBoardAsync(int boardId)
        {
            return await _boardService.GetBoardAsync(boardId);
        }

        [HttpPost]
        [Route("create")]
        public async Task<BoardDTO> CreateBoardAsync([FromBody]BoardDTO boardDTO)
        {
            return await _boardService.CreateBoardAsync(boardDTO);
        }

        [HttpDelete]
        [Route("delete/{boardId}")]
        public async Task DeleteBoard(int boardId)
        {
            await _boardService.DeleteBoardAsync(boardId);
        }
    }
}