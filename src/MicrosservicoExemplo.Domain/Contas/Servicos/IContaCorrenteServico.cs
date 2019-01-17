using MicrosservicoExemplo.Domain.ValueObjects;

namespace MicrosservicoExemplo.Domain.Contas.Servicos
{
    public interface IContaCorrenteServico
    {
        Valor ObterSaldo(int numeroConta);
    }
}