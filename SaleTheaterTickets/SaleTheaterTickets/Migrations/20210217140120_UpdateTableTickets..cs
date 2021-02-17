using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleTheaterTickets.Migrations
{
    public partial class UpdateTableTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSeats",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "QuantityOfSeats",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Schedule",
                table: "Tickets",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityOfSeats",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeats",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
