#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/FintrakERPIMSDemo.Migrator/FintrakERPIMSDemo.Migrator.csproj", "src/FintrakERPIMSDemo.Migrator/"]
COPY ["src/FintrakERPIMSDemo.EntityFrameworkCore/FintrakERPIMSDemo.EntityFrameworkCore.csproj", "src/FintrakERPIMSDemo.EntityFrameworkCore/"]
COPY ["src/FintrakERPIMSDemo.Core/FintrakERPIMSDemo.Core.csproj", "src/FintrakERPIMSDemo.Core/"]
COPY ["src/FintrakERPIMSDemo.Core.Shared/FintrakERPIMSDemo.Core.Shared.csproj", "src/FintrakERPIMSDemo.Core.Shared/"]
RUN dotnet restore "src/FintrakERPIMSDemo.Migrator/FintrakERPIMSDemo.Migrator.csproj"
COPY . .
WORKDIR "/src/src/FintrakERPIMSDemo.Migrator"
RUN dotnet build "FintrakERPIMSDemo.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FintrakERPIMSDemo.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FintrakERPIMSDemo.Migrator.dll"]
