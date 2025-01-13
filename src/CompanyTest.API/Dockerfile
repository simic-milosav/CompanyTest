# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CompanyTest.API/CompanyTest.API.csproj", "src/CompanyTest.API/"]
COPY ["src/CompanyTest.Application/CompanyTest.Application/CompanyTest.Application.csproj", "src/CompanyTest.Application/CompanyTest.Application/"]
COPY ["CompanyTest.Domain/CompanyTest.Domain.csproj", "CompanyTest.Domain/"]
COPY ["src/CompanyTest.Contracts/CompanyTest.Contracts/CompanyTest.Contracts.csproj", "src/CompanyTest.Contracts/CompanyTest.Contracts/"]
COPY ["src/CompanyTest.Infrastructure/CompanyTest.Infrastructure/CompanyTest.Infrastructure.csproj", "src/CompanyTest.Infrastructure/CompanyTest.Infrastructure/"]
RUN dotnet restore "./src/CompanyTest.API/CompanyTest.API.csproj"
COPY . .
WORKDIR "/src/src/CompanyTest.API"
RUN dotnet build "./CompanyTest.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CompanyTest.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyTest.API.dll"]