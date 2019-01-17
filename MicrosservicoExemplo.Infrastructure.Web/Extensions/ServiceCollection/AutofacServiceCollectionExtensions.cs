using Autofac;
using MicrosservicoExemplo.Infrastructure.Bootstrap.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicrosservicoExemplo.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class AutofacServiceCollectionExtensions
    {
        public static void ConfigureModules(this ContainerBuilder builder)
        {
            builder.RegisterModule<ContasModule>();
        }
    }
}
