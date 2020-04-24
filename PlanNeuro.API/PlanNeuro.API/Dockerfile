FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["PlanNeuro.API/PlanNeuro.API.csproj", "PlanNeuro.API/"]
RUN dotnet restore "PlanNeuro.API/PlanNeuro.API.csproj"
COPY . .
WORKDIR "/src/PlanNeuro.API"
RUN dotnet build "PlanNeuro.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PlanNeuro.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PlanNeuro.API.dll"]