using Flunt.Notifications;
using MicrosservicoExemplo.Domain.Contas;
using System.Collections.Generic;

namespace MicrosservicoExemplo.Application.UseCases.Contas
{
    public class CadastrarContaCorrenteResult  
    {
        public int Agencia { get; set; }
        public int Conta { get; set; }

      

        public static CadastrarContaCorrenteResult FromDomain(ContaCorrente contaCorrente)
        {
            return new CadastrarContaCorrenteResult
            {
                Agencia = contaCorrente.Agencia,
                Conta = contaCorrente.Conta
            };
        }

        
 
    }
}
