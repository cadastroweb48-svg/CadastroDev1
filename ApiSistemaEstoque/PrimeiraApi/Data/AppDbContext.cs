using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Models;

namespace PrimeiraApi.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		public DbSet<Cliente> Cliente { get; set; }

	    
		public DbSet<Usuario> Usuarios { get; set; }
	}
}
