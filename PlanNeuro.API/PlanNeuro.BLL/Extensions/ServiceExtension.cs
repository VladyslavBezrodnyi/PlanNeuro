using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PlanNeuro.BLL.Configurations;
using PlanNeuro.BLL.Interfaces;
using PlanNeuro.BLL.Services;
using PlanNeuro.DAL.Context;
using PlanNeuro.DAL.Entities;
using System;

namespace PlanNeuro.BLL.Extensions
{
    public static class ServiceExtension
    {
        public static AuthenticationBuilder AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddServices(configuration)
                .AddIdentity(configuration);
            return services.AddTokenAuthentication(configuration);
        }

        public static IdentityBuilder AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddIdentity<User, IdentityRole<int>>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireDigit = true;
                }
                )
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("PlanNeuro.DAL")), ServiceLifetime.Scoped)
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IBoardService,BoardService>()
                .AddScoped<ICardsListService, CardsListService>()
                .AddScoped<ICardService, CardService>()
                .AddScoped<IPlanningService, PlanningService>()
                .AddScoped<IRatingService, RatingService>()
                .AddScoped<IConversationService, ConversationService>();
        }

        private static AuthenticationBuilder AddTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            AuthConfiguration authConfiguration = new AuthConfiguration(configuration);
            return services
                .AddSingleton(authConfiguration)
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = authConfiguration.KEY,

                        ValidateIssuer = true,
                        ValidIssuer = authConfiguration.ISSUER,

                        ValidateAudience = true,
                        ValidAudience = authConfiguration.AUDIENCE,

                        ValidateLifetime = true,

                        ClockSkew = TimeSpan.Zero
                    };
                });
        }
    }
}
