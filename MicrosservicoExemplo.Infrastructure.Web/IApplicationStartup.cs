using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MicrosservicoExemplo.Infrastructure.Web
{
    public interface IApplicationStartup
    {
        void Configure(IApplicationBuilder app, IHostingEnvironment env);
        void ConfigureContainer(ContainerBuilder container);
        void ConfigureServices(IServiceCollection services);
    }
}