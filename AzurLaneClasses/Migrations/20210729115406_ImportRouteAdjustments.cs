using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzurLaneClasses.Migrations
{
    public partial class ImportRouteAdjustments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipEquippableSlot_EquipSlot1Id",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipEquippableSlot_EquipSlot2Id",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipEquippableSlot_EquipSlot3Id",
                table: "Ships");

            migrationBuilder.DropTable(
                name: "ShipLimitBreak");

            migrationBuilder.DropIndex(
                name: "IX_Ships_EquipSlot1Id",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_EquipSlot2Id",
                table: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_Ships_EquipSlot3Id",
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
                name: "IconImage",
                table: "Ships");

            migrationBuilder.RenameColumn(
                name: "Aviation",
                table: "ConstructionAvailability",
                newName: "Special");

            migrationBuilder.AlterColumn<string>(
                name: "Nation",
                table: "TorpedoBomberPlanes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nation",
                table: "SubmarineTorpedoes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Armor",
                table: "ShipStats",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HuntingRange",
                table: "ShipStats",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ObtainedFrom",
                table: "ShipSkins",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Ships",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Rarity",
                table: "Ships",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nation",
                table: "Ships",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ShipId",
                table: "ShipEquippableSlot",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ConstructionTime",
                table: "ShipConstruction",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nation",
                table: "Seaplanes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nation",
                table: "LightCruiserGuns",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nation",
                table: "LargeCruiserGuns",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nation",
                table: "HeavyCruiserGuns",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nation",
                table: "FighterPlanes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nation",
                table: "DiveBomberPlanes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nation",
                table: "DestroyerGuns",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nation",
                table: "BattleshipGuns",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nation",
                table: "AntiAirGuns",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipLimitBreaks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LimitBreaks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShipId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipLimitBreaks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipLimitBreaks_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "ShipId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ShipEquippableSlot_ShipId",
                table: "ShipEquippableSlot",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipLimitBreaks_ShipId",
                table: "ShipLimitBreaks",
                column: "ShipId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipEquippableSlot_Ships_ShipId",
                table: "ShipEquippableSlot",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "ShipId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipEquippableSlot_Ships_ShipId",
                table: "ShipEquippableSlot");

            migrationBuilder.DropTable(
                name: "ShipLimitBreaks");

            migrationBuilder.DropIndex(
                name: "IX_ShipEquippableSlot_ShipId",
                table: "ShipEquippableSlot");

            migrationBuilder.DropColumn(
                name: "HuntingRange",
                table: "ShipStats");

            migrationBuilder.DropColumn(
                name: "ObtainedFrom",
                table: "ShipSkins");

            migrationBuilder.DropColumn(
                name: "ShipId",
                table: "ShipEquippableSlot");

            migrationBuilder.RenameColumn(
                name: "Special",
                table: "ConstructionAvailability",
                newName: "Aviation");

            migrationBuilder.AlterColumn<int>(
                name: "Nation",
                table: "TorpedoBomberPlanes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Nation",
                table: "SubmarineTorpedoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Armor",
                table: "ShipStats",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Rarity",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Nation",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.AddColumn<string>(
                name: "IconImage",
                table: "Ships",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ConstructionTime",
                table: "ShipConstruction",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Nation",
                table: "Seaplanes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Nation",
                table: "LightCruiserGuns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Nation",
                table: "LargeCruiserGuns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Nation",
                table: "HeavyCruiserGuns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Nation",
                table: "FighterPlanes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Nation",
                table: "DiveBomberPlanes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Nation",
                table: "DestroyerGuns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Nation",
                table: "BattleshipGuns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Nation",
                table: "AntiAirGuns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShipLimitBreak",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    First = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Second = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShipId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Third = table.Column<string>(type: "longtext", nullable: true)
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
                name: "IX_ShipLimitBreak_ShipId",
                table: "ShipLimitBreak",
                column: "ShipId");

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
        }
    }
}
