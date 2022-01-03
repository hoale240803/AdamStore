#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Development 

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY "API/API.sln" "API/API.sln"
COPY ["API/API.csproj", "API/API.csproj"]

COPY ["Application/Application.csproj", "Application/Application.csproj"]
COPY ["Data/Data.csproj", "Data/Data.csproj"]
COPY ["Shared.Utilities/Shared.Utilities.csproj", "Shared.Utilities/Shared.Utilities.csproj"]
COPY ["ViewModels/ViewModels.csproj","ViewModels/ViewModels.csproj"]

RUN dotnet restore "API/API.csproj"
COPY . .


WORKDIR "/src/."
RUN dotnet build "API/API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API/API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]





####### run sql script for data
#FROM mcr.microsoft.com/mssql/server:2017-latest
#
#ENV ACCEPT_EULA=Y
#ENV MSSQL_SA_PASSWORD=Secret123!@#
#ENV MSSQL_PID=Developer
#ENV MSSQL_TCP_PORT=1433
#WORKDIR /src
#
#COPY ./API/docker/db-script/filldata.sql ./db-script/filldata.sql
#RUN (/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" &&  /opt/mssql-tools/bin/sqlcmd -S127.0.0.1 -Usa -PSecret123!@# -i db-script/filldata.sql