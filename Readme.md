## Microsserviço Exemplo

Esse projeto contém uma estrutura de exemplo para um microsserviço desenvolvido em .Net Core com arquitetura limpa/hexagonal.

A Arquitetura Hexagonal (também conhecida como Portas e Adaptadores) é uma estratégia para dissociar os casos de uso dos detalhes externos. Foi inventado por Alistar Cockburn há mais de 13 anos. 

Ao longo do tempo outros engenheiros trabalharam em veriações dela:
- Onion Architecture - Jeffrey Palermo https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/
- Clean Architecture - Uncle Bob.

Embora estes arquétipos variem em algum ou outro detalhe, todos possuem o mesmo objetivo: 

> Separar a lógica da aplicação de detalhes externos.


Na nossa estrutura, as Regras de Negócios e os Casos de Uso devem ser implementados dentro da Camada Core (Aplicação e Domínio) e serão mantidas em toda a vída do produto.  
Por outro lado tudo que dá suporte a recursos externos são apenas detalhes. Eles podem ser substituídos por diferentes razões, e não queremos que as regras de negócios sejam acopladas ou afetadas por estas mudanças.

Por isso, a divisão do projeto em 
1) Entrypoint (Projeto(s) com WebAPI, listeners de filas, worker de um job agendado, etc.) Não deve ter  regras de negócio nem de aplicação. Apenas obtém as entradas e delega para a camada de aplicação. Pode executar alguma formatação na saída para o formato apropriado do seu consumidor.
2) Core - bibliotecas sem dependencias de frameworks com o principal da aplicação: as Regras de Negócio e Caso de Uso.
   Aqui dividimos em duas camadas: 
   - Domain - onde ficarão as regras de negócio (em tempos de DDD também chamadas de domínio e expressadas através de  entidades, serviços de dominio, value objects, interfaces de repositórios, etc.) 
     Gosto bastante da definição do Uncle Bob para a "camada" de domínio:
    > São as regras de negócios que fazem ou economizariam o dinheiro da empresa, independentemente de terem sido implementadas em um computador. Elas fariam ou economizariam dinheiro mesmo se fossem executadas manualmente.
  - Application  - onde iremos implementar as regras específicas da aplicação. São aquelas regras que existem apemas porquê estamos desenvolvendo este sistema / serviço. Aqui vem nossos casos de uso da aplicação.

3) Infrastructure - aqui são as implementações contretas para todos os "detalhes". É a camada que conhece frameworks e bits da aplicação como qual banco de dados, qual ORM, filtros e middlewares de Web API, etc.


- Mais detalhes sobre a Arquitetura Limpa pode ser encontrada nesse vídeo do UncleBob: https://www.youtube.com/watch?v=Nsjsiz2A9mg
- Outro exemplo, com algumas diferenças, e descrição das camadas e suas responsabilidades pode ser encontrado em https://github.com/ivanpaulovich/clean-architecture-manga 

## TechStack

### Projetos:

No desenvolvimento da solução foram utilizados os seguintes targets de compilação:

- Bibliotecas - .Net Standard 2.0
- Entrypoint\Web API - .Net Core 2.2
- Tests - .Net Core 2.0 / xUnit

### Database Migrations
- EF core 2.0 - Em breve

### Documentação de API 

Estamos usando o pacote [SwashBuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) para gerar a documentação da API no formato OpenAPI / Swagger. Para explorar a API, acesse https://localhost:5000/swagger.

As configurações podem ser encontradas no projeto `MicrosservicoExemplo.Infrastructure.Bootstrap`, nos arquivos `/ApplicationBuilder/SwaggerApplicationBuilderExtensions.cs` e  `/ServiceCollection/SwaggerServiceCollectionExtensions.cs`.

Maiores informações podem ser encontradas na documentação da biblioteca em 
https://github.com/domaindrivendev/Swashbuckle.AspNetCore#include-descriptions-from-xml-comments

### HealthChecks
Utilizamos a biblioteca Microsoft.AspNetCore.Diagnostics.HealthChecks - https://docs.microsoft.com/pt-br/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-2.2.
A configuração está disponível em `MicrosservicoExemplo.Infrastructure.Bootstrap` nos arquivos `/ApplicationBuilderExtensions/HealthChecksApplicationBuilderExtensions` e `/ServiceCollectionExtensions/HealthChecksServiceCollectionExtensions`.

Neste exemplo não configuramos nenhum probe, mas a documentação oficial apresenta exemplos sobre configuração de probes como:
- Servidor de banco de dados: https://docs.microsoft.com/pt-br/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-2.2#database-probe

### Logs
Microsoft.Extension.Logging - https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/logging/?view=aspnetcore-2.2#create-logs
Como a infraestrutura irá caputurar a saída dos containers, para uso junto ao Kubernetes o ConsoleLogging (opção default) é o ideal.

### Métricas

Estamos utilizando a biblioteca [AppMetrics](https://www.app-metrics.io), com formatter para Prometheus.

As métricas básicas (volume de requisições, requisições por status code, etc.) são geradas automaticamente através de hooks no ciclo de vida das requisições do asp.net core. Sua configuração pode ser encontrada em `1-entrypoint\MicrosservicoExemplo.API\Program.cs`.

Métricas de negócio podem ser adicionadas utilizando a API, disponível em https://www.app-metrics.io/getting-started/.

### Testes Unitários

Os testes unitários foram escritos usando XUnit e as seguintes bibliotecas:
- FluentAssertions - https://fluentassertions.com/ - para asserts mais expressivos
- Moq - https://github.com/Moq/moq4/wiki/Quickstart - para mocks

### Testes de integração
- Microsoft.AspNetCore.TestHost - em breve

### Outras libs bacaninhas:
- [Flunt](https://github.com/andrebaltieri/flunt) - Para domain notifications. Foi a unica lib externa utilizada na camada de domínio deste projeto.
- [Refit](https://github.com/reactiveui/refit) - Para criar HTTP clients sem dor
- [Polly](https://github.com/App-vNext/Polly) - Para implementar políticas de CircuitBreaking / Retry