# Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia a solução e todos os projetos
COPY *.sln ./
COPY ScreenSound.csproj ./           
COPY ScreenSound.API/*.csproj ./ScreenSound.API/
COPY ScreenSound.Share.Dados/*.csproj ./ScreenSound.Share.Dados/
COPY ScreenSound.Share.Modelos/*.csproj ./ScreenSound.Share.Modelos/

# Restaura os pacotes
RUN dotnet restore

# Copia todo o código
COPY . .

# Publica em Release
RUN dotnet publish ScreenSound.API/ScreenSound.API.csproj -c Release -o out

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Porta e inicialização
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_PRINT_TELEMETRY_MESSAGE=false
EXPOSE 8080
ENTRYPOINT ["dotnet", "ScreenSound.API.dll"]
