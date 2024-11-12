// DataAccess/Services/ImageService.cs
using Dapper;
using DataAccess.Database;
using DataAccess.Models;
using DataAccess.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Services
{
	public class ImageService : IImageService
	{
		private readonly ApplicationDbContext _context;
		private readonly IQueryService _queryService;

		public ImageService(ApplicationDbContext context, IQueryService queryService)
		{
			_context = context;
			_queryService = queryService;
		}

		public async Task<IEnumerable<Image>> GetAllImagesAsync()
		{
			var query = _queryService.GetQuery("GetAllImages");
			using (var connection = _context.CreateConnection())
			{
				return await connection.QueryAsync<Image>(query);
			}
		}

		public async Task<Image> GetImageByIdAsync(int id)
		{
			var query = _queryService.GetQuery("GetImageById");
			using (var connection = _context.CreateConnection())
			{
				return await connection.QueryFirstOrDefaultAsync<Image>(query, new { Id = id });
			}
		}

		public async Task<int> AddImageAsync(Image image)
		{
			var query = _queryService.GetQuery("InsertImage");
			using (var connection = _context.CreateConnection())
			{
				// This returns the newly inserted Id
				var id = await connection.QuerySingleAsync<int>(query, image);
				return id;
			}
		}

		public async Task UpdateImageAsync(Image image)
		{
			var query = _queryService.GetQuery("UpdateImage");
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, image);
			}
		}

		public async Task DeleteImageAsync(int id)
		{
			var query = _queryService.GetQuery("DeleteImage");
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, new { Id = id });
			}
		}
	}
}
