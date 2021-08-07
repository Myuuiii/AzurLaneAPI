using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzurLaneClasses.Migrations
{
    public partial class removeDefaultShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipSkins_DefaultSkinId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_DefaultSkinId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "DefaultSkinId",
                table: "Ships");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DefaultSkinId",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_DefaultSkinId",
                table: "Ships",
                column: "DefaultSkinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipSkins_DefaultSkinId",
                table: "Ships",
                column: "DefaultSkinId",
                principalTable: "ShipSkins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
