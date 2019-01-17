using FluentAssertions;
using MicrosservicoExemplo.Domain.Contas;
using MicrosservicoExemplo.Domain.Contas.Repositorios;
using MicrosservicoExemplo.Domain.Contas.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MicrosservicosExemplo.Domain.Tests.Contas.Servicos
{
    public class ContaCorrenteServicoTest
    {
        [Fact]
        public void Deve_calcular_saldo_de_uma_conta_corrente()
        {
            int numeroConta = 100;

            var conta = new ContaCorrente(Guid.NewGuid() ,1, numeroConta);
            conta.Creditar(1000);
            conta.Debitar(100);
            
            var contaCorrenteRepositorioMoq = new Mock<IContaCorrenteRepositorio>();
            contaCorrenteRepositorioMoq.Setup(r => r.Obter(It.IsAny<int>())).Returns(conta);

            IContaCorrenteRepositorio contaCorrenteRepositorio = contaCorrenteRepositorioMoq.Object; ;
            var contaCorrenteServico = new ContaCorrenteServico(contaCorrenteRepositorio);

            var saldo = contaCorrenteServico.ObterSaldo(numeroConta);
            saldo.Should().Be(900.0);
        }
    }
}


