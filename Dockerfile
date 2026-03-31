# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia apenas os arquivos de projeto e a solução para restaurar as dependências
# Isso permite que o Docker cache esta camada se os arquivos .csproj e .sln não mudarem
COPY ./ScreenSound.sln ./
COPY ./ScreenSound.API ./ScreenSound.API
COPY ./ScreenSound.Share.Modelos ./ScreenSound.Share.Modelos
COPY ./ScreenSound.Share.Dados ./ScreenSound.Share.Dados

# Restaura dependências
# O comando dotnet restore pode ser executado na raiz do WORKDIR se a solução estiver lá
# ou você pode especificar o caminho da solução.
RUN dotnet restore

# Copia todo o restante do código
# Agora que as dependências foram restauradas, copiamos o código-fonte completo
COPY . .

# Publica o projeto principal da API
RUN dotnet publish ./ScreenSound.API/ScreenSound.API.csproj -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "ScreenSound.API.dll"]
