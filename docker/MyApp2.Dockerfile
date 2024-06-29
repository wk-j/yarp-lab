# Dockerfile for MyApp2
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/MyApp2/MyApp2.csproj", "src/MyApp2/"]
RUN dotnet restore "src/MyApp2/MyApp2.csproj"
COPY . .
WORKDIR "/src/src/MyApp2"
RUN dotnet build "MyApp2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyApp2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyApp2.dll"]