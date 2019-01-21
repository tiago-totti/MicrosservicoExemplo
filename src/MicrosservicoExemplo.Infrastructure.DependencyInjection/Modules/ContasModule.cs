using Microsoft.Extensions.DependencyInjection;
using MicrosservicoExemplo.Application;
using MicrosservicoExemplo.Application.UseCases.Contas;
using MicrosservicoExemplo.Domain.Contas.Repositorios;
using MicrosservicoExemplo.Domain.Contas.Servicos;
using MicrosservicoExemplo.Infrastructure.Data;

namespace MicrosservicoExemplo.Infrastructure.DependencyInjection.Modules
{
    public static class ContasModule
    {
        public static void AddContas(this IServiceCollection services)
        {
            services.AddSingleton<IContaCorrenteRepositorio, InMemoryRepository>();
            services.AddScoped<INotificationContext, NotificationContext>();
            services.AddScoped<ITransferenciaUseCase, TransferenciaUseCase>();
            services.AddScoped<ICadastrarContaCorrenteUseCase, CadastrarContaCorrenteUseCase>();
        }
    }
}
