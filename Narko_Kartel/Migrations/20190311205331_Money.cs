using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLapp.Migrations
{
    public partial class Money : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    MoneyKey = table.Column<string>(nullable: false),
                    Money_Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.MoneyKey);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Money");
        }
    }
}
