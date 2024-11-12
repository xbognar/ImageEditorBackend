using System;
using System.Reflection;
using System.Threading;
using DataAccess.Database;
using DataAccess.Services;
using DataAccess.Services.Interfaces;
using DbUp;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add environment variables to configuration
builder.Configuration.AddEnvironmentVariables();

// Get the connection string from configuration
string originalConnectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]
	?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Use SqlConnectionStringBuilder to manipulate the connection string
var connectionStringBuilder = new SqlConnectionStringBuilder(originalConnectionString);
string originalDatabase = connectionStringBuilder.InitialCatalog;

// Set InitialCatalog to 'master' to connect to master database
connectionStringBuilder.InitialCatalog = "master";
string masterConnectionString = connectionStringBuilder.ConnectionString;

bool dbReady = false;
int maxRetries = 10;
int delaySeconds = 10;

for (int i = 0; i < maxRetries; i++)
{
	try
	{
		// Try to open a connection to the master database
		using (var connection = new SqlConnection(masterConnectionString))
		{
			connection.Open();

			// Create the database if it doesn't exist
			var cmdText = $@"
						IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'{originalDatabase}')
						BEGIN
							CREATE DATABASE [{originalDatabase}];
						END";
			using (var command = new SqlCommand(cmdText, connection))
			{
				command.ExecuteNonQuery();
			}
		}

		// Restore the original connection string
		connectionStringBuilder.InitialCatalog = originalDatabase;
		string connectionString = connectionStringBuilder.ConnectionString;

		// Run DbUp migrations
		var upgrader = DeployChanges.To
			.SqlDatabase(connectionString)
			.WithScriptsEmbeddedInAssembly(
				Assembly.GetExecutingAssembly(),
				s => s.Contains("Migrations") && s.EndsWith(".sql"))
			.LogToConsole()
			.Build();

		var result = upgrader.PerformUpgrade();
		if (!result.Successful)
		{
			throw new Exception("Database migration failed: " + result.Error);
		}

		dbReady = true;
		break;
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Database not ready yet, retrying in {delaySeconds} seconds... {ex.Message}");
		Thread.Sleep(delaySeconds * 1000);
	}
}

if (!dbReady)
{
	throw new Exception("Failed to connect to the database after multiple retries.");
}

string finalConnectionString = connectionStringBuilder.ConnectionString;
builder.Services.AddSingleton<ApplicationDbContext>(provider => new ApplicationDbContext(finalConnectionString));
builder.Services.AddSingleton<IQueryService, QueryService>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Image Editor API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Image Editor API V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
