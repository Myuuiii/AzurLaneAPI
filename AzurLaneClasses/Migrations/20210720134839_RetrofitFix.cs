using Microsoft.EntityFrameworkCore.Migrations;

namespace AzurLaneClasses.Migrations
{
    public partial class RetrofitFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipStats_BaseStatsIdId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipStats_Level100RetrofitStatsIdId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipStats_Level100StatsIdId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipStats_Level120RetrofitStatsIdId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipStats_Level120StatsIdId",
                table: "Ships");

            migrationBuilder.RenameColumn(
                name: "Level120StatsIdId",
                table: "Ships",
                newName: "Level120StatsId");

            migrationBuilder.RenameColumn(
                name: "Level120RetrofitStatsIdId",
                table: "Ships",
                newName: "Level120RetrofitStatsId");

            migrationBuilder.RenameColumn(
                name: "Level100StatsIdId",
                table: "Ships",
                newName: "Level100StatsId");

            migrationBuilder.RenameColumn(
                name: "Level100RetrofitStatsIdId",
                table: "Ships",
                newName: "Level100RetrofitStatsId");

            migrationBuilder.RenameColumn(
                name: "BaseStatsIdId",
                table: "Ships",
                newName: "BaseStatsId");

            migrationBuilder.RenameIndex(
                name: "IX_Ships_Level120StatsIdId",
                table: "Ships",
                newName: "IX_Ships_Level120StatsId");

            migrationBuilder.RenameIndex(
                name: "IX_Ships_Level120RetrofitStatsIdId",
                table: "Ships",
                newName: "IX_Ships_Level120RetrofitStatsId");

            migrationBuilder.RenameIndex(
                name: "IX_Ships_Level100StatsIdId",
                table: "Ships",
                newName: "IX_Ships_Level100StatsId");

            migrationBuilder.RenameIndex(
                name: "IX_Ships_Level100RetrofitStatsIdId",
                table: "Ships",
                newName: "IX_Ships_Level100RetrofitStatsId");

            migrationBuilder.RenameIndex(
                name: "IX_Ships_BaseStatsIdId",
                table: "Ships",
                newName: "IX_Ships_BaseStatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipStats_BaseStatsId",
                table: "Ships",
                column: "BaseStatsId",
                principalTable: "ShipStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipStats_Level100RetrofitStatsId",
                table: "Ships",
                column: "Level100RetrofitStatsId",
                principalTable: "ShipStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipStats_Level100StatsId",
                table: "Ships",
                column: "Level100StatsId",
                principalTable: "ShipStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipStats_Level120RetrofitStatsId",
                table: "Ships",
                column: "Level120RetrofitStatsId",
                principalTable: "ShipStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipStats_Level120StatsId",
                table: "Ships",
                column: "Level120StatsId",
                principalTable: "ShipStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipStats_BaseStatsId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipStats_Level100RetrofitStatsId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipStats_Level100StatsId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipStats_Level120RetrofitStatsId",
                table: "Ships");

            migrationBuilder.DropForeignKey(
                name: "FK_Ships_ShipStats_Level120StatsId",
                table: "Ships");

            migrationBuilder.RenameColumn(
                name: "Level120StatsId",
                table: "Ships",
                newName: "Level120StatsIdId");

            migrationBuilder.RenameColumn(
                name: "Level120RetrofitStatsId",
                table: "Ships",
                newName: "Level120RetrofitStatsIdId");

            migrationBuilder.RenameColumn(
                name: "Level100StatsId",
                table: "Ships",
                newName: "Level100StatsIdId");

            migrationBuilder.RenameColumn(
                name: "Level100RetrofitStatsId",
                table: "Ships",
                newName: "Level100RetrofitStatsIdId");

            migrationBuilder.RenameColumn(
                name: "BaseStatsId",
                table: "Ships",
                newName: "BaseStatsIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Ships_Level120StatsId",
                table: "Ships",
                newName: "IX_Ships_Level120StatsIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Ships_Level120RetrofitStatsId",
                table: "Ships",
                newName: "IX_Ships_Level120RetrofitStatsIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Ships_Level100StatsId",
                table: "Ships",
                newName: "IX_Ships_Level100StatsIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Ships_Level100RetrofitStatsId",
                table: "Ships",
                newName: "IX_Ships_Level100RetrofitStatsIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Ships_BaseStatsId",
                table: "Ships",
                newName: "IX_Ships_BaseStatsIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipStats_BaseStatsIdId",
                table: "Ships",
                column: "BaseStatsIdId",
                principalTable: "ShipStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipStats_Level100RetrofitStatsIdId",
                table: "Ships",
                column: "Level100RetrofitStatsIdId",
                principalTable: "ShipStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipStats_Level100StatsIdId",
                table: "Ships",
                column: "Level100StatsIdId",
                principalTable: "ShipStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipStats_Level120RetrofitStatsIdId",
                table: "Ships",
                column: "Level120RetrofitStatsIdId",
                principalTable: "ShipStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ships_ShipStats_Level120StatsIdId",
                table: "Ships",
                column: "Level120StatsIdId",
                principalTable: "ShipStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
