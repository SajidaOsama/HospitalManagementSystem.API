Hospital Management System API

A RESTful Web API designed to manage hospital operations, built using C# and ASP.NET Core.

Tech Stack & Architecture

Framework: .NET 10 (C#)

Data Access: Entity Framework Core (EF Core)

Database: SQLite

API Documentation: Swagger / OpenAPI

Architecture: Layered structure (API, Application, Domain, and Infrastructure)

Design Concepts: DTOs, Service Interfaces, and Dependency Injection

Features

CRUD operations for Patients, Doctors, Receptionists, and Appointments.

RESTful API endpoints following standard HTTP methods (GET, POST, PUT, DELETE).

DTOs for request/response data handling and separation of concerns.

Service layer with interfaces and asynchronous operations.

Entity Framework Core for database access and management.

Database relationships using Primary Keys and Foreign Keys.

Database schema management through EF Core Migrations.

API documentation and endpoint testing using Swagger.

Project Structure

API: Controllers and HTTP request handling.

Application: Business services, interfaces, and DTOs.

Domain: Core entities.

Infrastructure: Database context and migrations.

How to Run

Clone the repository:

git clone https://github.com/SajidaOsama/HospitalManagementSystem.API.git

Open the solution in Visual Studio.

Update the SQLite connection string in appsettings.json to a valid local database path.

Apply database migrations:

dotnet ef database update --project HospitalManagementSystem.Infrastructure --startup-project HospitalManagementSystem.API

Run the API and explore the endpoints using Swagger.
