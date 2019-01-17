using Autofac;
using MicrosservicoExemplo.Application.UseCases.Contas;
using MicrosservicoExemplo.Domain.Contas.Repositorios;
using MicrosservicoExemplo.Domain.Contas.Servicos;
using MicrosservicoExemplo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicrosservicoExemplo.Infrastructure.DependencyInjection.Modules
{
    public class ContasModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContaCorrenteServico>().As<IContaCorrenteServico>().InstancePerLifetimeScope();
            builder.RegisterType<InMemoryRepository>().As<IContaCorrenteRepositorio>().SingleInstance();

            builder.RegisterType<TransferenciaUseCase>().As<ITransferenciaUseCase>().InstancePerLifetimeScope();
        }
    }
}
