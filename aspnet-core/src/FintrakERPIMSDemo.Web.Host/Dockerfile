#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/FintrakERPIMSDemo.Web.Host/FintrakERPIMSDemo.Web.Host.csproj", "src/FintrakERPIMSDemo.Web.Host/"]
COPY ["src/FintrakERPIMSDemo.Web.Core/FintrakERPIMSDemo.Web.Core.csproj", "src/FintrakERPIMSDemo.Web.Core/"]
COPY ["src/FintrakERPIMSDemo.Application/FintrakERPIMSDemo.Application.csproj", "src/FintrakERPIMSDemo.Application/"]
COPY ["src/FintrakERPIMSDemo.Application.Shared/FintrakERPIMSDemo.Application.Shared.csproj", "src/FintrakERPIMSDemo.Application.Shared/"]
COPY ["src/FintrakERPIMSDemo.Core.Shared/FintrakERPIMSDemo.Core.Shared.csproj", "src/FintrakERPIMSDemo.Core.Shared/"]
COPY ["src/FintrakERPIMSDemo.Core/FintrakERPIMSDemo.Core.csproj", "src/FintrakERPIMSDemo.Core/"]
COPY ["src/FintrakERPIMSDemo.EntityFrameworkCore/FintrakERPIMSDemo.EntityFrameworkCore.csproj", "src/FintrakERPIMSDemo.EntityFrameworkCore/"]
COPY ["src/FintrakERPIMSDemo.GraphQL/FintrakERPIMSDemo.GraphQL.csproj", "src/FintrakERPIMSDemo.GraphQL/"]
RUN dotnet restore "src/FintrakERPIMSDemo.Web.Host/FintrakERPIMSDemo.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/FintrakERPIMSDemo.Web.Host"
RUN dotnet build "FintrakERPIMSDemo.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FintrakERPIMSDemo.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FintrakERPIMSDemo.Web.Host.dll"]
