using PlanNeuro.DAL.Entities;
using PlanNeuro.Domain.DTOs;

namespace PlanNeuro.Domain.Mappers
{
    public static class UserExtension
    {
        public static User ToUser(this RegistrationDTO registrationDTO)
        {
            return new User
            {
                Name = registrationDTO.Name,
                Email = registrationDTO.Email,
                UserName = registrationDTO.Email
            };
        }

        public static UserDTO ToUserDTO(this User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Emile = user.Email
            };
        }
    }
}
