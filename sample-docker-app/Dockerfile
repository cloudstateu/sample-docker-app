FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["sample-docker-app/sample_docker_app.csproj", "sample-docker-app/"]

RUN dotnet restore "sample-docker-app/sample_docker_app.csproj"
COPY . .
WORKDIR "/src/sample-docker-app"
RUN dotnet build "sample_docker_app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "sample_docker_app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "sample_docker_app.dll"]