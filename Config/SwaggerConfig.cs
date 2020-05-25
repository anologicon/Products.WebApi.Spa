using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Products.WebApi.Config
{
    public class SwaggerConfig
    {
        const string VersionName = "v1";

        public static void UseSwagger(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"swagger/{VersionName}/swagger.json", "Movies API {VersionName}");
                c.RoutePrefix = string.Empty;
            });
        }
        
        public static void AddSwagger(IServiceCollection services, string runningAssemblyName)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(VersionName, new OpenApiInfo
                {
                    Version = VersionName,
                    Title = $"Product API {VersionName}",
                    Description = "Product API com Swagger",
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{runningAssemblyName}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}