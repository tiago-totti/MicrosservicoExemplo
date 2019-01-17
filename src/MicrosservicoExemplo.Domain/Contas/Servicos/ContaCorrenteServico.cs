using MicrosservicoExemplo.Domain.Contas.Repositorios;
using MicrosservicoExemplo.Domain.ValueObjects;
using System;
using System.Linq;

namespace MicrosservicoExemplo.Domain.Contas.Servicos
{
    public class ContaCorrenteServico:IContaCorrenteServico
    {
        private readonly IContaCorrenteRepositorio _correnteRepositorio;

        public ContaCorrenteServico(IContaCorrenteRepositorio contaCorrenteRepositorio)
        {
            _correnteRepositorio = contaCorrenteRepositorio;
        }

        public Valor ObterSaldo(int numeroConta)
        {
            var conta = _correnteRepositorio.Obter(numeroConta);

            var creditos = SomarLancamentos<Credito>(conta);
            var debitos = SomarLancamentos<Debito>(conta);

            return creditos - debitos;
        }

        private double SomarLancamentos<T>(ContaCorrente conta) where T:Lancamento
        {
            return conta.Lancamentos.OfType<T>().Select(c => (double)c.Valor).Sum();
        }

    }
}
