FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FBS.API/FBS.API.csproj", "FBS.API/"]
COPY ["FBS.BusinessLogics/FBS.BusinessLogics.csproj", "FBS.BusinessLogics/"]
COPY ["FBS.BusinessObjects/FBS.BusinessObjects.csproj", "FBS.BusinessObjects/"]
COPY ["FBS.DataAccess/FBS.Repositories.csproj", "FBS.DataAccess/"]
RUN dotnet restore "FBS.API/FBS.API.csproj"
COPY . .
WORKDIR "/src/FBS.API"
RUN dotnet build "FBS.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FBS.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FBS.API.dll"]
