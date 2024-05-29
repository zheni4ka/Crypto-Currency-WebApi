using BusinessLogic.Helpers;
using Crypto_Currency_WebApi.Requirements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Crypto_Currency_WebApi
{
    public static class Policies
    {
        public const string PREMIUM_CLIENT = "PremiumClient";
        public const string ADULT = "Adult";
    }
    //public static void AddRequirements(this IServiceCollection services)
    //{
    //    services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
    //}
    public static class ServiceExtentions
    {
        public static void AddJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOpts = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()!;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOpts.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpts.Key)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }
    }
}
