using MicrosservicoExemplo.Domain.ValueObjects;
using System;

namespace MicrosservicoExemplo.Domain.Contas
{
    public abstract class Lancamento
    {
        public Guid Id { get; private set; }

        public ContaCorrente Conta { get; private set; }
        public Valor Valor { get; private set; }

        public Lancamento(Guid id, ContaCorrente conta, Valor valor)
        {
            this.Id = id;
            this.Conta = conta;
            this.Valor = valor;
        }
    }
}
