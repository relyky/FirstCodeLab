# Project Overview

This is a .NET 8 Web API project created using Visual Studio. It appears to be a starting point for a web application with a database backend.

## Key Technologies

*   **.NET 8:** The underlying framework for the application.
*   **ASP.NET Core:** Used for building the Web API.
*   **Entity Framework Core:** Used for data access and database management. The connection string in `FirstCodeLab/DatabaseContext/AppDbContext.cs` points to a local SQL Server instance `RELYNB4` and database `MyTestDB`.
*   **Swagger/OpenAPI:** Used for API documentation and testing, accessible at `/swagger` in the development environment.

## Project Structure

*   `FirstCodeLab.sln`: The Visual Studio solution file.
*   `FirstCodeLab/`: The main project directory.
    *   `FirstCodeLab.csproj`: The project file, containing project metadata and dependencies.
    *   `Program.cs`: The main entry point of the application.
    *   `appsettings.json`: Configuration file.
    *   `Controllers/`: Contains API controllers.
        *   `WeatherForecastController.cs`: A sample controller.
    *   `DatabaseContext/`:
        *   `AppDbContext.cs`: The Entity Framework Core database context, defining the database connection and tables.
    *   `Entities/`: Contains the database entities (Customer, Item, Order, OrderItem).
    *   `Properties/`:
        *   `launchSettings.json`: IIS and Kestrel launch settings.

# Building and Running

## Building

To build the project, use the `dotnet build` command in the `FirstCodeLab` directory:

```bash
cd FirstCodeLab
dotnet build
```

## Running

To run the project, use the `dotnet run` command in the `FirstCodeLab` directory:

```bash
cd FirstCodeLab
dotnet run
```

The application will be accessible at the URLs specified in `Properties/launchSettings.json`, typically `https://localhost:7195` and `http://localhost:5195`.

## Testing

There are no tests in this project.

# Development Conventions

*   The project follows the standard .NET API project structure.
*   The connection string is now stored in `appsettings.json` and loaded through configuration.
*   The database schema is created automatically on startup in the development environment.
