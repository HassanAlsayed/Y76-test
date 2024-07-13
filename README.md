# Todo App

## Overview
This project is a rest api for Todo app using asp.net webapi and sql server.

## Technologies Used
- .NET Core
- ASP.NET Core
- Entity Framework Core
- sql server 

## Prerequisites
- .NET Core SDK [8.0.302]
- [asp.net webapi,sql server]

## Getting Started
### 1. Clone the Repository
```bash
git clone https://github.com/HassanAlsayed/Y76-test.git
cd Y76-test/y76
### 2. Install Dependencies
dotnet restore
Setup Database 
dotnet ef database update

Running the Application
Development Environment
dotnet run --project y76/y76.csproj

Production Build
dotnet publish -c Release -o ./publish
cd ./publish
dotnet y76.dll

Testing
dotnet test

Deployment
Local Deployment
./publish/deploy.sh



