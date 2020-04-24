using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PlanNeuro.BLL.Configurations;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.DAL.Context;
using PlanNeuro.DAL.Entities;
using PlanNeuro.Domain.DTOs;
using PlanNeuro.Domain.ExceptionBuilders;
using PlanNeuro.Domain.Exceptions;
using PlanNeuro.DAL.Mappers;
using PlanNeuro.Domain.ModelValidators;
using PlanNeuro.Domain.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly AuthConfiguration _authConfiguration;
        private readonly ApplicationDbContext db;

        public AccountService(UserManager<User> userManager,
                              AuthConfiguration authConfiguration,
                              ApplicationDbContext db)
        {
            _userManager = userManager;
            _authConfiguration = authConfiguration;
            this.db = db;
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            return await db.Users
                .Where(u => u.Email.ToUpperInvariant().StartsWith(email.ToUpperInvariant()))
                .Take(10)
                .Select(u => u.ToUserDTO())
                .ToListAsync();
        }

        public async Task<TokenResponse> LoginAsync(LoginDTO loginDTO)
        {
            var result = ModelValidator.IsValid(loginDTO);

            if (!result.Successed)
                throw ValidationExceptionBuilder.BuildValidationException(result);

            var foundUser = await FindUserByEmail(loginDTO.Email);
            await CheckIfThePasswordIsCorrect(foundUser, loginDTO.Password);
            var userRole = await _userManager.GetRolesAsync(foundUser);

            return GenerateJwtToken(foundUser, userRole);
        }
        
        public async Task RegisterAsync(RegistrationDTO registrationDTO)
        {
            ValidationResults result = ModelValidator.IsValid(registrationDTO);
            if (!result.Successed)
                throw ValidationExceptionBuilder.BuildValidationException(result);

            User newUser = registrationDTO.ToUser();

            string password = registrationDTO.Password;
            await CheckIfThePasswordIsValid(password);
            await CheckIfTheUserDoesNotExist(newUser);

            var isCreated = await _userManager.CreateAsync(newUser, password);
            if (!isCreated.Succeeded)
            {
                throw new DBException("Cann't create new user");
            }
            
            var isAddedToRole = await _userManager.AddToRoleAsync(newUser, "personal");
            if (!isAddedToRole.Succeeded)
            {
                throw new DBException("Cann't add new user to personal role");
            }
            var newBoard = new Board
            {
                Title = "Personal board",
                Date = DateTimeOffset.UtcNow,
                UserId = newUser.Id
            };
            db.Boards.Add(newBoard);
            await db.SaveChangesAsync();
            var plansList = new CardsList
            {
                Type = "PlanCard",
                BoardId = newBoard.Id
            };
            var habitsList = new CardsList {
                Type = "HabitCard",
                BoardId = newBoard.Id
            };
            db.CardsLists.AddRange(plansList, habitsList);
            await db.SaveChangesAsync();
        }
        
        private async Task CheckIfThePasswordIsValid(string password)
        {
            var passwordValidator = new PasswordValidator<User>();
            var isValid = (await passwordValidator.ValidateAsync(_userManager, null, password)).Succeeded;
            if (!isValid) throw new ValidationException("Invalid password");

        }

        private async Task<User> FindUser(string email)
        {
            return await _userManager.FindByEmailAsync(email);

        }

        private async Task CheckIfTheUserDoesNotExist(User user)
        {
            User foundUser = await _userManager.FindByEmailAsync(user.Email);
            if (foundUser != null) throw new ValidationException("User with this email already exists");
        }

        private TokenResponse GenerateJwtToken(User user, IList<string> roles)
        {
            string stringOfRoles = String.Join(" ", roles.ToArray());
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, stringOfRoles),
            };

            var token = new JwtSecurityToken(
                issuer: _authConfiguration.ISSUER,
                audience: _authConfiguration.AUDIENCE,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_authConfiguration.LIFETIME),
                signingCredentials: new SigningCredentials(
                        _authConfiguration.KEY,
                        SecurityAlgorithms.HmacSha256)
            );
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new TokenResponse() { AccessToken = jwtToken };
        }

        private async Task<User> FindUserByEmail(string email)
        {
            User foundUser = await _userManager.FindByEmailAsync(email);
            if (foundUser == null) throw new ValidationException("There is no user with such email");
            return foundUser;
        }

        private async Task CheckIfThePasswordIsCorrect(User user, string password)
        {
            bool IsPasswordCorrect = await _userManager.CheckPasswordAsync(user, password);
            if (!IsPasswordCorrect)
                throw new ValidationException("Wrong password");
        }
    }
}
