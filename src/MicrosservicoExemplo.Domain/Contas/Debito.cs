using MicrosservicoExemplo.Domain.ValueObjects;
using System;

namespace MicrosservicoExemplo.Domain.Contas
{
    public class Debito:Lancamento
    {
        public Debito(ContaCorrente conta, Valor valor)
            :base(Guid.NewGuid(), conta,valor)
        {

        }
    }
}
