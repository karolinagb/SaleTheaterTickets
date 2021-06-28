using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleTheaterTickets.Migrations
{
    public partial class CreateFieldCriationDateGeneratedTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedTickets_Tickets_TicketId",
                table: "GeneratedTickets");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "GeneratedTickets",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "GeneratedTickets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedTickets_Tickets_TicketId",
                table: "GeneratedTickets",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedTickets_Tickets_TicketId",
                table: "GeneratedTickets");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "GeneratedTickets");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "GeneratedTickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedTickets_Tickets_TicketId",
                table: "GeneratedTickets",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
