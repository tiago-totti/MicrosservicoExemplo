namespace MicrosservicoExemplo.Application.UseCases.Contas
{
    public class CadastrarContaCorrenteRequest
    {
        public int Agencia { get; set; }
        public int Conta { get; set; }
    }
}