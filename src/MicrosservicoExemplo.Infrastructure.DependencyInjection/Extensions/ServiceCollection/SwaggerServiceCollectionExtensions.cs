using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Reflection;

namespace MicrosservicoExemplo.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class SwaggerServiceCollectionExtensions
    {

        public static void AddMicrosservicoExemploSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Microsservico Exemplo API",
                        Version = "v1"
                    }
                 );

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, xmlFile);
                config.IncludeXmlComments(filePath);
            });
        }
    }
}
