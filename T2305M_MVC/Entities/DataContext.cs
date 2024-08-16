using System;
using Microsoft.EntityFrameworkCore;
namespace T2305M_MVC.Entities
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options): base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

		// Brand
		// User
	}
}

