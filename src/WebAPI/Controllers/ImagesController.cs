// WebAPI/Controllers/ImagesController.cs
using DataAccess.Models;
using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImagesController : ControllerBase
	{
		private readonly IImageService _imageService;

		public ImagesController(IImageService imageService)
		{
			_imageService = imageService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Image>>> GetImages()
		{
			var images = await _imageService.GetAllImagesAsync();
			return Ok(images);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Image>> GetImage(int id)
		{
			var image = await _imageService.GetImageByIdAsync(id);
			if (image == null)
			{
				return NotFound();
			}
			return Ok(image);
		}

		[HttpPost]
		public async Task<ActionResult<Image>> AddImage([FromBody] Image image)
		{
			var id = await _imageService.AddImageAsync(image);
			image.Id = id;
			return CreatedAtAction(nameof(GetImage), new { id = image.Id }, image);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateImage(int id, [FromBody] Image image)
		{
			if (id != image.Id)
			{
				return BadRequest("Image ID mismatch.");
			}

			var existingImage = await _imageService.GetImageByIdAsync(id);
			if (existingImage == null)
			{
				return NotFound();
			}

			await _imageService.UpdateImageAsync(image);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteImage(int id)
		{
			var existingImage = await _imageService.GetImageByIdAsync(id);
			if (existingImage == null)
			{
				return NotFound();
			}

			await _imageService.DeleteImageAsync(id);
			return NoContent();
		}
	}
}
