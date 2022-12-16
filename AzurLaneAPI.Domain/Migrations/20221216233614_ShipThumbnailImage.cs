using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzurLaneAPI.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ShipThumbnailImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailImage",
                table: "Ships",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailImage",
                table: "Ships");
        }
    }
}
