FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV TZ=America/Sao_Paulo
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HealthCheck.Auth/HealthCheck.Auth.API/HealthCheck.Auth.API.csproj", "HealthCheck.Auth/HealthCheck.Auth.API/"]
COPY ["HealthCheck.Auth/HealthCheck.Auth.Application/HealthCheck.Auth.Application.csproj", "HealthCheck.Auth/HealthCheck.Auth.Application/"]
COPY ["HealthCheck.Auth/HealthCheck.Auth.Domain/HealthCheck.Auth.Domain.csproj", "HealthCheck.Auth/HealthCheck.Auth.Domain/"]
COPY ["HealthCheck.Auth/HealthCheck.Auth.Infrastructure/HealthCheck.Auth.Infrastructure.csproj", "HealthCheck.Auth/HealthCheck.Auth.Infrastructure/"]
COPY ["HealthCheck.Auth/HealthCheck.Auth.IOC/HealthCheck.Auth.IOC.csproj", "HealthCheck.Auth/HealthCheck.Auth.IOC/"]
RUN dotnet restore "HealthCheck.Auth/HealthCheck.Auth.API/HealthCheck.Auth.API.csproj"
COPY . .
WORKDIR "/src/HealthCheck.Auth/HealthCheck.Auth.API"
RUN dotnet build "HealthCheck.Auth.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HealthCheck.Auth.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthCheck.Auth.API.dll"]