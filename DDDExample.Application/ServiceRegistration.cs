using DDDExample.Application.Classes;
using DDDExample.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DDDExample.Application
{
    public static class ServiceRegistrationApplication
    {

        public static IServiceCollection ApplicationRegistration(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IBasketService, BasketManager>();
            return services;
        }
    }
}
