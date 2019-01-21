using FluentAssertions;
using MicrosservicoExemplo.Application.UseCases.Contas;
using MicrosservicoExemplo.Domain.Contas;
using MicrosservicoExemplo.Domain.Contas.Repositorios;
using MicrosservicoExemplo.Domain.Contas.Servicos;
using Moq;
using System;
using Xunit;

namespace MicrosservicoExemplo.Application.Tests.UseCases
{
    public class TransferenciaUseCaseTest
    {
        const int Origem = 1;
        const int Destino = 2;
        const int Agencia = 1;
        ContaCorrente ContaOrgiem = new ContaCorrente(Guid.NewGuid(), Agencia, Origem);
        ContaCorrente ContaDestino = new ContaCorrente(Guid.NewGuid(), Agencia, Destino);

        [Fact]
        public void Deve_lancar_excessao_quando_conta_origem_invalida()
        {
            var contaCorrenteServicoMock = new Mock<IContaCorrenteServico>();
            var contaCorrenteRepositorioMock = new Mock<IContaCorrenteRepositorio>();
            contaCorrenteRepositorioMock.Setup(r => r.Obter(It.Is<int>(c => c == Origem)))
                .Returns<ContaCorrente>(null);

            var request = new TransferenciaRequest
            {
                ContaOrigem = Origem,
                ContaDestino = Destino,
                Valor = 300
            };

            TransferenciaUseCase transferenciaUseCase = new TransferenciaUseCase(contaCorrenteServicoMock.Object, contaCorrenteRepositorioMock.Object);
            Action action = () => transferenciaUseCase.Executar(request);
            action.Should().Throw<ContaCorrenteInvalidaException>();
        }

        [Fact]
        public void Deve_lancar_excessao_quando_conta_destino_invalida()
        {
            var contaCorrenteServicoMock = new Mock<IContaCorrenteServico>();
            var contaCorrenteRepositorioMock = new Mock<IContaCorrenteRepositorio>();
            contaCorrenteRepositorioMock.Setup(r => r.Obter(It.Is<int>(c => c == Origem)))
                .Returns(ContaOrgiem);

            contaCorrenteRepositorioMock.Setup(r => r.Obter(It.Is<int>(c => c == Destino)))
                 .Returns<ContaCorrente>(null);

            var request = new TransferenciaRequest
            {
                ContaOrigem = Origem,
                ContaDestino = Destino,
                Valor = 300
            };

            TransferenciaUseCase transferenciaUseCase = new TransferenciaUseCase(contaCorrenteServicoMock.Object, contaCorrenteRepositorioMock.Object);
            Action action = () => transferenciaUseCase.Executar(request);
            action.Should().Throw<ContaCorrenteInvalidaException>();
        }

        [Fact]
        public void Deve_lancar_excessao_quando_saldo_insuficiente()
        {
            var contaCorrenteServicoMock = new Mock<IContaCorrenteServico>();
            contaCorrenteServicoMock.Setup(s => s.ObterSaldo(It.IsAny<int>()))
                .Returns(0);

            var contaCorrenteRepositorioMock = new Mock<IContaCorrenteRepositorio>();
            contaCorrenteRepositorioMock.Setup(r => r.Obter(It.Is<int>(c => c == Origem)))
                .Returns(ContaOrgiem);

            contaCorrenteRepositorioMock.Setup(r => r.Obter(It.Is<int>(c => c == Destino)))
                 .Returns(ContaDestino);

            var request = new TransferenciaRequest
            {
                ContaOrigem = Origem,
                ContaDestino = Destino,
                Valor = 300
            };

            TransferenciaUseCase transferenciaUseCase = new TransferenciaUseCase(contaCorrenteServicoMock.Object, contaCorrenteRepositorioMock.Object);
            Action action = () => transferenciaUseCase.Executar(request);
            action.Should().Throw<SaldoInsuficienteException>();
        }

        [Fact]
        public void Deve_executar_transferencia()
        {
            var contaCorrenteServicoMock = new Mock<IContaCorrenteServico>();
            contaCorrenteServicoMock.Setup(s => s.ObterSaldo(It.IsAny<int>()))
                .Returns(300);

            var contaCorrenteRepositorioMock = new Mock<IContaCorrenteRepositorio>();
            contaCorrenteRepositorioMock.Setup(r => r.Obter(It.Is<int>(c => c == Origem)))
                .Returns(ContaOrgiem);

            contaCorrenteRepositorioMock.Setup(r => r.Obter(It.Is<int>(c => c == Destino)))
                 .Returns(ContaDestino);

            var request = new TransferenciaRequest
            {
                ContaOrigem = Origem,
                ContaDestino = Destino,
                Valor = 300
            };

            var transferenciaUseCase = new TransferenciaUseCase(contaCorrenteServicoMock.Object, contaCorrenteRepositorioMock.Object);
            transferenciaUseCase.Executar(request);

            contaCorrenteRepositorioMock.Verify(r => r.Salvar(It.IsAny<ContaCorrente>()), Times.Exactly(2));           
        }
    }
}
