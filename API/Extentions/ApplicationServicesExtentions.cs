using System.Linq;
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extentions
{
    public static class ApplicationServicesExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services){

            services.AddScoped<IOrderService,OrderService>();
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>),(typeof(GenericRepository<>)));
            services.AddSingleton<IBasketRepository,BasketRepository>();
                     
            services.Configure<ApiBehaviorOptions>(options => {

               options.InvalidModelStateResponseFactory = actionConext => {

                   var errors = actionConext
                               .ModelState.Where(e => e.Value.Errors.Count > 0)
                               .SelectMany( x => x.Value.Errors).Select( x => x.ErrorMessage).ToArray();

                   var errorResponse = new ApivalidationErrorResponse{

                       Errors = errors
                   };

                   return new BadRequestObjectResult(errorResponse);
               };

            });

            return services;
        }
    }
}