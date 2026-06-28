# Farmers Market API

A modern ASP.NET Core Web API for managing farmers, produce listings, buyers, and orders in a small agricultural marketplace platform. This project is designed to showcase clean backend architecture, dependency injection, EF Core persistence, and API development in C#.

## Overview

Farmers Market API provides a practical foundation for a marketplace application where:

- Farmers can be registered and managed
- Produce listings can be created and searched
- Buyers can be stored and tracked
- Orders can be placed against listings
- Data is persisted with Entity Framework Core and PostgreSQL

This project is structured to demonstrate solid software engineering practices that are valuable in a C# developer portfolio.

## Features

- ASP.NET Core Web API with Swagger support
- Entity Framework Core with PostgreSQL
- Repository pattern for data access
- Dependency injection for services and repositories
- Seed data for farmers, buyers, produce listings, and orders
- Clean model structure with enums and custom exceptions
- MVC-compatible project layout for future expansion

## Tech Stack

- C# / ASP.NET Core
- .NET 10
- Entity Framework Core
- PostgreSQL with Npgsql
- Swagger / OpenAPI
- Visual Studio / VS Code

## Project Structure

```text
Farmers_Market_API/
├── Controllers/
├── Data/
├── DTOs/
├── Enums/
├── Exceptions/
├── Interfaces/
├── Models/
├── Repositories/
├── Views/
└── wwwroot/
```

## Getting Started

### Prerequisites

- .NET 10 SDK
- PostgreSQL database
- A connection string named DefaultConnection

### Configuration

Update the connection string in the application configuration file:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=farmers_market;Username=postgres;Password=your_password"
  }
}
```

### Run the Application

```bash
dotnet restore
dotnet build
dotnet run
```

Then open the Swagger UI at:

```text
https://localhost:5001/swagger
```

## Database Notes

This project uses EF Core migrations and PostgreSQL. If you want to apply the schema locally, run:

```bash
dotnet ef database update
```

## Why This Project Matters

This API is a strong portfolio example because it demonstrates:

- Real-world domain modeling
- API design and structure
- Data persistence with ORM tools
- Clean separation of concerns
- Practical use of modern .NET features

## Future Improvements

Potential enhancements for the next iteration include:

- Authentication and authorization
- User roles for farmers and buyers
- Order status workflows with notifications
- Advanced filtering and search for produce listings
- Unit and integration tests

## License

This project is intended for educational and portfolio purposes.
