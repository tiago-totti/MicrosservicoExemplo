namespace MicrosservicoExemplo.Domain.Contas.Repositorios
{
    public interface IContaCorrenteRepositorio
    {
        ContaCorrente Obter(int numeroConta);
        void Salvar(ContaCorrente conta);
    }
}
