FROM node:16-alpine AS builder
WORKDIR /app
EXPOSE 3000
COPY package.json  ./
RUN npm install
RUN npm run build
COPY . ./

FROM nginx:latest
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*
COPY --from=builder /app/dist .
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
ENTRYPOINT ["nginx", "-g", "daemon off;"]
