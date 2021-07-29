using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzurLaneClasses.Migrations
{
    public partial class ShipsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipSkins_Ships_ShipId",
                table: "ShipSkins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ships",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "ChibiImage",
                table: "ShipSkins");

            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "DefaultChibiImage",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "DefaultFullImage",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "EquippableTypeSlot1",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "EquippableTypeSlot2",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "EquippableTypeSlot3",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "HasLive2DModel",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "VoiceActor",
                table: "Ships");

            migrationBuilder.RenameColumn(
                name: "Name_Japanese",
                table: "ShipSkins",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Name_English",
                table: "ShipSkins",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "Name_Chinese",
                table: "ShipSkins",
                newName: "ChibiUrl");

            migrationBuilder.RenameColumn(
                name: "FullImage",
                table: "ShipSkins",
                newName: "BackgroundUrl");

            migrationBuilder.AlterColumn<string>(
                name: "ShipId",
                table: "ShipSkins",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<bool>(
                name: "Live2dModel",
                table: "ShipSkins",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailImage",
                table: "Ships",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ShipId",
                table: "Ships",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ships",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "IconImage",
                table: "Ships",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "ConstructionId",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "DefaultSkinId",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "EnhanceValueId",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "EquipSlot1Id",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "EquipSlot2Id",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "EquipSlot3Id",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "MiscId",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ScrapValueId",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "StarsId",
                table: "Ships",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ships",
                table: "Ships",
                column: "ShipId");

            migrationBuilder.CreateTable(
                name: "ConstructionAvailability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Light = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Heavy = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Aviation = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Limited = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Exchange = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionAvailability", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipArtist",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipArtist", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipEnhanceValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Firepower = table.Column<int>(type: "int", nullable: false),
                    Torpedo = table.Column<int>(type: "int", nullable: false),
                    Aviation = table.Column<int>(type: "int", nullable: false),
                    Reload = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipEnhanceValues", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipEquippableSlot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    MaxEfficiency = table.Column<int>(type: "int", nullable: false),
                    MinEfficiency = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Max = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipEquippableSlot", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipGalleryItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShipId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipGalleryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipGalleryItem_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "ShipId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipLimitBreak",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    First = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Second = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Third = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShipId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipLimitBreak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipLimitBreak_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "ShipId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipPixiv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipPixiv", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipScrapValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Coins = table.Column<int>(type: "int", nullable: false),
                    Oil = table.Column<int>(type: "int", nullable: false),
                    Medals = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipScrapValues", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShipId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipSkill_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "ShipId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipStars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Stars = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipStars", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipTwitter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipTwitter", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipVoiceActor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipVoiceActor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipWeb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipWeb", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipConstruction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ConstructionTime = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    AvailabilityId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipConstruction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipConstruction_ConstructionAvailability_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "ConstructionAvailability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipMisc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ArtistId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PixivId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    TwitterId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    WebId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    VoiceActorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
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
                name: "IX_Ships_ConstructionId",
                table: "Ships",
                column: "ConstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_DefaultSkinId",
                table: "Ships",
                column: "DefaultSkinId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_EnhanceValueId",
                table: "Ships",
                column: "EnhanceValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_EquipSlot1Id",
                table: "Ships",
                column: "EquipSlot1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_EquipSlot2Id",
                table: "Ships",
                column: "EquipSlot2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_EquipSlot3Id",
                table: "Ships",
                column: "EquipSlot3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_MiscId",
                table: "Ships",
                column: "MiscId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ScrapValueId",
                table: "Ships",
                column: "ScrapValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_StarsId",
                table: "Ships",
                column: "StarsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipConstruction_AvailabilityId",
                table: "ShipConstruction",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipGalleryItem_ShipId",
                table: "ShipGalleryItem",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipLimitBreak_ShipId",
                table: "ShipLimitBreak",
                column: "ShipId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ShipSkill_ShipId",
                table: "ShipSkill",
                column: "ShipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipConstruction_ConstructionId",
                table: "Ships",
                column: "ConstructionId",
                principalTable: "ShipConstruction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipEnhanceValues_EnhanceValueId",
                table: "Ships",
                column: "EnhanceValueId",
                principalTable: "ShipEnhanceValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipEquippableSlot_EquipSlot1Id",
                table: "Ships",
                column: "EquipSlot1Id",
                principalTable: "ShipEquippableSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipEquippableSlot_EquipSlot2Id",
                table: "Ships",
                column: "EquipSlot2Id",
                principalTable: "ShipEquippableSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipEquippableSlot_EquipSlot3Id",
                table: "Ships",
                column: "EquipSlot3Id",
                principalTable: "ShipEquippableSlot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipMisc_MiscId",
                table: "Ships",
                column: "MiscId",
                principalTable: "ShipMisc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipScrapValues_ScrapValueId",
                table: "Ships",
                column: "ScrapValueId",
                principalTable: "ShipScrapValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipSkins_DefaultSkinId",
                table: "Ships",
                column: "DefaultSkinId",
                principalTable: "ShipSkins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipStars_StarsId",
                table: "Ships",
                column: "StarsId",
                principalTable: "ShipStars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipSkins_Ships_ShipId",
                table: "ShipSkins",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "ShipId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipConstruction_ConstructionId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipEnhanceValues_EnhanceValueId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipEquippableSlot_EquipSlot1Id",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipEquippableSlot_EquipSlot2Id",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipEquippableSlot_EquipSlot3Id",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipMisc_MiscId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipScrapValues_ScrapValueId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipSkins_DefaultSkinId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipStars_StarsId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipSkins_Ships_ShipId",
                table: "ShipSkins");

            migrationBuilder.DropTable(
                name: "ShipConstruction");

            migrationBuilder.DropTable(
                name: "ShipEnhanceValues");

            migrationBuilder.DropTable(
                name: "ShipEquippableSlot");

            migrationBuilder.DropTable(
                name: "ShipGalleryItem");

            migrationBuilder.DropTable(
                name: "ShipLimitBreak");

            migrationBuilder.DropTable(
                name: "ShipMisc");

            migrationBuilder.DropTable(
                name: "ShipScrapValues");

            migrationBuilder.DropTable(
                name: "ShipSkill");

            migrationBuilder.DropTable(
                name: "ShipStars");

            migrationBuilder.DropTable(
                name: "ConstructionAvailability");

            migrationBuilder.DropTable(
                name: "ShipArtist");

            migrationBuilder.DropTable(
                name: "ShipPixiv");

            migrationBuilder.DropTable(
                name: "ShipTwitter");

            migrationBuilder.DropTable(
                name: "ShipVoiceActor");

            migrationBuilder.DropTable(
                name: "ShipWeb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ships",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ConstructionId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_DefaultSkinId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_EnhanceValueId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_EquipSlot1Id",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_EquipSlot2Id",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_EquipSlot3Id",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_MiscId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_ScrapValueId",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_StarsId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "Live2dModel",
                table: "ShipSkins");

            migrationBuilder.DropColumn(
                name: "ConstructionId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "DefaultSkinId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "EnhanceValueId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "EquipSlot1Id",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "EquipSlot2Id",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "EquipSlot3Id",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "MiscId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "ScrapValueId",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "StarsId",
                table: "Ships");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ShipSkins",
                newName: "Name_Japanese");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "ShipSkins",
                newName: "Name_English");

            migrationBuilder.RenameColumn(
                name: "ChibiUrl",
                table: "ShipSkins",
                newName: "Name_Chinese");

            migrationBuilder.RenameColumn(
                name: "BackgroundUrl",
                table: "ShipSkins",
                newName: "FullImage");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShipId",
                table: "ShipSkins",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ChibiImage",
                table: "ShipSkins",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailImage",
                table: "Ships",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ships",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "IconImage",
                table: "Ships",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ShipId",
                table: "Ships",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Ships",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DefaultChibiImage",
                table: "Ships",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DefaultFullImage",
                table: "Ships",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "EquippableTypeSlot1",
                table: "Ships",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquippableTypeSlot2",
                table: "Ships",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquippableTypeSlot3",
                table: "Ships",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasLive2DModel",
                table: "Ships",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VoiceActor",
                table: "Ships",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ships",
                table: "Ships",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipSkins_Ships_ShipId",
                table: "ShipSkins",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
