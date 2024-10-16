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

            // Repositories:
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ICourtRepository, CourtRepository>();
            services.AddScoped<ICourtSlotRepository, CourtSlotRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewReplyRepository, ReviewReplyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Services:
            // Authentication
            var key = Encoding.ASCII.GetBytes("YourSecretKeyHere");
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
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
