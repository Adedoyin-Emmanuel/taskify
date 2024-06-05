FROM bitnami/mysql:latest

ENV MYSQL_USER=admin
ENV MYSQL_PASSWORD=admin@taskify
ENV MYSQL_DATABASE=taskify-db
ENV MYSQL_ROOT_PASSWORD=admin@taskify


EXPOSE 3306


