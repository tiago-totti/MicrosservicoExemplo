namespace MicrosservicoExemplo.Application.UseCases.Contas
{
    public interface ICadastrarContaCorrenteUseCase
    {
        CadastrarContaCorrenteResult Executar(CadastrarContaCorrenteRequest request);
    }
}