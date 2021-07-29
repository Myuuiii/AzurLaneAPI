using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzurLaneClasses.Migrations
{
    public partial class MiscExtensions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipMisc_MiscId",
                table: "Ships");

            migrationBuilder.DropTable(
                name: "ShipMisc");

            migrationBuilder.RenameColumn(
                name: "MiscId",
                table: "Ships",
                newName: "WebId");

            migrationBuilder.RenameIndex(
                name: "IX_Ships_MiscId",
                table: "Ships",
                newName: "IX_Ships_WebId");

            migrationBuilder.AddColumn<Guid>(
                name: "ArtistId",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "PixivId",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TwitterId",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "VoiceActorId",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ArtistId",
                table: "Ships",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_PixivId",
                table: "Ships",
                column: "PixivId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_TwitterId",
                table: "Ships",
                column: "TwitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_VoiceActorId",
                table: "Ships",
                column: "VoiceActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipArtist_ArtistId",
                table: "Ships",
                column: "ArtistId",
                principalTable: "ShipArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipPixiv_PixivId",
                table: "Ships",
                column: "PixivId",
                principalTable: "ShipPixiv",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipTwitter_TwitterId",
                table: "Ships",
                column: "TwitterId",
                principalTable: "ShipTwitter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipVoiceActor_VoiceActorId",
                table: "Ships",
                column: "VoiceActorId",
                principalTable: "ShipVoiceActor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipWeb_WebId",
                table: "Ships",
                column: "WebId",
                principalTable: "ShipWeb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipArtist_ArtistId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipPixiv_PixivId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipTwitter_TwitterId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipVoiceActor_VoiceActorId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipWeb_WebId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ArtistId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_PixivId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_TwitterId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_VoiceActorId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "PixivId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "TwitterId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "VoiceActorId",
                table: "Ships");

            migrationBuilder.RenameColumn(
                name: "WebId",
                table: "Ships",
                newName: "MiscId");

            migrationBuilder.RenameIndex(
                name: "IX_Ships_WebId",
                table: "Ships",
                newName: "IX_Ships_MiscId");

            migrationBuilder.CreateTable(
                name: "ShipMisc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ArtistId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PixivId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    TwitterId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    VoiceActorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    WebId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipMisc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipMisc_ShipArtist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "ShipArtist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipMisc_ShipPixiv_PixivId",
                        column: x => x.PixivId,
                        principalTable: "ShipPixiv",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipMisc_ShipTwitter_TwitterId",
                        column: x => x.TwitterId,
                        principalTable: "ShipTwitter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipMisc_ShipVoiceActor_VoiceActorId",
                        column: x => x.VoiceActorId,
                        principalTable: "ShipVoiceActor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShipMisc_ShipWeb_WebId",
                        column: x => x.WebId,
                        principalTable: "ShipWeb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ShipMisc_ArtistId",
                table: "ShipMisc",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipMisc_PixivId",
                table: "ShipMisc",
                column: "PixivId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipMisc_TwitterId",
                table: "ShipMisc",
                column: "TwitterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipMisc_VoiceActorId",
                table: "ShipMisc",
                column: "VoiceActorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipMisc_WebId",
                table: "ShipMisc",
                column: "WebId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipMisc_MiscId",
                table: "Ships",
                column: "MiscId",
                principalTable: "ShipMisc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
