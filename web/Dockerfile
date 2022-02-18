FROM node:alpine AS builder-web
WORKDIR /app/web
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build --prod

FROM nginx:latest AS runtime
COPY --from=builder-web /app/web/dist/crud-client /usr/share/nginx/html
COPY --from=builder-web /app/web/nginx.conf  /etc/nginx/conf.d/default.conf
