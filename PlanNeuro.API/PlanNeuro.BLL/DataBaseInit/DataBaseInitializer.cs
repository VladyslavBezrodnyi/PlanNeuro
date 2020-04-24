using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PlanNeuro.DAL.Context;
using PlanNeuro.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace PlanNeuro.BLL.DataBaseInit
{
    public static class DataBaseInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var context = provider.GetRequiredService<ApplicationDbContext>();
                var userManager = provider.GetRequiredService<UserManager<User>>();
                var roleManager = provider.GetRequiredService<RoleManager<IdentityRole<int>>>();

                await InitializeRolesAsync(userManager, roleManager);
            }
        }

        private static async Task InitializeRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string name = "admin";
            string password = "_Aa123456";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<int>("admin"));
            }
            if (await roleManager.FindByNameAsync("work") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<int>("work"));
            }
            if (await roleManager.FindByNameAsync("personal") == null)
            {
                await roleManager.CreateAsync(new IdentityRole<int>("personal"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    Name = name
                };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

        }
    }
}