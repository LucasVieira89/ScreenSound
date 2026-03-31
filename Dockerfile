# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia a solução e restaura os pacotes
COPY *.sln ./
COPY ScreenSound.API/*.csproj ./ScreenSound.API/
RUN dotnet restore

# Copia todo o código e publica
COPY . ./
RUN dotnet publish ScreenSound.API/ScreenSound.API.csproj -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "ScreenSound.API.dll"]
