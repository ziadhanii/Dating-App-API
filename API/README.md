# Dating App API

A RESTful API built with ASP.NET Core for a dating application platform.

## Features

- **User Authentication & Authorization**
  - User registration and login
  - JWT token-based authentication
  - Secure password handling

- **User Management**
  - User profiles with detailed information
  - Member browsing functionality
  - Account management

- **Database**
  - Entity Framework Core integration
  - SQLite database
  - Code-first migrations

## Technologies Used

- **ASP.NET Core** - Web API framework
- **Entity Framework Core** - ORM for database operations
- **SQLite** - Lightweight database
- **JWT (JSON Web Tokens)** - Authentication mechanism
- **C# 10** - Programming language

## Project Structure

```
API/
├── Controllers/        # API endpoints
├── Data/              # Database context and migrations
├── DTOs/              # Data Transfer Objects
├── Entities/          # Database entities
├── Interfaces/        # Service interfaces
├── Services/          # Business logic services
└── Program.cs         # Application entry point
```

## Getting Started

### Prerequisites

- .NET SDK 10.0 or later
- Visual Studio 2022 / VS Code / Rider

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/ziadhanii/Dating-App-API.git
   cd Dating-App-API/API
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Update the database:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

The API will be available at `https://localhost:5001` (or the port specified in launchSettings.json)

## API Endpoints

### Authentication
- `POST /api/account/register` - Register a new user
- `POST /api/account/login` - Login user

### Members
- `GET /api/members` - Get all members
- `GET /api/members/{id}` - Get member by ID

## Configuration

Update `appsettings.json` with your configuration:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=datingapp.db"
  },
  "TokenKey": "your-secret-key-here"
}
```

## Database Migrations

Create a new migration:
```bash
dotnet ef migrations add MigrationName
```

Update database:
```bash
dotnet ef database update
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License.

## Author

[Ziad Hanii](https://github.com/ziadhanii)
