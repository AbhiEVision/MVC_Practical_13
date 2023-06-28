using System;
using System.ComponentModel.DataAnnotations;

namespace Practical_13.Models
{
	public class Employee
	{

		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		[Required]
		[DataType(dataType: DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime DOB { get; set; }

		public int? Age { get; set; }

	}
}