using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test2.Models
{
	public class Designations
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Designation { get; set; }


		public ICollection<Employee> Employees { get; set; }
	}
}