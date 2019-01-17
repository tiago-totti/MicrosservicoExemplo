using Autofac;
using MicrosservicoExemplo.Application;
using MicrosservicoExemplo.Application.UseCases.Contas;
using MicrosservicoExemplo.Domain.Contas.Repositorios;
using MicrosservicoExemplo.Domain.Contas.Servicos;
using MicrosservicoExemplo.Infrastructure.Data;

namespace MicrosservicoExemplo.Infrastructure.Bootstrap.Modules
{
    public class ContasModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NotificationContext>().As<INotificationContext>().InstancePerRequest();

            builder.RegisterType<ContaCorrenteServico>().As<IContaCorrenteServico>().InstancePerLifetimeScope();
            builder.RegisterType<InMemoryRepository>().As<IContaCorrenteRepositorio>().SingleInstance();

            builder.RegisterType<TransferenciaUseCase>().As<ITransferenciaUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<CadastrarContaCorrenteUseCase>().As<ICadastrarContaCorrenteUseCase>().InstancePerLifetimeScope();
        }
    }
}
