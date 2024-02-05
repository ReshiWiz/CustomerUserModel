using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerUserModel.Migrations
{
	/// <inheritdoc />
	public partial class selfForeginKey : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Currencies",
				columns: table => new
				{
					CurrencyId = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
					Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
					ExchangeCurrencyId = table.Column<int>(type: "int", nullable: false),
					ExchangeRate = table.Column<decimal>(type: "smallMoney", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
					table.ForeignKey(
						name: "FK_Currencies_Currencies_ExchangeCurrencyId",
						column: x => x.ExchangeCurrencyId,
						principalTable: "Currencies",
						principalColumn: "CurrencyId",
						onDelete: ReferentialAction.NoAction);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Currencies_ExchangeCurrencyId",
				table: "Currencies",
				column: "ExchangeCurrencyId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Currencies");
		}
	}
}
