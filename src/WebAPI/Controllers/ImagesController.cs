using DataAccess.Models;
using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ImagesController : ControllerBase
	{
		private readonly IImageService _imageService;

		public ImagesController(IImageService imageService)
		{
			_imageService = imageService;
		}

		// GET: api/images
		[HttpGet]
		public async Task<IActionResult> GetAllImages()
		{
			var images = await _imageService.GetAllImagesAsync();
			return Ok(images);
		}

		// GET: api/images/{id}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetImageById(int id)
		{
			var image = await _imageService.GetImageByIdAsync(id);
			if (image == null)
				return NotFound();

			return Ok(image);
		}

		// POST: api/images
		[HttpPost]
		public async Task<IActionResult> AddImage([FromBody] Image image)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _imageService.AddImageAsync(image);
			return CreatedAtAction(nameof(GetImageById), new { id = image.Id }, image);
		}

		// PUT: api/images/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateImage(int id, [FromBody] Image image)
		{
			if (id != image.Id)
				return BadRequest("Image ID mismatch");

			await _imageService.UpdateImageAsync(image);
			return NoContent();
		}

		// DELETE: api/images/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteImage(int id)
		{
			await _imageService.DeleteImageAsync(id);
			return NoContent();
		}
	}
}
