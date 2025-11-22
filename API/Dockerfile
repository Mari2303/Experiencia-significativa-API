FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1️⃣ Copiar todo el proyecto desde el contexto actual
COPY . .

# 2️⃣ Restaurar dependencias (busca automáticamente archivos .sln y .csproj)
RUN dotnet restore

# 3️⃣ Compilar el proyecto API
RUN dotnet build API/API.csproj -c Release -o /app/build

FROM build AS publish
# 4️⃣ Publicar la aplicación
RUN dotnet publish API/API.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]

