FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BiogenomWeb.Api/BiogenomWeb.Api.csproj", "BiogenomWeb.Api/"]
COPY ["BiogenomWeb.Infrastructure/BiogenomWeb.Infrastructure.csproj", "BiogenomWeb.Infrastructure/"]
COPY ["BiogenomWeb.Application/BiogenomWeb.Application.csproj", "BiogenomWeb.Application/"]
COPY ["BiogenomWeb.Domain/BiogenomWeb.Domain.csproj", "BiogenomWeb.Domain/"]
RUN dotnet restore "./BiogenomWeb.Api/BiogenomWeb.Api.csproj"
COPY . .
WORKDIR "/src/BiogenomWeb.Api"
RUN dotnet build "./BiogenomWeb.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BiogenomWeb.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BiogenomWeb.Api.dll"]