using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string FirstName { get; set; }

		[StringLength(50)]
		public string MiddleName { get; set; }

		[Required]
		[StringLength(50)]
		public string LastName { get; set; }

		[Required]
		[Column(TypeName = "Date")]
		[DataType(dataType: DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime DOB { get; set; }

		[Required]
		[DisplayName("Mobile Number")]
		[StringLength(10, MinimumLength = 10)]
		[Phone]
		public string MobileNo { get; set; }

		[StringLength(100)]
		public string Address { get; set; }

		[Required]
		public decimal Salary { get; set; }

		public virtual Designations Designations { get; set; }

		[ForeignKey("Designations")]
		public int DesignationId { get; set; }


	}
}