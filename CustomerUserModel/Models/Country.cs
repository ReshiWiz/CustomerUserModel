
using System.ComponentModel.DataAnnotations;

namespace CustomerUserModel.Models
{
	public class Country
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string? CountryName { get; set; }
	}
}
