using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerUserModel.Models
{
	public class City
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(100)]
		public string? CityName { get; set; }
		[ForeignKey("Country")]
		public int CountryId { get; set; }
		public virtual Country? Country { get; set; }
	}
}
