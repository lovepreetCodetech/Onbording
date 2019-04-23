using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Onbording.Models
{
	public class ReactContext : DbContext
	{
		public ReactContext() : base("DefaultConnection") {}
		public DbSet<Customer> Customer { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<store> Stores { get; set; }
		public DbSet<sales> Sales { get; set; }
		
	}
}	