#base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
LABEL service="SFC.Data.Api" author="Kryvoruk Andrii" email="krivorukandrey@gmail.com"
USER root 
WORKDIR /app

#restore & build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ENV HUSKY=False
WORKDIR /source
COPY ["Directory.Build.props", "."]
COPY ["nuget.config", "."]
COPY ["src/API/SFC.Data.Api/SFC.Data.Api.csproj", "src/API/SFC.Data.Api/"]
COPY ["src/Core/SFC.Data.Application/SFC.Data.Application.csproj", "src/Core/SFC.Data.Application/"]
COPY ["src/Core/SFC.Data.Domain/SFC.Data.Domain.csproj", "src/Core/SFC.Data.Domain/"]
COPY ["src/Infrastructure/SFC.Data.Infrastructure/SFC.Data.Infrastructure.csproj", "src/Infrastructure/SFC.Data.Infrastructure/"]
COPY ["src/Infrastructure/SFC.Data.Infrastructure.Persistence/SFC.Data.Infrastructure.Persistence.csproj", "src/Infrastructure/SFC.Data.Infrastructure.Persistence/"]
COPY ["src/Contracts/SFC.Data.Contracts/SFC.Data.Contracts.csproj", "src/Contracts/SFC.Data.Contracts/"]
COPY ["src/Contracts/SFC.Data.Messages/SFC.Data.Messages.csproj", "src/Contracts/SFC.Data.Messages/"]
RUN dotnet restore "./src/API/SFC.Data.Api/SFC.Data.Api.csproj" --property:HUSKY=$HUSKY
COPY [".", "."]
WORKDIR "/source/src/API/SFC.Data.Api"
RUN dotnet build "./SFC.Data.Api.csproj" --configuration $BUILD_CONFIGURATION --property:HUSKY=$HUSKY --output /app/build

#publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SFC.Data.Api.csproj" --configuration $BUILD_CONFIGURATION --property:HUSKY=$HUSKY --property:UseAppHost=false --output /app/publish

#final
FROM base AS final
ARG HTTP_PORT=8080
ARG HTTPS_PORT=8081
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE $HTTP_PORT
EXPOSE $HTTPS_PORT
ENTRYPOINT ["bash", "entrypoint.sh"]