using MicrosservicoExemplo.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MicrosservicoExemplo.Application.UseCases.Contas
{
    public class ContaCorrenteInvalidaException : BusinessException
    {
        public int NumeroConta { get; private set; }

        public ContaCorrenteInvalidaException(int numeroConta)
            : this(numeroConta, $"Conta corrente {numeroConta} inválida")
        {
        }

        public ContaCorrenteInvalidaException(int numeroConta, string message)
            :base(message)
        {
            NumeroConta = numeroConta;
        }

        public ContaCorrenteInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ContaCorrenteInvalidaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
