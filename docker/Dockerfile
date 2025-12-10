FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/Domain/FitnessApp.Domain.csproj", "src/Domain/"]
COPY ["src/Application/FitnessApp.Application.csproj", "src/Application/"]
COPY ["src/Infrastructure/FitnessApp.Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/Api/FitnessApp.Api.csproj", "src/Api/"]

RUN dotnet restore "src/Api/FitnessApp.Api.csproj"

COPY . .

WORKDIR "/src/src/Api"
RUN dotnet publish "FitnessApp.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FitnessApp.Api.dll"]