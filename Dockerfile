# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia csproj e restaura pacotes
COPY *.csproj ./
RUN dotnet restore

# Copia tudo e publica
COPY . ./
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "ScreenSound.API.dll"]
