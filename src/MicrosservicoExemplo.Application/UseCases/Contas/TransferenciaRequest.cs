using System;
using System.Collections.Generic;
using System.Text;

namespace MicrosservicoExemplo.Application.UseCases.Contas
{
    public class TransferenciaRequest
    {
        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
        public double Valor { get; set; }
    }
}
