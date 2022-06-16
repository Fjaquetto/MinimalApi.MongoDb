#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MinimalAPI.MongoDB/MinimalAPI.MongoDB.csproj", "MinimalAPI.MongoDB/"]
RUN dotnet restore "MinimalAPI.MongoDB/MinimalAPI.MongoDB.csproj"
COPY . .
WORKDIR "/src/MinimalAPI.MongoDB"
RUN dotnet build "MinimalAPI.MongoDB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MinimalAPI.MongoDB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinimalAPI.MongoDB.dll"]

# FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
# WORKDIR /app
# COPY . .
# RUN dotnet restore
# RUN dotnet publish -o /app/published-app

# FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
# WORKDIR /app
# COPY --from=build /app/published-app /app
# ENTRYPOINT [ "dotnet", "/app/MinimalAPI.MongoDB.dll" ]