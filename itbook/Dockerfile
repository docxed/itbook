# 1. Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy files and build
COPY . ./
RUN dotnet publish -c Release -o out

# 2. Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Install netcat for healthcheck
RUN apt-get update && apt-get install -y netcat-traditional

# Expose port
EXPOSE 8080

# Healthcheck for DB
ENTRYPOINT ["/bin/sh", "-c", "until nc -z db 1433; do echo 'Waiting for DB...'; sleep 2; done; dotnet itbook.dll"]