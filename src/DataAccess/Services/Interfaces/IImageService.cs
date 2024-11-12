using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Services.Interfaces
{
	public interface IImageService
	{
		Task<IEnumerable<Image>> GetAllImagesAsync();
		Task<Image> GetImageByIdAsync(int id);
		Task<int> AddImageAsync(Image image); 
		Task UpdateImageAsync(Image image);
		Task DeleteImageAsync(int id);
	}
}
