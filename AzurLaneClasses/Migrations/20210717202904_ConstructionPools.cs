using Microsoft.EntityFrameworkCore.Migrations;

namespace AzurLaneClasses.Migrations
{
    public partial class ConstructionPools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConstructionPools",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Coins = table.Column<int>(type: "int", nullable: false),
                    WisdomCubes = table.Column<int>(type: "int", nullable: false),
                    CV = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CVL = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DD = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CL = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CA = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BM = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BC = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BB = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AR = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SS = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionPools", x => x.Name);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstructionPools");
        }
    }
}
