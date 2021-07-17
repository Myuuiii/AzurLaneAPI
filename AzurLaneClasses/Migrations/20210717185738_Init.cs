using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzurLaneClasses.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CampaignLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Chapter = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    EN_Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CN_Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JP_Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignLevels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JP_Period = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CN_Period = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EN_Period = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Summary = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipClasses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipStats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Luck = table.Column<int>(type: "int", nullable: false),
                    Armor = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Firepower = table.Column<int>(type: "int", nullable: false),
                    AntiAir = table.Column<int>(type: "int", nullable: false),
                    Torpedo = table.Column<int>(type: "int", nullable: false),
                    Evasion = table.Column<int>(type: "int", nullable: false),
                    Aviation = table.Column<int>(type: "int", nullable: false),
                    OilConsumption = table.Column<int>(type: "int", nullable: false),
                    Reload = table.Column<int>(type: "int", nullable: false),
                    AntiSubmarine = table.Column<int>(type: "int", nullable: false),
                    Oxygen = table.Column<int>(type: "int", nullable: false),
                    Ammunition = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipStats", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ShipId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    Nation = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    HasLive2DModel = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Artist = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VoiceActor = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconImage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ThumbnailImage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DefaultFullImage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DefaultChibiImage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BaseStatsIdId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Level100StatsIdId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Level100RetrofitStatsIdId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Level120StatsIdId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Level120RetrofitStatsIdId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    EquippableTypeSlot1 = table.Column<int>(type: "int", nullable: false),
                    EquippableTypeSlot2 = table.Column<int>(type: "int", nullable: false),
                    EquippableTypeSlot3 = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_ShipStats_BaseStatsIdId",
                        column: x => x.BaseStatsIdId,
                        principalTable: "ShipStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ships_ShipStats_Level100RetrofitStatsIdId",
                        column: x => x.Level100RetrofitStatsIdId,
                        principalTable: "ShipStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ships_ShipStats_Level100StatsIdId",
                        column: x => x.Level100StatsIdId,
                        principalTable: "ShipStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ships_ShipStats_Level120RetrofitStatsIdId",
                        column: x => x.Level120RetrofitStatsIdId,
                        principalTable: "ShipStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ships_ShipStats_Level120StatsIdId",
                        column: x => x.Level120StatsIdId,
                        principalTable: "ShipStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipSkins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name_English = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_Japanese = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_Chinese = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChibiImage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShipId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipSkins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipSkins_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_BaseStatsIdId",
                table: "Ships",
                column: "BaseStatsIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_Level100RetrofitStatsIdId",
                table: "Ships",
                column: "Level100RetrofitStatsIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_Level100StatsIdId",
                table: "Ships",
                column: "Level100StatsIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_Level120RetrofitStatsIdId",
                table: "Ships",
                column: "Level120RetrofitStatsIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_Level120StatsIdId",
                table: "Ships",
                column: "Level120StatsIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipSkins_ShipId",
                table: "ShipSkins",
                column: "ShipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignLevels");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ShipClasses");

            migrationBuilder.DropTable(
                name: "ShipSkins");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "ShipStats");
        }
    }
}
