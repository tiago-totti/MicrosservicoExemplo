using MicrosservicoExemplo.Domain.Contas.Repositorios;
using MicrosservicoExemplo.Domain.Contas.Servicos;

namespace MicrosservicoExemplo.Application.UseCases.Contas
{
    public class TransferenciaUseCase : ITransferenciaUseCase
    {
        private IContaCorrenteServico _contaCorrenteServico;
        private IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public TransferenciaUseCase(IContaCorrenteServico contaCorrenteServico, IContaCorrenteRepositorio contaCorrenteRepositorio)
        {
            _contaCorrenteServico = contaCorrenteServico;
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
        }

        public void Executar(TransferenciaRequest request)
        {
            var contaOrigem = _contaCorrenteRepositorio.Obter(request.ContaOrigem);
            if(contaOrigem == null)
            {
                throw new ContaCorrenteInvalidaException(request.ContaOrigem);
            }

            var contaDestino = _contaCorrenteRepositorio.Obter(request.ContaDestino);
            if (contaDestino == null)
            {
                throw new ContaCorrenteInvalidaException(request.ContaDestino);
            }

            var saldoContaOrigem = _contaCorrenteServico.ObterSaldo(contaOrigem.Conta);
            if(saldoContaOrigem < request.Valor)
            {
                throw new SaldoInsuficienteException(request.ContaOrigem, request.Valor);
            }

            contaOrigem.Debitar(request.Valor);
            contaDestino.Creditar(request.Valor);

            //contaCorrenteRepositorio.UnitOfWork.BeginTransaction();
            _contaCorrenteRepositorio.Salvar(contaOrigem);
            _contaCorrenteRepositorio.Salvar(contaDestino);
            //contaCorrenteRepositorio.UnitOfWork.CommitTransaction();
        }
    }
}
