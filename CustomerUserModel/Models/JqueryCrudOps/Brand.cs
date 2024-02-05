using System.ComponentModel.DataAnnotations;

namespace CustomerUserModel.Models.JqueryCrudOps
{
	public class Brand
	{
		[Key]
		public int BrandId { get; set; }

		[Required, StringLength(25)]
		public string? Name { get; set; }

		[Required]
		[StringLength(200)]
		public string? Description { get; set; }
	}
}
