# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Define las variables de entorno
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ConnectionStrings__ConnectionDBSQL: "Server=localhost;Database=AlicundeDB;TrustServerCertificate=True;MultiSubnetFailover=True;Trusted_Connection=False;User Id=sa;Password=D@rioSn0w;"
ENV ConnectionStrings__EndpointEsett:"https://api.opendata.esett.com/EXP01/BalanceServiceProviders"

# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApp.csproj", "."]
RUN dotnet restore "./WebApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApp.dll"]