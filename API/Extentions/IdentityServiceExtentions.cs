using System.Text;
using Core.Entities.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Extentions
{
    public static class IdentityServiceExtentions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
        IConfiguration config){

            var biulder = services.AddIdentityCore<AppUser>();
            biulder = new IdentityBuilder(biulder.UserType,biulder.Services);
            biulder.AddEntityFrameworkStores<AppIdentityDbContext>();
            biulder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option => {

                option.TokenValidationParameters = new TokenValidationParameters {

                 ValidateIssuerSigningKey  = true,
                 IssuerSigningKey =
                 new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:key"])),
                 ValidIssuer = config["Token:Issuer"],
                 ValidateIssuer = true,
                 ValidateAudience = false
                 

                };
            });

            return services;


        }
    }
}