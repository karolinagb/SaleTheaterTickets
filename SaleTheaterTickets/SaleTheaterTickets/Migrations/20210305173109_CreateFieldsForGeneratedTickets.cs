using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleTheaterTickets.Migrations
{
    public partial class CreateFieldsForGeneratedTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "GeneratedTickets");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "GeneratedTickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GeneratedTickets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "GeneratedTickets",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "GeneratedTickets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "GeneratedTickets");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "GeneratedTickets");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "GeneratedTickets",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
