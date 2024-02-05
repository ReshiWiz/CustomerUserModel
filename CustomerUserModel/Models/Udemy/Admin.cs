using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerUserModel.Models.Udemy
{
	public class Admin
	{
		[Key]

		public int ad_id { get; set; }
		[Required(ErrorMessage = "Username field is required ")]
		public string? ad_userName { get; set; }
		[Required(ErrorMessage = "password field is required ")]
		public string? ad_password { get; set; }

		public virtual ICollection<ViewCategory>? Categories { get; set; }

		public Admin()
		{
			Categories = new HashSet<ViewCategory>();
		}
	}
}

