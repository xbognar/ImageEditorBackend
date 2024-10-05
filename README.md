
# Custom Image Editor API Documentation

The Custom Image Editor API is designed to handle and manage image data for a custom image processor and editor frontend, which is built using C++ Qt. The backend, developed using C# and .NET, connects to an MSSQL database. It professionally handles the storage, management, and retrieval of image data, allowing the frontend to fetch image data for rendering and processing. The project is containerized using Docker and Docker Compose to ensure consistent runtime environments.

## Technologies Used

- **Programming Language:** C#
- **Framework:** .NET 8.0
- **Database:** MSSQL
- **ORM:** Entity Framework Core
- **Containerization:** Docker
- **API Documentation:** Swagger
- **Testing:** xUnit, Moq

## Features

- **Image Management:** CRUD operations for handling image data.
- **Global Error Handling:** Centralized handling of exceptions.
- **Integration Tests:** Ensuring the API endpoints function correctly.
- **Unit Tests:** Testing the core logic and services.
- **Automated Scripts:** Simplified start and stop scripts for running the application.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (Must be installed and running on the user's PC)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Project Structure

```
ImageEditorBackend/
├── src/
│   ├── WebAPI/
│   │   ├── Controllers/
│   │   │   └── ImagesController.cs
│   │   ├── Program.cs
│   │   ├── WebAPI.csproj
|   |   ├── Dockerfile
│   │   ├── appsettings.json
│   │   └── ...
│   ├── DataAccess/
│   │   ├── DataAccess/
│   │   │   └── ApplicationDbContext.cs
│   │   ├── Interfaces/
│   │   │   └── IImageService.cs
│   │   ├── Models/
│   │   │   └── Image.cs
│   │   ├── Services/
│   │   │   └── ImageService.cs
│   │   └── DataAccess.csproj
├── tests/
│   └── ImageServiceTests/
│       └── ImageServiceTests.cs
├── docker-compose.yml
├── .env
├── README.md
├── StartBE.bat
└── StopBE.bat
```

### Script Details

- **StartBE.bat:** This script starts Docker Desktop (if not already running), navigates to the project directory, and starts the Docker containers using Docker Compose. It allows the user to run the application with a single click.
- **StopBE.bat:** This script stops all running Docker containers related to the application and stops Docker Desktop. It provides a clean and easy way to shut down the application.

### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/xbognar/ImageEditorBackend.git
   cd CustomImageRendererBackend
   ```

2. **Create a `.env` file in the root directory:**

   ```bash
   SA_PASSWORD=YourStrong@Passw0rd
   CONNECTION_STRING="Server=mssql;Database=CustomRendererDB;User Id=sa;Password=YourStrong@Passw0rd;"
   ```

3. **Run the application using the START script:**

   Simply double-click the `START.bat` file. This will automatically start Docker Desktop (if not running), build and run the containers, and set up the application environment.

4. **Apply migrations:**

   Migrations will be applied automatically when the application starts.

## Usage

1. **Starting the API:**

   The API will be available at `http://localhost:80` after running the `START.bat` script.

2. **Stopping the API:**

   To stop the API and Docker containers, double-click the `STOP.bat` file. This will shut down the containers and stop Docker Desktop.

3. **Accessing Swagger:**

   Swagger documentation will be available at `http://localhost:80/swagger/index.html`.

4. **Endpoints:**

   - **Images:**
     - `GET /api/images`
     - `GET /api/images/{id}`
     - `POST /api/images`
     - `PUT /api/images/{id}`
     - `DELETE /api/images/{id}`

## Testing

### Run Unit and Integration Tests:

Run the following commands to execute the tests:

```bash
dotnet test tests/ImageServiceTests/
```

- **Mocking:** The tests use Moq for mocking dependencies, ensuring that the controllers and services are tested in isolation.
- **Endpoint Testing:** Each endpoint is tested to confirm it handles both valid and invalid inputs correctly, verifying the business logic.
