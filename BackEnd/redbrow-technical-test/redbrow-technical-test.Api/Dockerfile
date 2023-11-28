#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["redbrow-technical-test.Api/redbrow-technical-test.Api.csproj", "redbrow-technical-test.Api/"]
RUN dotnet restore "./redbrow-technical-test.Api/./redbrow-technical-test.Api.csproj"
COPY . .
WORKDIR "/src/redbrow-technical-test.Api"
RUN dotnet build "./redbrow-technical-test.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./redbrow-technical-test.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "redbrow-technical-test.Api.dll"]