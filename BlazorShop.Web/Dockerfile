FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlazorShop.Web/BlazorShop.Web.csproj", "BlazorShop.Web/"]
COPY ["BlazorShop.Models/BlazorShop.Models.csproj", "BlazorShop.Models/"]
RUN dotnet restore "BlazorShop.Web/BlazorShop.Web.csproj"

COPY . .
WORKDIR "/src/BlazorShop.Web"
RUN dotnet build "BlazorShop.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BlazorShop.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf