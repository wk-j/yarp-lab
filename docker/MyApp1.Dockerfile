# Dockerfile for MyApp1
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/MyApp1/MyApp1.csproj", "src/MyApp1/"]
RUN dotnet restore "src/MyApp1/MyApp1.csproj"
COPY . .
WORKDIR "/src/src/MyApp1"
RUN dotnet build "MyApp1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyApp1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyApp1.dll"]