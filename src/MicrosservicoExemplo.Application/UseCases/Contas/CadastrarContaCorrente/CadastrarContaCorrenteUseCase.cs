using MicrosservicoExemplo.Domain.Contas;
using MicrosservicoExemplo.Domain.Contas.Repositorios;
using System;

namespace MicrosservicoExemplo.Application.UseCases.Contas
{
    public class CadastrarContaCorrenteUseCase : ICadastrarContaCorrenteUseCase
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;
        private readonly INotificationContext _notificationContext;

        public CadastrarContaCorrenteUseCase(IContaCorrenteRepositorio contaCorrenteRepositorio, INotificationContext notificationContext)
        {
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
            _notificationContext = notificationContext;
        }

        public CadastrarContaCorrenteResult Executar(CadastrarContaCorrenteRequest request)
        {
            if (_contaCorrenteRepositorio.Obter(request.Conta) != null)
            {
                _notificationContext.AddNotification(nameof(request.Conta), "Conta já cadastrada");
                return new CadastrarContaCorrenteResult();
            }

            ContaCorrente conta = new ContaCorrente(Guid.NewGuid(), request.Agencia, request.Conta);

            if (conta.Invalid)
            {
                _notificationContext.AddNotifications(conta.Notifications);
                return new CadastrarContaCorrenteResult();
            }

            _contaCorrenteRepositorio.Salvar(conta);
            return CadastrarContaCorrenteResult.FromDomain(conta);
        }
    }
}
