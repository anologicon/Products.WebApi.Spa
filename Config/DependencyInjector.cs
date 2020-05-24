using System.Reflection.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Products.WebApi.Repository;
using Products.WebApi.Services;

namespace Products.WebApi.Config
{
    public class DependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Data
            services.AddScoped<ProductsApiDbContext>();
            services.AddScoped<ProductRepository>();
            
            // Services
            services.AddScoped<ProductService>();

        }
    }
}