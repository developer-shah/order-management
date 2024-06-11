using App.Domain.Interfaces.Repositories;
using App.Domain.Interfaces;
using App.Domain;
using App.Infrastructure.Repositories;
using WebApp.Api.Controllers;

namespace App.Api.Extensions
{
    public static class Dependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(BaseApiController).Assembly));
            services.AddSingleton<IOrderList, InMemoryOrderList>(); //this will be used to store orders in memory (using singleton)

            services.AddSingleton<IRepository<Order>, OrderRepository<Order>>();
            services.AddSingleton<IRepository<Product>, ProductRepository<Product>>();
            services.AddSingleton<ICustomerRepository<Customer>, CustomerRepository<Customer>>();

            return services;
        }
    }
}
