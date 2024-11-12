namespace DataAccess.Models
{
	public class Image
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public byte[] ImageData { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public string PixelFormat { get; set; }
		public string Path { get; set; }
	}
}
