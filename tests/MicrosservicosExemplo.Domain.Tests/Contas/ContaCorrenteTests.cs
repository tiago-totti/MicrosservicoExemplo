using FluentAssertions;
using MicrosservicoExemplo.Domain.Contas;
using MicrosservicoExemplo.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MicrosservicosExemplo.Domain.Tests.Contas
{
    public class ContaCorrenteTests
    {
        [Fact]
        public void Deve_gerar_lancamento_de_credito()
        {
            var credito = new Valor(1000);
            var conta = new ContaCorrente(Guid.NewGuid(), 1, 100);

            conta.Creditar(credito);

            conta.Lancamentos.Count().Should().Be(1);

            var lancamento = conta.Lancamentos.First();
            lancamento.Conta.Should().Be(conta);
            lancamento.Valor.Should().Be(credito);
            lancamento.Should().BeOfType<Credito>();
        }

        [Fact]
        public void Deve_gerar_lancamento_de_debito()
        {
            var debito = new Valor(1000);
            var conta = new ContaCorrente(Guid.NewGuid(), 1, 100);

            conta.Debitar(debito);

            conta.Lancamentos.Count().Should().Be(1);

            var lancamento = conta.Lancamentos.First();
            
            lancamento.Conta.Should().Be(conta);
            lancamento.Valor.Should().Be(debito);
            lancamento.Should().BeOfType<Debito>();
        }
    }
}
