using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MicrosservicoExemplo.Infrastructure.Web;
using Autofac.Extensions.DependencyInjection;

namespace MicrosservicoExemplo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(s =>
                {
                    s.AddScoped<IApplicationStartup, ApplicationStartup>();
                    s.AddAutofac();
                }
                )
                .UseStartup<Startup>();
    }
}
