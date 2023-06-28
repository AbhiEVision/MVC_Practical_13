using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Practical_13.Models
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext() : base("Data Source=SF-CPU-523;Initial Catalog=EmployeeDB;User Id=sa;Password =Abhi@15042002;Encrypt =false;") { }

		public DbSet<Employee> Employees { get; set; }
	}
}