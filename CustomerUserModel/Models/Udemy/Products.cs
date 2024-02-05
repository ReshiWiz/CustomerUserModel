using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerUserModel.Models.Udemy
{
	[Table("Product")]
	public class Product
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Pro_Id { get; set; }

		[MaxLength(50)]
		public string? Pro_Name { get; set; }

		[MaxLength(50)]
		public string? Pro_Category { get; set; }

		[MaxLength(50)]
		public string? Pro_Des { get; set; }

		[MaxLength(50)]
		public string? Pro_Title { get; set; }

		[ForeignKey("Category")]
		public int Pro_Fk_Cat { get; set; }

		[ForeignKey("User")]
		public int Pro_Fk_User { get; set; }

		// Navigation properties
		public virtual ViewCategory? Category { get; set; }
		public virtual User? Usser { get; set; }
	}
}