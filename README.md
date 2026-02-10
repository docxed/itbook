# IT Book Online Shop API

## Prerequisites
- .NET 8 SDK
- SQL Server 2022
- Docker (Optional for Docker Setup)

## Setup (Locally)
1. Add `.env` (Example Key Click Here)
2. restore dependencies:
```bash
dotnet restore
```
3. Update DB migrations:
```bash
dotnet ef database update
```
4. Run application:
```bash
dotnet run
```
5. Open [Swagger](http://localhost:5005/swagger)

*FYI. DB port: 1433, API port: 5005*

## Setup (Docker) (Recommended)
1. Add `.env` (Example Key Click Here)
2. Run
```bash
docker-compose up --build -d
```
3. Open [Swagger](http://localhost:5000/swagger)

*FYI. DB port: 1433, API port: 5000*
