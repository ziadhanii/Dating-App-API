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
  - Profile photos support

- **Repository Pattern Implementation**
  - Clean architecture with repository pattern
  - Separation of concerns
  - Testable and maintainable code

- **Data Seeding**
  - Automatic database seeding with sample data
  - JSON-based seed data configuration
  - Development environment data population

- **Database**
  - Entity Framework Core integration
  - SQLite database
  - Code-first migrations
  - Optimized queries with async operations

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
│   ├── AccountController.cs
│   ├── MembersController.cs
│   └── BuggyController.cs
├── Data/              # Database context and migrations
│   ├── AppDbContext.cs
│   ├── Seed.cs
│   ├── UserSeedData.json
│   └── Migrations/
├── DTOs/              # Data Transfer Objects
│   ├── LoginRequestDto.cs
│   ├── RegisterRequestDto.cs
│   ├── UserDto.cs
│   └── SeedUserDto.cs
├── Entities/          # Database entities
│   ├── AppUser.cs
│   ├── Member.cs
│   └── Photo.cs
├── Interfaces/        # Service interfaces
│   ├── ITokenService.cs
│   └── IMemberRepository.cs
├── Services/          # Business logic and repositories
│   ├── TokenService.cs
│   └── MemberRepository.cs
├── Middleware/        # Custom middleware
│   └── ExceptionMiddleware.cs
├── Errors/            # Error handling models
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

4. Seed the database with sample data (optional):
   
   The application will automatically seed the database on startup if running in Development mode.
   Seed data is located in `Data/UserSeedData.json`.

5. Run the application:

   ```bash
   dotnet run
   ```

The API will be available at `https://localhost:5001` (or the port specified in launchSettings.json)

## API Endpoints

### Authentication

- `POST /api/account/register` - Register a new user
  - Body: `{ "username": "string", "password": "string" }`
  - Returns: User object with JWT token

- `POST /api/account/login` - Login user
  - Body: `{ "username": "string", "password": "string" }`
  - Returns: User object with JWT token

### Members

- `GET /api/members` - Get all members (requires authentication)
  - Returns: List of member profiles

- `GET /api/members/{username}` - Get member by username (requires authentication)
  - Returns: Member profile details with photos

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

## Key Components

### Entities

- **AppUser**: Core user entity with authentication details
- **Member**: Extended user profile with personal information
- **Photo**: User profile photos with URL and approval status

### Repository Pattern

The application implements the Repository Pattern for data access:

- **IMemberRepository**: Interface defining member data operations
- **MemberRepository**: Implementation with async database operations

### Data Seeding

The application includes automatic data seeding functionality:
- Seed data defined in `Data/UserSeedData.json`
- Automatically runs on application startup in Development mode
- Creates sample users with complete profile information

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
