using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicrosservicoExemplo.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class HealthChecksServiceCollectionExtensions
    {
        public static void AddMicrosservicoExemploHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();
        }
    }
}
