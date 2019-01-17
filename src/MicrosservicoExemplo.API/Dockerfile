FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/MicrosservicoExemplo.API/MicrosservicoExemplo.API.csproj", "src/MicrosservicoExemplo.API/"]
RUN dotnet restore "src/MicrosservicoExemplo.API/MicrosservicoExemplo.API.csproj"
COPY . .
WORKDIR "/src/src/MicrosservicoExemplo.API"
RUN dotnet build "MicrosservicoExemplo.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MicrosservicoExemplo.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicrosservicoExemplo.API.dll"]