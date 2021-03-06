﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicrosservicoExemplo.Infrastructure.Bootstrap;

namespace MicrosservicoExemplo.API
{
    public class Startup
    {
        private ApplicationStartup _startup;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _startup = new ApplicationStartup();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _startup.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            _startup.Configure(app, env);
        }
    }
}
