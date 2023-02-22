#!/bin/bash

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
    

COPY *.csproj ./
RUN dotnet restore

COPY ./ ./

RUN dotnet publish -c Release -o out
    

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

COPY ../Database/ ./Database/

EXPOSE 8080

ENTRYPOINT ["dotnet", "Itzz.dll"]