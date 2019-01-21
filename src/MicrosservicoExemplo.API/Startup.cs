using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MicrosservicoExemplo.Application;
using MicrosservicoExemplo.Application.UseCases.Contas;
using MicrosservicoExemplo.Domain.Contas.Repositorios;
using MicrosservicoExemplo.Infrastructure.Data;
using MicrosservicoExemplo.Infrastructure.Web;
using MicrosservicoExemplo.Infrastructure.Web.Filters;

namespace MicrosservicoExemplo.API
{
    public class Startup
    {
        //private IApplicationStartup _startup;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IContaCorrenteRepositorio, InMemoryRepository>();
            services.AddScoped<INotificationContext, NotificationContext>();
            services.AddScoped<ITransferenciaUseCase, TransferenciaUseCase>();
            services.AddScoped<ICadastrarContaCorrenteUseCase, CadastrarContaCorrenteUseCase>();

            services.AddMvc(options =>
            {
                options.Filters.Add<NotificationHandlerFilter>();
            });

            services.AddMetrics();
            //_startup = services.BuildServiceProvider().GetRequiredService<IApplicationStartup>();
            //_startup.ConfigureServices(services);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            
            //_startup.ConfigureContainer(builder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // app.UseMiddleware<NotificationHandlerMiddleware>();
            app.UseMvc();
            //_startup.Configure(app, env);
        }
    }
}
