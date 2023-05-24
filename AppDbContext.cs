using Microsoft.EntityFrameworkCore;

namespace ParcialRaffoZelada
{
	public class AppDbContext : DbContext
	{

		public DbSet<Persona> personas { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

	}
}
