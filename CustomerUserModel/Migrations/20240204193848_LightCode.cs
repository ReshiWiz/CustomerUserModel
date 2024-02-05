using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerUserModel.Migrations
{
    /// <inheritdoc />
    public partial class LightCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ad_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad_userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ad_password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ad_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User",
                columns: table => new
                {
                    U_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    U_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    U_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    U_Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    U_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    U_Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    U_Contact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.U_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Category",
                columns: table => new
                {
                    Cat_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cat_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cat_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cat_Status = table.Column<int>(type: "int", nullable: false),
                    Cat_Fk_Ad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Category", x => x.Cat_Id);
                    table.ForeignKey(
                        name: "FK_tbl_Category_Admins_Cat_Fk_Ad",
                        column: x => x.Cat_Fk_Ad,
                        principalTable: "Admins",
                        principalColumn: "ad_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Pro_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pro_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pro_Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pro_Des = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pro_Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pro_Fk_Cat = table.Column<int>(type: "int", nullable: false),
                    Pro_Fk_User = table.Column<int>(type: "int", nullable: false),
                    UsserU_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Pro_Id);
                    table.ForeignKey(
                        name: "FK_Product_tbl_Category_Pro_Fk_Cat",
                        column: x => x.Pro_Fk_Cat,
                        principalTable: "tbl_Category",
                        principalColumn: "Cat_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_tbl_User_UsserU_Id",
                        column: x => x.UsserU_Id,
                        principalTable: "tbl_User",
                        principalColumn: "U_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Pro_Fk_Cat",
                table: "Product",
                column: "Pro_Fk_Cat");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UsserU_Id",
                table: "Product",
                column: "UsserU_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Category_Cat_Fk_Ad",
                table: "tbl_Category",
                column: "Cat_Fk_Ad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "tbl_Category");

            migrationBuilder.DropTable(
                name: "tbl_User");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CId);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExchangeCurrencyId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "smallMoney", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                    table.ForeignKey(
                        name: "FK_Currencies_Currencies_ExchangeCurrencyId",
                        column: x => x.ExchangeCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    SId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.SId);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "SId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_ExchangeCurrencyId",
                table: "Currencies",
                column: "ExchangeCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");
        }
    }
}
