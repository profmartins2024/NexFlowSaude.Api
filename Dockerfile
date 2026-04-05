# BUILD
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["NexFlowSaude.Api.csproj", "./"]
RUN dotnet restore "NexFlowSaude.Api.csproj"

COPY . .
RUN dotnet publish "NexFlowSaude.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# RUNTIME
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

# Render usa variável PORT automaticamente
ENV ASPNETCORE_URLS=http://+:$PORT

ENTRYPOINT ["dotnet", "NexFlowSaude.Api.dll"]