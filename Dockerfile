FROM mysql-db

ENV MYSQL_USER=admin
ENV MYSQL_PASSWORD=admin@taskify
ENV MYSQL_DATABASE=taskify-db

EXPOSE 3306




# The mysql-db is a bitnami/mysql:latest image that I've locally. You should change it to  bitnami/mysql:latest