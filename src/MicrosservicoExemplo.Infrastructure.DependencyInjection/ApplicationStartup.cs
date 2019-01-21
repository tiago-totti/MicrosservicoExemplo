using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MicrosservicoExemplo.Infrastructure.Bootstrap.Extensions.ApplicationBuilder;
using MicrosservicoExemplo.Infrastructure.Bootstrap.Extensions.ServiceCollection;
using MicrosservicoExemplo.Infrastructure.Web.Filters;

namespace MicrosservicoExemplo.Infrastructure.Bootstrap
{
    public class ApplicationStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContas();
          
            services.AddMvc(options =>
            {
                options.Filters.Add<NotificationHandlerFilter>();
            });

            services.AddMicrosservicoExemploSwagger();
            services.AddMetrics();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMicrosservicoExemploSwagger();
            app.UseMvc();
        }
    }
}
