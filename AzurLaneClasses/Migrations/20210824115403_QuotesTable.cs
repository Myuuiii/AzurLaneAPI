using Microsoft.EntityFrameworkCore.Migrations;

namespace AzurLaneClasses.Migrations
{
    public partial class QuotesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipQuote_Ships_ShipId",
                table: "ShipQuote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShipQuote",
                table: "ShipQuote");

            migrationBuilder.RenameTable(
                name: "ShipQuote",
                newName: "ShipQuotes");

            migrationBuilder.RenameIndex(
                name: "IX_ShipQuote_ShipId",
                table: "ShipQuotes",
                newName: "IX_ShipQuotes_ShipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShipQuotes",
                table: "ShipQuotes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipQuotes_Ships_ShipId",
                table: "ShipQuotes",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "ShipId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipQuotes_Ships_ShipId",
                table: "ShipQuotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShipQuotes",
                table: "ShipQuotes");

            migrationBuilder.RenameTable(
                name: "ShipQuotes",
                newName: "ShipQuote");

            migrationBuilder.RenameIndex(
                name: "IX_ShipQuotes_ShipId",
                table: "ShipQuote",
                newName: "IX_ShipQuote_ShipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShipQuote",
                table: "ShipQuote",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipQuote_Ships_ShipId",
                table: "ShipQuote",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "ShipId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
