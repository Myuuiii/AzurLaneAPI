using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzurLaneAPI.Domain.Migrations
{
    /// <inheritdoc />
    public partial class BaseStatsOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipStats_BaseStatsId",
                table: "Ships");

            migrationBuilder.AlterColumn<Guid>(
                name: "BaseStatsId",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipStats_BaseStatsId",
                table: "Ships",
                column: "BaseStatsId",
                principalTable: "ShipStats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipStats_BaseStatsId",
                table: "Ships");

            migrationBuilder.AlterColumn<Guid>(
                name: "BaseStatsId",
                table: "Ships",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipStats_BaseStatsId",
                table: "Ships",
                column: "BaseStatsId",
                principalTable: "ShipStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
