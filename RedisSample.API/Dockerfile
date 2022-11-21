#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RedisSample.API/RedisSample.API.csproj", "RedisSample.API/"]
RUN dotnet restore "RedisSample.API/RedisSample.API.csproj"
COPY . .
WORKDIR "/src/RedisSample.API"
RUN dotnet build "RedisSample.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedisSample.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedisSample.API.dll"]