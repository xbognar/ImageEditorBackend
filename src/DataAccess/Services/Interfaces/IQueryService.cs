using System.Collections.Generic;

namespace DataAccess.Services.Interfaces
{
	public interface IQueryService
	{
		string GetQuery(string queryName);
	}
}
