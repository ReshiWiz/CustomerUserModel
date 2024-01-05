using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerUserModel.Models
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Please enter your first name")]

		public string? FirstName { get; set; }
		[Required(ErrorMessage = "Please enter your last name")]

		public string? LastName { get; set; }
		[Required(ErrorMessage = "Please enter your Phone number")]
		public double PhoneNumber { get; set; }
		[Required(ErrorMessage = "Please enter your email address")]
		public string? Email { get; set; }
		[Required(ErrorMessage = "Please enter your address")]
		public string? Address { get; set; }

		[Required]
		[ForeignKey("City")]
		[DisplayName("City")]
		public int CityId { get; set; }
		public virtual City? City { get; set; }

		[Required]
		[ForeignKey("Country")]
		[DisplayName("Country")]
		public int CountryId { get; set; }
		public virtual Country? Country { get; set; }
	}
}
