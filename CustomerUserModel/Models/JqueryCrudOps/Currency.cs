using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerUserModel.Models.JqueryCrudOps
{
	public class Currency
	{

		public int CurrencyId { get; set; }

		[Required, StringLength(25)]
		public string? Name { get; set; }

		[Required]
		[StringLength(200)]
		public string? Description { get; set; }
		[Required]
		[ForeignKey("Currencies")]
		public int ExchangeCurrencyId { get; set; }
		public virtual Currency? Currencies { 
			get; set; }
		[Column(TypeName = "smallMoney")]
		[Required]
		public decimal ExchangeRate { get; set; }
	}
}
