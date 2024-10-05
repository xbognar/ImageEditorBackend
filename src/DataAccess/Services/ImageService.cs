using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services
{
	public class ImageService : IImageService
	{
		private readonly ApplicationDbContext _context;

		public ImageService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Image>> GetAllImagesAsync()
		{
			return await _context.Images.ToListAsync();
		}

		public async Task<Image> GetImageByIdAsync(int id)
		{
			return await _context.Images.FindAsync(id);
		}

		public async Task AddImageAsync(Image image)
		{
			_context.Images.Add(image);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateImageAsync(Image image)
		{
			_context.Images.Update(image);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteImageAsync(int id)
		{
			var image = await _context.Images.FindAsync(id);
			if (image != null)
			{
				_context.Images.Remove(image);
				await _context.SaveChangesAsync();
			}
		}
	}
}
