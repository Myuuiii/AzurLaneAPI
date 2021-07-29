using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzurLaneClasses.Migrations
{
    public partial class TokenLastAccessed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastRequest",
                table: "ALTokens",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastRequest",
                table: "ALTokens");
        }
    }
}
