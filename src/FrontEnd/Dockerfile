
FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore FrontEnd/FrontEnd.csproj
WORKDIR /src/FrontEnd
RUN dotnet build FrontEnd.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish FrontEnd.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FrontEnd.dll"]
