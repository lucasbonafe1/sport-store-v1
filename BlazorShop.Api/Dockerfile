# fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080

# fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BlazorShop.Api/BlazorShop.Api.csproj", "BlazorShop.Api/"]
COPY ["BlazorShop.Models/BlazorShop.Models.csproj", "BlazorShop.Models/"]
RUN dotnet restore "BlazorShop.Api/BlazorShop.Api.csproj"

COPY . .
WORKDIR "/src/BlazorShop.Api"
RUN dotnet build "BlazorShop.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BlazorShop.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorShop.Api.dll"]