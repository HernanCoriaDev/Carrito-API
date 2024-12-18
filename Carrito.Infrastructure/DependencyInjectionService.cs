using Carrito.Application.Interfaces.Repository;
using Carrito.Application.Interfaces.UnitOfWork;
using Carrito.Infrastructure.DataBase;
using Carrito.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carrito.Infrastructure
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings"]));

            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
