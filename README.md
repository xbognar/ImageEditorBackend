
# Image Editor API Documentation

The Image Editor API is designed to manage image data, including functionalities for adding, updating, retrieving, and deleting image records. The backend is developed using C# and .NET, with an MSSQL database. The project is designed to run locally, utilizing Docker containers for both the database and backend services. This setup provides an efficient environment for managing image data.

## Technologies Used

- **Programming Language:** C#
- **Framework:** .NET 8.0
- **Database:** MSSQL
- **Data Access:** Dapper
- **Containerization:** Docker
- **API Documentation:** Swagger

## Features

- **Image Management:** CRUD operations for images.
- **Database Migrations:** Automated database migrations using DbUp.
- **Swagger Documentation:** Easy-to-use API documentation.
- **Docker Support:** Containerized environment for consistent deployment.

## Project Structure

```
ImageEditorBackend/
├── src/
│   ├── WebAPI/
│   │   ├── Controllers/
│   │   │   └── ImagesController.cs
│   │   ├── Migrations/
│   │   │   └── 001_CreateImageTable.sql
│   │   ├── Program.cs
│   │   ├── WebAPI.csproj
│   ├── DataAccess/
│   │   ├── Database/
│   │   │   └── ApplicationDbContext.cs
│   │   ├── Models/
│   │   │   └── Image.cs
│   │   ├── Queries/
│   │   │   ├── DeleteImage.sql
│   │   │   ├── GetAllImages.sql
│   │   │   ├── GetImageById.sql
│   │   │   ├── InsertImage.sql
│   │   │   └── UpdateImage.sql
│   │   ├── Services/
│   │   │   ├── Interfaces/
│   │   │   │   ├── IImageService.cs
│   │   │   │   ├── IQueryService.cs
│   │   │   ├── ImageService.cs
│   │   │   └── QueryService.cs
├── docker-compose.yaml
├── .env
├── README.md
├── START3.bat
└── STOP3.bat
```

## Script Details

- **START3.bat:** This script starts Docker Desktop (if not already running), navigates to the project directory, and starts the Docker containers using Docker Compose. It allows the user to run the application with a single click.
- **STOP3.bat:** This script stops all running Docker containers related to the application and stops Docker Desktop. It provides a clean and easy way to shut down the application.

## Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/yourusername/ImageEditorBackend.git
   cd ImageEditorBackend
   ```

2. **Create a `.env` file in the root directory with your own secure values:**

   ```bash
   SA_PASSWORD=YourSecurePassword
   CONNECTION_STRING="Server=mssql;Database=ImageEditorDB;User Id=sa;Password=YourSecurePassword;"
   ```

3. **Run the application using the START script:**

   Simply double-click the `START3.bat` file. This will automatically start Docker Desktop (if not running), build and run the containers, and set up the application environment.

4. **Apply migrations:**

   Migrations will be applied automatically when the application starts.

## Usage

1. **Starting the API:**

   The API will be available at `http://localhost:8080` after running the `START3.bat` script.

2. **Stopping the API:**

   To stop the API and Docker containers, double-click the `STOP3.bat` file. This will shut down the containers and stop Docker Desktop.

3. **Accessing Swagger:**

   Swagger documentation will be available at `http://localhost:8080/swagger`.

## Endpoints

  - **Images:**
     - `GET /api/images`
     - `GET /api/images/{id}`
     - `POST /api/images`
     - `PUT /api/images/{id}`
     - `DELETE /api/images/{id}`

---

## Database Migrations

#### DbUp:

The application uses DbUp for database migrations. The SQL scripts are located in the `Migrations` folder within the `WebAPI` project.

#### Automatic Migrations:

Migrations are applied automatically when the application starts. The `Program.cs` file contains the logic to perform the migrations.

---

## Configuration

#### Environment Variables:

The application uses environment variables for configuration, specified in the `.env` file in the root directory.

- **SA_PASSWORD**: The SQL Server administrator password.
- **ConnectionStrings__DefaultConnection**: The connection string for the database.

#### Dockerfile:

The `Dockerfile` in the `WebAPI` project defines the build steps for the backend API container.

#### Docker Compose:

The `docker-compose.yaml` file defines the services:

- **imageprocessingapi**: The backend API service.
- **mssql**: The SQL Server database service.
