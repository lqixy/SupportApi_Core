#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["Flutter.Support.Web/Flutter.Support.Web.csproj", "Flutter.Support.Web/"]
#COPY ["Flutter.Support.Application/Flutter.Support.Application.csproj", "Flutter.Support.Application/"]
#COPY ["Flutter.Support.Extension/Flutter.Support.Extension.csproj", "Flutter.Support.Extension/"]
#COPY ["Flutter.Support.Common/Flutter.Support.Common.csproj", "Flutter.Support.Common/"]
#COPY ["Flutter.Support.Domain/Flutter.Support.Domain.csproj", "Flutter.Support.Domain/"]
#COPY ["Flutter.Support.SqlSugar/Flutter.Support.SqlSugar.csproj", "Flutter.Support.SqlSugar/"]
#COPY ["Flutter.Support.QueryServices.Dapper/Flutter.Support.QueryServices.Dapper.csproj", "Flutter.Support.QueryServices.Dapper/"]
#COPY ["Flutter.Support.QueryServices/Flutter.Support.QueryServices.csproj", "Flutter.Support.QueryServices/"]
#COPY ["Flutter.Support.Dapper/Flutter.Support.Dapper.csproj", "Flutter.Support.Dapper/"]
#COPY ["Flutter.Support.Repository/Flutter.Support.Repository.csproj", "Flutter.Support.Repository/"]
#COPY ["Flutter.Support.Dependency/Flutter.Support.Dependency.csproj", "Flutter.Support.Dependency/"]
#COPY ["Flutter.Support.ApiRepository/Flutter.Support.ApiRepository.csproj", "Flutter.Support.ApiRepository/"]
#RUN dotnet restore "Flutter.Support.Web/Flutter.Support.Web.csproj"
COPY . .
#WORKDIR "/src/Flutter.Support.Web"
#RUN dotnet build "Flutter.Support.Web.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Flutter.Support.Web.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Flutter.Support.Web.dll"]