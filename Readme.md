## Microsservi�o Exemplo




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
