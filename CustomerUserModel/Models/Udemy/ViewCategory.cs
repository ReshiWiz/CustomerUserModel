using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerUserModel.Models.Udemy
{
	[Table("tbl_Category")]
	public class ViewCategory
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Cat_Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string? Cat_Name { get; set; }

		[Required]
		public string? Cat_Image { get; set; }

		[Required]
		public int Cat_Status { get; set; }

		[ForeignKey("Admin")]
		public int Cat_Fk_Ad { get; set; }

		public virtual Admin? Admin { get; set; }
	}


}