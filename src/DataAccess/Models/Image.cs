using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
	public class Image
	{
		public int Id { get; set; }  // Primary key

		public string Name { get; set; }  // Image name

		public byte[] ImageData { get; set; }  // Image binary data

		public int Width { get; set; }  // Image width in pixels

		public int Height { get; set; }  // Image height in pixels

		public string PixelFormat { get; set; }  // RGB or RGBA

		public string Path { get; set; }  // File path where the image is stored
	}
}
