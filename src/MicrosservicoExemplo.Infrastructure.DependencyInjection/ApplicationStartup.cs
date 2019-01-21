using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MicrosservicoExemplo.Infrastructure.DependencyInjection.Modules;
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

            services.AddMetrics();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
