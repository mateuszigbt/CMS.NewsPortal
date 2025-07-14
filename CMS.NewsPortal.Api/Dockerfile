# Zobacz https://aka.ms/customizecontainer, aby dowiedzieć się, jak dostosować kontener debugowania i jak program Visual Studio używa tego pliku Dockerfile do kompilowania obrazów w celu szybszego debugowania.

# Ten etap jest używany podczas uruchamiania z programu VS w trybie szybkim (domyślnie dla konfiguracji debugowania)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Ten etap służy do kompilowania projektu usługi
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CMS.NewsPortal.Api/CMS.NewsPortal.Api.csproj", "CMS.NewsPortal.Api/"]
COPY ["CMS.NewsPortal.Application/CMS.NewsPortal.Application.csproj", "CMS.NewsPortal.Application/"]
COPY ["CMS.NewsPortal.Domain/CMS.NewsPortal.Domain.csproj", "CMS.NewsPortal.Domain/"]
COPY ["CMS.NewsPortal.Infrastructure/CMS.NewsPortal.Infrastructure.csproj", "CMS.NewsPortal.Infrastructure/"]
RUN dotnet restore "./CMS.NewsPortal.Api/CMS.NewsPortal.Api.csproj"
COPY . .
WORKDIR "/src/CMS.NewsPortal.Api"
RUN dotnet build "./CMS.NewsPortal.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Ten etap służy do publikowania projektu usługi do skopiowania do etapu końcowego
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CMS.NewsPortal.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Ten etap jest używany w środowisku produkcyjnym lub w przypadku uruchamiania z programu VS w trybie regularnym (domyślnie, gdy nie jest używana konfiguracja debugowania)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMS.NewsPortal.Api.dll"]