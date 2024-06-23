using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioManagement.Migrations
{
    public partial class AddTotalValueToInvestment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "Investments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "Investments");
        }
    }
}
