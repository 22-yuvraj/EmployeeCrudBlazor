using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudBlazor.Data
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string MiddleName { get; set; }

		public string LastName { get; set; }

		public string Gender { get; set; }

		public string City { get; set; }

		public string Designation { get; set; }
	}
}
