using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanNeuro.BLL.Services;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.Domain.DTOs;
using PlanNeuro.Domain.Responses;

namespace PlanNeuro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("search/{email}")]
        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            return await _accountService.SearchByEmail(email);
        }

        [HttpPost]
        [Route("register")]
        public async Task RegisterAsync([FromBody] RegistrationDTO registrationDTO)
        {
            await _accountService.RegisterAsync(registrationDTO);
        }
    
        [HttpPost]
        [Route("login")]
        public async Task<TokenResponse> LoginAsync([FromBody] LoginDTO loginDTO)
        {
            return await _accountService.LoginAsync(loginDTO);
        }
    }
}