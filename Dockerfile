# Añadimos la base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definimos la carpeta de trabajo donde vamos a crear el proyecto/imagen
WORKDIR /src

# Copiamos los proyectos
COPY ["platform.Api/platform.Api.csproj", "platform.Api/"]
COPY ["platform.Application/platform.Application.csproj", "platform.Application/"]
COPY ["platform.Domain/platform.Domain.csproj", "platform.Domain/"]
COPY ["platform.Infrastructure/platform.Infrastructure.csproj", "platform.Infrastructure/"]

# Recuperamos las dependencias
RUN dotnet restore "platform.Api/platform.Api.csproj"

# Copiamos tdo el codigo
COPY . .

# Cambiamos directorio de trabajo
WORKDIR "/src/platform.Api"

# Compilamos el proyecto y guardamos los archivos en una nueva carpeta
RUN dotnet build "platform.Api.csproj" -c Release -o app/build

# cambiamos a publish para compilar el proyecto compilado de build y asi obtenemos el proyecto terminado para el publish
FROM build AS publish

RUN dotnet publish "platform.Api.csproj"  -c Release -o /app/publish

# Utilizamos una nueva imagen mas ligera apartir de la imagen anterior 
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# establecemos al directorio de trabajo
WORKDIR /app

# Copiamos los archivos publicados desde la carpeta anterios
COPY --from=publish /app/publish .

# Exponemos los puertos que usa la aplicacion
EXPOSE 8080

# Definimos el comando que se ejecutara al iniciar el contenedor
ENTRYPOINT ["dotnet", "platform.Api.dll"]