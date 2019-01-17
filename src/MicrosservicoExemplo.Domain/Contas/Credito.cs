using MicrosservicoExemplo.Domain.ValueObjects;
using System;

namespace MicrosservicoExemplo.Domain.Contas
{
    public class Credito:Lancamento
    {
        public Credito(ContaCorrente conta, Valor valor)
            :base(Guid.NewGuid(), conta,valor)
        {

        }
    }
}
