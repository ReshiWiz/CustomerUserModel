using CustomerUserModel.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerUserModel.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Country> Countries { get; set; }
	}
}
