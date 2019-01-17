using MicrosservicoExemplo.Domain.Contas;
using MicrosservicoExemplo.Domain.Contas.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicrosservicoExemplo.Infrastructure.Data
{
    public class InMemoryRepository : IContaCorrenteRepositorio
    {
        private Dictionary<int,ContaCorrente> _db = new Dictionary<int, ContaCorrente> ();

        public ContaCorrente Obter(int numeroConta)
        {
            if (!_db.ContainsKey(numeroConta))
            {
                return null;
            }
            return _db[numeroConta];
        }

        public void Salvar(ContaCorrente conta)
        {
            _db[conta.Conta] = conta;
        }
    }
}
