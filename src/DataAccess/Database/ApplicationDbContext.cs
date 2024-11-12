// DataAccess/Database/ApplicationDbContext.cs
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccess.Database
{
	public class ApplicationDbContext
	{
		private readonly string _connectionString;

		public ApplicationDbContext(string connectionString)
		{
			_connectionString = connectionString
				?? throw new InvalidOperationException("Connection string cannot be null.");
		}

		public IDbConnection CreateConnection()
		{
			return new SqlConnection(_connectionString);
		}
	}
}
