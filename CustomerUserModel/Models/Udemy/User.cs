using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("tbl_User")]
public class User
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int U_Id { get; set; }

	[MaxLength(50)]
	public string? U_Name { get; set; }

	[MaxLength(50)]
	public string? U_Email { get; set; }

	[Required]
	[MaxLength(50)]
	public string? U_Password { get; set; }

	[Required]
	[MaxLength]
	public string? U_Image { get; set; }

	[Required]
	[MaxLength(50)]
	public string? U_Department { get; set; }

	[Required]
	[MaxLength(50)]
	public string? U_Contact { get; set; }
}
