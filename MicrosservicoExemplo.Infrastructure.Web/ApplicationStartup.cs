using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicrosservicoExemplo.Infrastructure.Bootstrap.Extensions.ServiceCollection;
using MicrosservicoExemplo.Infrastructure.Web.Middleware;
using System;

namespace MicrosservicoExemplo.Infrastructure.Web
{
    public class ApplicationStartup : IApplicationStartup
    {
        public ApplicationStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.ConfigureModules();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<NotificationHandlerMiddleware>();
            app.UseMvc();
        }
    }
}

//api/