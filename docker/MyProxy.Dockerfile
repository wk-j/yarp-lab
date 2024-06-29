# Dockerfile for MyProxy
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/MyProxy/MyProxy.csproj", "src/MyProxy/"]
RUN dotnet restore "src/MyProxy/MyProxy.csproj"
COPY . .
WORKDIR "/src/src/MyProxy"
RUN dotnet build "MyProxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyProxy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyProxy.dll"]