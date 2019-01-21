namespace MicrosservicoExemplo.Application.UseCases.Contas
{
    public interface ITransferenciaUseCase
    {
        void Executar(TransferenciaRequest request);
    }
}