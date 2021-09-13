using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleTheaterTickets.Migrations
{
    public partial class AlterColumnNamePiece : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedTickets_Tickets_TicketId",
                table: "GeneratedTickets");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pieces",
                type: "VARCHAR(400)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "GeneratedTickets",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedTickets_Tickets_TicketId",
                table: "GeneratedTickets",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedTickets_Tickets_TicketId",
                table: "GeneratedTickets");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pieces",
                type: "VARCHAR(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(400)");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "GeneratedTickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedTickets_Tickets_TicketId",
                table: "GeneratedTickets",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
