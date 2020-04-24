using PlanNeuro.Domain.DataObjects;
using System.Security.Claims;

namespace PlanNeuro.API.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static UserData ToUserData(this ClaimsPrincipal claimsPrincipal)
        {
            int id = int.Parse(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier));
            string role = claimsPrincipal.FindFirstValue(ClaimTypes.Role);
            return new UserData()
            {
                Id = id,
                Roles = role.Split(" ")
            };
        }
    }
}
