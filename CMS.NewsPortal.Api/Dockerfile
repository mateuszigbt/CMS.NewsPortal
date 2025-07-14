FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

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

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CMS.NewsPortal.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMS.NewsPortal.Api.dll"]