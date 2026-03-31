# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia a solução e todos os projetos
COPY ./ScreenSound.sln ./
COPY ./ScreenSound.API ./ScreenSound.API
COPY ./ScreenSound.Share.Modelos ./ScreenSound.Share.Modelos
COPY ./ScreenSound.Share.Dados ./ScreenSound.Share.Dados

# Restaura dependências
RUN dotnet restore

# Copia todo o restante do código
COPY . .

# Publica o projeto principal da API
RUN dotnet publish ./ScreenSound.API/ScreenSound.API.csproj -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "ScreenSound.API.dll"]
