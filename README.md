# IT Book Online Shop API

## Prerequisites
- .NET 8 SDK
- SQL Server 2022
- Docker (Optional for Docker Setup)

## Getting Started
- [Setup (Locally)](#setup-locally)
- [Setup (Docker)](#setup-docker-recommended)
- [Examples usage](#examples-usage)

## Setup (Locally)
1. Add `.env` (Example [Click Here](https://github.com/docxed/itbook/blob/main/itbook/.env.example))
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
1. Add `.env` (Example [Click Here](https://github.com/docxed/itbook/blob/main/itbook/.env.example))
2. Run:
```bash
docker-compose up --build -d
```
3. Open [Swagger](http://localhost:5000/swagger)

*FYI. DB port: 1433, API port: 5000*

## Examples usage
- Register and login

https://github.com/user-attachments/assets/3f8e8ba1-a9da-4b6d-aee6-cc5f2abc8a7f

- Like book

https://github.com/user-attachments/assets/3df9057f-7f15-4435-aab3-0f3378e44f70
