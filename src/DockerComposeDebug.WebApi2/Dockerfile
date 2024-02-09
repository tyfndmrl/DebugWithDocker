#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/DockerComposeDebug.WebApi2/DockerComposeDebug.WebApi2.csproj", "src/DockerComposeDebug.WebApi2/"]
RUN dotnet restore "./src/DockerComposeDebug.WebApi2/./DockerComposeDebug.WebApi2.csproj"
COPY . .
WORKDIR "/src/src/DockerComposeDebug.WebApi2"
RUN dotnet build "./DockerComposeDebug.WebApi2.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DockerComposeDebug.WebApi2.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerComposeDebug.WebApi2.dll"]