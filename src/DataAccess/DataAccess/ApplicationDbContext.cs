using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataAccess
{
	public class ApplicationDbContext : DbContext
	{

		public DbSet<Image> Images { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

	}
}
