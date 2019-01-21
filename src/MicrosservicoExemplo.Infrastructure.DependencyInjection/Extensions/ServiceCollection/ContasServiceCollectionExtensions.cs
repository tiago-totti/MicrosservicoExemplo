using Microsoft.Extensions.DependencyInjection;
using MicrosservicoExemplo.Application;
using MicrosservicoExemplo.Application.UseCases.Contas;
using MicrosservicoExemplo.Domain.Contas.Repositorios;
using MicrosservicoExemplo.Infrastructure.Data;

namespace MicrosservicoExemplo.Infrastructure.Bootstrap.Extensions.ServiceCollection
{
    public static class ContasServiceCollectionExtensions
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
