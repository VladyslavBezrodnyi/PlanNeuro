using PlanNeuro.Domain.DTOs;
using PlanNeuro.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<List<UserDTO>> SearchByEmail(string email);
        Task<TokenResponse> LoginAsync(LoginDTO loginDTO);
        Task RegisterAsync(RegistrationDTO registrationDTO);
    }
}
