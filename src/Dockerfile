#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5172
EXPOSE 5443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["cliente.dominio/cliente.dominio.csproj", "cliente.dominio/"]
RUN dotnet restore "cliente.dominio/cliente.dominio.csproj"

COPY ["cliente.aplicacion/cliente.aplicacion.csproj", "cliente.aplicacion/"]
RUN dotnet restore "cliente.aplicacion/cliente.aplicacion.csproj"

COPY ["cliente.persistencia/cliente.persistencia.csproj", "cliente.persistencia/"]
RUN dotnet restore "cliente.persistencia/cliente.persistencia.csproj"

COPY ["cliente.comun/cliente.comun.csproj", "cliente.comun/"]
RUN dotnet restore "cliente.comun/cliente.comun.csproj"

COPY ["Cliente/cliente.api.csproj", "Cliente/"]
RUN dotnet restore "Cliente/cliente.api.csproj"



COPY . .
WORKDIR "/src/cliente.dominio"
RUN dotnet build "cliente.dominio.csproj" -c Release -o /app/build

WORKDIR "/src/cliente.aplicacion"
RUN dotnet build "cliente.aplicacion.csproj" -c Release -o /app/build

WORKDIR "/src/cliente.persistencia"
RUN dotnet build "cliente.persistencia.csproj" -c Release -o /app/build

WORKDIR "/src/cliente.comun"
RUN dotnet build "cliente.comun.csproj" -c Release -o /app/build

WORKDIR "/src/Cliente"
RUN dotnet build "cliente.api.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "cliente.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cliente.api.dll"]