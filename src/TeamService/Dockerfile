
FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY TeamService.csproj TeamService/
RUN dotnet restore TeamService/TeamService.csproj
WORKDIR /src/TeamService
COPY . .
RUN dotnet build TeamService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TeamService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TeamService.dll"]
