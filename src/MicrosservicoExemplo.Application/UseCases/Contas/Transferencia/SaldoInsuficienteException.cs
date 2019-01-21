using MicrosservicoExemplo.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MicrosservicoExemplo.Application.UseCases.Contas
{
    public class SaldoInsuficienteException : BusinessException
    {
        private int contaOrigem;
        private double valor;        

        protected SaldoInsuficienteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public SaldoInsuficienteException(int contaOrigem, double valor)
            :base($"A conta {contaOrigem} não possui saldo suficiente para debitar o valor {valor.ToString("c")} ")
        {
            this.contaOrigem = contaOrigem;
            this.valor = valor;
        }
    }
}
