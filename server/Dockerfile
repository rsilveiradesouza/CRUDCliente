FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder
WORKDIR /app/server
COPY . .
RUN dotnet restore
RUN dotnet publish -c release -o ./ --no-restore