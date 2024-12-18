using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Carrito.API
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Carrito.API",
                    Description = "DANAIDE"
                });
            });

            return services;
        }
    }
}
