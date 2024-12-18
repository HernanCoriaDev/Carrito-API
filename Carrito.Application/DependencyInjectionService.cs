using Carrito.Application.Interfaces.Services;
using Carrito.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Carrito.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();

            services.AddValidatorsFromAssemblyContaining<CartService>();
            services.AddValidatorsFromAssemblyContaining<UserService>();
            services.AddValidatorsFromAssemblyContaining<ProductService>();

            return services;
        }
    }
}
