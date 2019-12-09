#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MLog.Api/MLog.Api.csproj", "MLog.Api/"]
RUN dotnet restore "MLog.Api/MLog.Api.csproj"
COPY . .
WORKDIR "/src/MLog.Api"
RUN dotnet build "MLog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MLog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MLog.Api.dll"]