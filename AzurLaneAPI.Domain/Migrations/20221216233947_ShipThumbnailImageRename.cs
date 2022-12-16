using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzurLaneAPI.Domain.Migrations
{
    /// <inheritdoc />
    public partial class ShipThumbnailImageRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThumbnailImage",
                table: "Ships",
                newName: "ThumbnailImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThumbnailImageUrl",
                table: "Ships",
                newName: "ThumbnailImage");
        }
    }
}
