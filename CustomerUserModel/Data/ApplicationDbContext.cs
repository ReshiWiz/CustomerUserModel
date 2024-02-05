using CustomerUserModel.Models;
using CustomerUserModel.Models.DisplayModel;
using CustomerUserModel.Models.JqueryCrudOps;
using CustomerUserModel.Models.TodoList;
using CustomerUserModel.Models.Udemy;
using Microsoft.EntityFrameworkCore;

namespace CustomerUserModel.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

		//public DbSet<User> Users { get; set; }
		//public DbSet<City> Cities { get; set; }
		//public DbSet<State> States { get; set; }
		//public DbSet<Country> Countries { get; set; }
		//public DbSet<TodoModel>? Todos { get; set; }
		//public DbSet<Currency> Currencies { get; set; }

		// Udemy Db Context 

		public DbSet<Admin> Admins { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ViewCategory> Categories { get; set; }
	}
}
