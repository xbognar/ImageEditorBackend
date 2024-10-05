using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interfaces
{
	public interface IImageService
	{
		
		Task<IEnumerable<Image>> GetAllImagesAsync();
		
		Task<Image> GetImageByIdAsync(int id);
		
		Task AddImageAsync(Image image);
		
		Task UpdateImageAsync(Image image);
		
		Task DeleteImageAsync(int id);
	
	}
}
