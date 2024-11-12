# Use the official .NET 8.0 SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj files and restore dependencies
COPY ["src/WebAPI/WebAPI.csproj", "src/WebAPI/"]
COPY ["src/DataAccess/DataAccess.csproj", "src/DataAccess/"]
RUN dotnet restore "src/WebAPI/WebAPI.csproj"

# Copy the full source code and build the application
COPY src/ ./src/
WORKDIR "/app/src/WebAPI"
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish

# Use the official .NET 8.0 runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 80
EXPOSE 80

# Set the entry point for the container
ENTRYPOINT ["dotnet", "WebAPI.dll"]
