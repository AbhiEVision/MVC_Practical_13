using System.Data.Entity;
using Test2.Models;

namespace Test2.Data
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext() : base("Data Source=SF-CPU-523;Initial Catalog=EmployeeDB2;User Id=sa;Password =Abhi@15042002;Encrypt =false;") { }

		public DbSet<Designations> Designations { get; set; }

		public DbSet<Employee> Employees { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Employee>()
				.HasRequired<Designations>(x => x.Designations)
				.WithMany(x => x.Employees)
				.HasForeignKey<int>(x => x.DesignationId);
		}

	}
}