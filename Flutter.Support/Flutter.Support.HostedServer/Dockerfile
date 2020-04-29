#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["Flutter.Support.HostedServer/Flutter.Support.HostedServer.csproj", "Flutter.Support.HostedServer/"]
#COPY ["Flutter.Support.Application/Flutter.Support.Application.csproj", "Flutter.Support.Application/"]
#COPY ["Flutter.Support.Extension/Flutter.Support.Extension.csproj", "Flutter.Support.Extension/"]
#COPY ["Flutter.Support.Common/Flutter.Support.Common.csproj", "Flutter.Support.Common/"]
#COPY ["Flutter.Support.Domain/Flutter.Support.Domain.csproj", "Flutter.Support.Domain/"]
#COPY ["Flutter.Support.SqlSugar/Flutter.Support.SqlSugar.csproj", "Flutter.Support.SqlSugar/"]
#COPY ["Flutter.Support.Repository/Flutter.Support.Repository.csproj", "Flutter.Support.Repository/"]
#COPY ["Flutter.Support.Dapper/Flutter.Support.Dapper.csproj", "Flutter.Support.Dapper/"]
#COPY ["Flutter.Support.ApiRepository/Flutter.Support.ApiRepository.csproj", "Flutter.Support.ApiRepository/"]
#RUN dotnet restore "Flutter.Support.HostedServer/Flutter.Support.HostedServer.csproj"
COPY . .
#WORKDIR "/src/Flutter.Support.HostedServer"
#RUN dotnet build "Flutter.Support.HostedServer.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Flutter.Support.HostedServer.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Flutter.Support.HostedServer.dll"]