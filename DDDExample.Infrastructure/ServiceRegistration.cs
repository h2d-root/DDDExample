using DDDExample.Infrastructure.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Infrastructure
{
    public static class ServiceRegistrationInfrastructure
    {

        public static IServiceCollection InfrastructureRegistration(this IServiceCollection services)
        {
            services.AddScoped<IUserDal,UserDal>();
            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<ICategoryDal,CategoryDal>();
            services.AddScoped<IOrderDal, OrderDal>();
            services.AddScoped<IBasketDal, BasketDal>();
            return services;
        } 
    }
}
