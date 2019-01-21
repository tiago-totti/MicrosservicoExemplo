## Microsserviço Exemplo




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
