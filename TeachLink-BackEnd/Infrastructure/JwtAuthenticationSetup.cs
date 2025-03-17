using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace TeachLink_BackEnd.Infrastructure
{
    public static class JwtAuthenticationSetup
    {
        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var jwtSecret = configuration["Authentication:JwtSecret"];
            if (string.IsNullOrEmpty(jwtSecret))
            {
                throw new InvalidOperationException("JWT Secret is not configured.");
            }

            var key = Encoding.UTF8.GetBytes(jwtSecret);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidAudience = configuration["Authentication:ValidAudience"],
                        ValidIssuer = configuration["Authentication:ValidIssuer"],
                    };
                });

            return services;
        }
    }
}
