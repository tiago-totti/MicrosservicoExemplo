## Microsservi�o Exemplo

Esse projeto cont�m uma estrutura de exemplo para um microsservi�o desenvolvido em .Net Core com arquitetura limpa/hexagonal.

A Arquitetura Hexagonal (tamb�m conhecida como Portas e Adaptadores) � uma estrat�gia para dissociar os casos de uso dos detalhes externos. Foi inventado por Alistar Cockburn h� mais de 13 anos. 

Ao longo do tempo outros engenheiros trabalharam em veria��es dela:
- Onion Architecture - Jeffrey Palermo https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/
- Clean Architecture - Uncle Bob.

Embora estes arqu�tipos variem em algum ou outro detalhe, todos possuem o mesmo objetivo: 

> Separar a l�gica da aplica��o de detalhes externos.


Na nossa estrutura, as Regras de Neg�cios e os Casos de Uso devem ser implementados dentro da Camada Core (Aplica��o e Dom�nio) e ser�o mantidas em toda a v�da do produto.  
Por outro lado tudo que d� suporte a recursos externos s�o apenas detalhes. Eles podem ser substitu�dos por diferentes raz�es, e n�o queremos que as regras de neg�cios sejam acopladas ou afetadas por estas mudan�as.

Por isso, a divis�o do projeto em 
1) Entrypoint (Projeto(s) com WebAPI, listeners de filas, worker de um job agendado, etc.) N�o deve ter  regras de neg�cio nem de aplica��o. Apenas obt�m as entradas e delega para a camada de aplica��o. Pode executar alguma formata��o na sa�da para o formato apropriado do seu consumidor.
2) Core - bibliotecas sem dependencias de frameworks com o principal da aplica��o: as Regras de Neg�cio e Caso de Uso.
   Aqui dividimos em duas camadas: 
   - Domain - onde ficar�o as regras de neg�cio (em tempos de DDD tamb�m chamadas de dom�nio e expressadas atrav�s de  entidades, servi�os de dominio, value objects, interfaces de reposit�rios, etc.) 
     Gosto bastante da defini��o do Uncle Bob para a "camada" de dom�nio:
    > S�o as regras de neg�cios que fazem ou economizariam o dinheiro da empresa, independentemente de terem sido implementadas em um computador. Elas fariam ou economizariam dinheiro mesmo se fossem executadas manualmente.
  - Application  - onde iremos implementar as regras espec�ficas da aplica��o. S�o aquelas regras que existem apemas porqu� estamos desenvolvendo este sistema / servi�o. Aqui vem nossos casos de uso da aplica��o.

3) Infrastructure - aqui s�o as implementa��es contretas para todos os "detalhes". � a camada que conhece frameworks e bits da aplica��o como qual banco de dados, qual ORM, filtros e middlewares de Web API, etc.


- Mais detalhes sobre a Arquitetura Limpa pode ser encontrada nesse v�deo do UncleBob: https://www.youtube.com/watch?v=Nsjsiz2A9mg
- Outro exemplo, com algumas diferen�as, e descri��o das camadas e suas responsabilidades pode ser encontrado em https://github.com/ivanpaulovich/clean-architecture-manga 

## TechStack

### Projetos:

No desenvolvimento da solu��o foram utilizados os seguintes targets de compila��o:

- Bibliotecas - .Net Standard 2.0
- Entrypoint\Web API - .Net Core 2.2
- Tests - .Net Core 2.0 / xUnit

### Database Migrations
- EF core 2.0 - Em breve

### Documenta��o de API 

Estamos usando o pacote [SwashBuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) para gerar a documenta��o da API no formato OpenAPI / Swagger. Para explorar a API, acesse https://localhost:5000/swagger.

As configura��es podem ser encontradas no projeto `MicrosservicoExemplo.Infrastructure.Bootstrap`, nos arquivos `/ApplicationBuilder/SwaggerApplicationBuilderExtensions.cs` e  `/ServiceCollection/SwaggerServiceCollectionExtensions.cs`.

Maiores informa��es podem ser encontradas na documenta��o da biblioteca em 
https://github.com/domaindrivendev/Swashbuckle.AspNetCore#include-descriptions-from-xml-comments

### HealthChecks
Utilizamos a biblioteca Microsoft.AspNetCore.Diagnostics.HealthChecks - https://docs.microsoft.com/pt-br/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-2.2.
A configura��o est� dispon�vel em `MicrosservicoExemplo.Infrastructure.Bootstrap` nos arquivos `/ApplicationBuilderExtensions/HealthChecksApplicationBuilderExtensions` e `/ServiceCollectionExtensions/HealthChecksServiceCollectionExtensions`.

Neste exemplo n�o configuramos nenhum probe, mas a documenta��o oficial apresenta exemplos sobre configura��o de probes como:
- Servidor de banco de dados: https://docs.microsoft.com/pt-br/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-2.2#database-probe

### Logs
Microsoft.Extension.Logging - https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2#create-logs
Como a infraestrutura ir� caputurar a sa�da dos containers, para uso junto ao Kubernetes o ConsoleLogging (op��o default) � o ideal.

### M�tricas

Estamos utilizando a biblioteca [AppMetrics](https://www.app-metrics.io), com formatter para Prometheus.

As m�tricas b�sicas (volume de requisi��es, requisi��es por status code, etc.) s�o geradas automaticamente atrav�s de hooks no ciclo de vida das requisi��es do asp.net core. Sua configura��o pode ser encontrada em `1-entrypoint\MicrosservicoExemplo.API\Program.cs`.

M�tricas de neg�cio podem ser adicionadas utilizando a API, dispon�vel em https://www.app-metrics.io/getting-started/.

### Testes Unit�rios

Os testes unit�rios foram escritos usando XUnit e as seguintes bibliotecas:
- FluentAssertions - https://fluentassertions.com/ - para asserts mais expressivos
- Moq - https://github.com/Moq/moq4/wiki/Quickstart - para mocks

### Testes de integra��o
- Microsoft.AspNetCore.TestHost - em breve

### Outras libs bacaninhas:
- [Flunt](https://github.com/andrebaltieri/flunt) - Para domain notifications. Foi a unica lib externa utilizada na camada de dom�nio deste projeto.
- [Refit](https://github.com/reactiveui/refit) - Para criar HTTP clients sem dor
- [Polly](https://github.com/App-vNext/Polly) - Para implementar pol�ticas de CircuitBreaking / Retry