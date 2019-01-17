using Flunt.Notifications;
using Flunt.Validations;
using MicrosservicoExemplo.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace MicrosservicoExemplo.Domain.Contas
{
    public class ContaCorrente : Notifiable, IValidatable
    {
        private ICollection<Lancamento> _lancamentos;

        public ContaCorrente(Guid id, int agencia, int conta, ICollection<Lancamento> lancamentos = null)
        {
            Id = id;
            Agencia = agencia;
            Conta = conta;
            _lancamentos = lancamentos ?? new List<Lancamento>();
            Validate();
        }
        public Guid Id { get; private set; }
        public int Conta { get; private set; }
        public int Agencia { get; private set; }

        public IEnumerable<Lancamento> Lancamentos => _lancamentos;

        public void Creditar(Valor valor)
        {
            var credito = new Credito(this, valor);
            _lancamentos.Add(credito);
        }

        public void Debitar(Valor valor)
        {
            var debito = new Debito(this, valor);
            _lancamentos.Add(debito);
        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .AreEquals(Agencia, 1, nameof(Agencia), "Agência inválida")
                .IsGreaterOrEqualsThan(Conta, 1, nameof(Conta), "Conta inválida"));
        }
    }
}
