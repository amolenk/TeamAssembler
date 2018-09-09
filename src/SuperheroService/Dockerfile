
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY . .
RUN dotnet restore SuperheroService/SuperheroService.csproj
WORKDIR /src/SuperheroService
RUN dotnet build SuperheroService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SuperheroService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SuperheroService.dll"]
