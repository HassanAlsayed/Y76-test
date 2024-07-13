Todo App
Overview
This project is a REST API for a Todo app built using ASP.NET Web API and SQL Server.

Technologies Used
.NET Core
ASP.NET Core
Entity Framework Core
SQL Server
Prerequisites
.NET Core SDK 8.0.302
ASP.NET Web API
SQL Server

Getting Started

Steps:

1- Clone the Repository:
git clone https://github.com/HassanAlsayed/Y76-test.git
cd Y76-test/y76

2- Install Dependencies:
dotnet restore

3- Setup Database:
dotnet ef database update

 Running the Application:
1- Development Environment:
dotnet run --project y76/y76.csproj

 Production Build: 
dotnet publish -c Release -o ./publish
cd ./publish
dotnet y76.dll

Testing: 
dotnet test

Local Deployment: 
./publish/deploy.sh

