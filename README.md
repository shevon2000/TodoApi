# TodoApi

A RESTful API for managing todo items built with ASP.NET Core, designed for beginners learning web API development.

## Description

TodoApi is a simple, lightweight API that allows you to create, read, update, and delete todo items. It's built using ASP.NET Core and follows RESTful principles. This project is intended as a learning resource for developers who are new to .NET Web APIs and want to understand layered architecture implementation.

## Why This Project Matters

This project is dedicated to developers who are willing to create .NET Web APIs and Applications. For beginners who want to follow layered architecture for their projects, this serves as an excellent starting point.

### Benefits of Using APIs for Application Backend

Unlike traditional approaches, Web APIs offer numerous advantages:

- **Security**: Better protection of your data and business logic
- **Separation of Concerns**: Clear distinction between frontend and backend
- **Implementation Hiding**: Users only interact with what they need to see
- **Scalability**: Easier to scale backend services independently
- **Reusability**: Same API can serve multiple client applications

The project demonstrates concepts like DTOs, repositories, and proper API design that you can implement in your own projects. For more advanced implementations of these concepts, check out my other projects.

## Features

- Create new todo items
- Retrieve a list of all todo items
- Retrieve a specific todo item by ID
- Update existing todo items
- Delete todo items
- Filter todos by completion status
- Search todos by name

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- SQL Server (or your database of choice)
- Swagger/OpenAPI for documentation
- React (frontend)

## Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or newer
- [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- [Node.js and npm](https://nodejs.org/) (for frontend)
- Database (SQL Server, SQLite, etc.)

## Getting Started

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/shevon2000/TodoApi.git
   cd TodoApi
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Update the connection string in `appsettings.json` to point to your database.

4. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

5. Run the API:
   ```bash
   dotnet run
   ```

   The API will be available at `https://localhost:5001` or `http://localhost:5000`.

6. In a separate terminal, run the frontend:
   ```bash
   cd client
   npm install
   npm start
   ```

   The React frontend will be available at `http://localhost:3000`.

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET    | /api/todos | Get all todo items |
| GET    | /api/todos/{id} | Get a specific todo item |
| POST   | /api/todos | Create a new todo item |
| PUT    | /api/todos/{id} | Update a todo item |
| DELETE | /api/todos/{id} | Delete a todo item |
| GET    | /api/todos/completed | Get completed todo items |
| GET    | /api/todos/incomplete | Get incomplete todo items |

## Testing with Postman

The repository includes a Postman collection file (`TodoAPI.postman_collection.json`) that contains pre-configured API requests for testing all endpoints. To use it:

1. Import the collection into Postman
2. Ensure your API is running
3. Execute the requests to test the functionality

This is a great way to practice understanding API request handling without needing to build a frontend right away.

## Configuration

The application can be configured in the `appsettings.json` file. Here you can set:

- Database connection string
- Logging options
- CORS policies
- Other application-specific settings

## Project Structure

```
TodoApi/
├── Controllers/        # API controllers
├── Models/             # Data models
├── Data/               # Database context and migrations
├── Services/           # Business logic
├── Properties/         # Configuration properties
├── client/             # React frontend
├── appsettings.json    # Application settings
└── Program.cs          # Application entry point
```

## Next Steps for Learning

After understanding this basic implementation, consider enhancing your knowledge by:

1. Implementing a repository pattern
2. Adding DTOs for better data encapsulation
3. Implementing authentication and authorization
4. Creating more complex data relationships
5. Adding validation and error handling

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Contact

Shevon - [GitHub Profile](https://github.com/shevon2000) | [LinkedIn](https://www.linkedin.com/in/shevon-fernando-2ab2a2122/)

Project Link: [https://github.com/shevon2000/TodoApi](https://github.com/shevon2000/TodoApi)
