FROM node:12.7-alpine AS build
WORKDIR /usr/src/app
COPY . .
RUN npm install
RUN npm run build
### STAGE 2: Run ###
FROM nginx:1.13.8-alpine
WORKDIR /usr/share/nginx/html

COPY --from=build /usr/src/app/dist/projetLaboV1 .
RUN cat /usr/share/nginx/html/assets/nginx/nginx.conf > /etc/nginx/conf.d/default.conf