using DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DataAccess.Services
{
	public class QueryService : IQueryService
	{
		private readonly Dictionary<string, string> _cachedQueries = new();

		public QueryService()
		{
			LoadQueries();
		}

		private void LoadQueries()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resourceNames = assembly.GetManifestResourceNames();

			foreach (var resourceName in resourceNames)
			{
				if (resourceName.EndsWith(".sql", StringComparison.OrdinalIgnoreCase))
				{
					using (var stream = assembly.GetManifestResourceStream(resourceName))
					using (var reader = new StreamReader(stream))
					{
						// Extract the query name from the resource name
						var queryName = Path.GetFileNameWithoutExtension(resourceName);
						if (queryName.Contains("."))
						{
							queryName = queryName.Substring(queryName.LastIndexOf('.') + 1);
						}
						var queryText = reader.ReadToEnd();
						_cachedQueries[queryName] = queryText;
					}
				}
			}
		}

		public string GetQuery(string queryName)
		{
			if (_cachedQueries.TryGetValue(queryName, out var queryText))
			{
				return queryText;
			}

			throw new ArgumentException($"Query '{queryName}' not found in cached queries.");
		}
	}
}
