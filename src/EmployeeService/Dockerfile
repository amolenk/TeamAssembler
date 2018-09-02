
FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY EmployeeService.csproj EmployeeService/
RUN dotnet restore EmployeeService/EmployeeService.csproj
WORKDIR /src/EmployeeService
COPY . .
RUN dotnet build EmployeeService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EmployeeService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmployeeService.dll"]
