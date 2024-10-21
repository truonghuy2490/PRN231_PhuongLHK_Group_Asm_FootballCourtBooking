using FBS.BusinessLogics.Services;
using FBS.BusinessObjects.BusinessModels;
using FBS.Repositories;
using FBS.Repositories.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FBS.API.DependencyInjections
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Mapper
            services.AddAutoMapper(typeof(MapperConfig).Assembly);

            // Add database
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICourtService, CourtService>();
            services.AddScoped<ICourtSlotService, CourtSlotService>();
            services.AddScoped<IReviewReplyService,  ReviewReplyService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IUserService, UserService>();

            // IUnitOfWork 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories:
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICourtRepository, CourtRepository>();
            services.AddScoped<ICourtSlotRepository, CourtSlotRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewReplyRepository, ReviewReplyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Services:
            // Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"] ?? string.Empty)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero // Optional: reduce clock skew for testing
                };
            });
            return services;
        }
    }
}
