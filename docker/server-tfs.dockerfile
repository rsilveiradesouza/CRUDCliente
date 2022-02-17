FROM node:12.20-alpine AS build
WORKDIR /app/web
RUN npm cache clean --force
COPY ./web .
RUN npm install
RUN npm run build --prod

FROM nginx:latest AS ngi
COPY --from=build /app/web/dist/crud-client /usr/share/nginx/html
COPY --from=build /app/web/nginx.conf  /etc/nginx/conf.d/default.conf
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS builder
WORKDIR /app/server

COPY ./server .

RUN dotnet restore
RUN dotnet publish -c release -o /out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS runtime

WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "CRUDCliente.Api.dll"]
