using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzurLaneClasses.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ALTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    WriteGrant = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALTokens", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AntiAirGuns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Firepower = table.Column<int>(type: "int", nullable: false),
                    AntiAir = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Reload = table.Column<double>(type: "double", nullable: false),
                    AADPS = table.Column<double>(type: "double", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    Nation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntiAirGuns", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Auxiliaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Firepower = table.Column<int>(type: "int", nullable: false),
                    AntiAir = table.Column<int>(type: "int", nullable: false),
                    Torpedo = table.Column<int>(type: "int", nullable: false),
                    Aviation = table.Column<int>(type: "int", nullable: false),
                    Reload = table.Column<int>(type: "int", nullable: false),
                    Evasion = table.Column<int>(type: "int", nullable: false),
                    AntiSubmarine = table.Column<int>(type: "int", nullable: false),
                    Oxygen = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auxiliaries", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BattleshipGuns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Firepower = table.Column<int>(type: "int", nullable: false),
                    AntiAir = table.Column<int>(type: "int", nullable: false),
                    Rounds = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoundsPerSecond = table.Column<double>(type: "double", nullable: false),
                    DamagePerShot = table.Column<int>(type: "int", nullable: false),
                    DamageCoefficient = table.Column<int>(type: "int", nullable: false),
                    VolleyTime = table.Column<double>(type: "double", nullable: false),
                    Reload = table.Column<double>(type: "double", nullable: false),
                    RawDPS = table.Column<double>(type: "double", nullable: false),
                    LightArmorDPS = table.Column<double>(type: "double", nullable: false),
                    MediumArmorDPS = table.Column<double>(type: "double", nullable: false),
                    HeavyArmorDPS = table.Column<double>(type: "double", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    Spread = table.Column<int>(type: "int", nullable: false),
                    Angle = table.Column<int>(type: "int", nullable: false),
                    Attribute = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AmmoType = table.Column<int>(type: "int", nullable: false),
                    Nation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleshipGuns", x => x.Id);
                })
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
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateTable(
                name: "DestroyerGuns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Firepower = table.Column<int>(type: "int", nullable: false),
                    AntiAir = table.Column<int>(type: "int", nullable: false),
                    Rounds = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoundsPerSecond = table.Column<double>(type: "double", nullable: false),
                    DamagePerShot = table.Column<int>(type: "int", nullable: false),
                    DamageCoefficient = table.Column<int>(type: "int", nullable: false),
                    VolleyTime = table.Column<double>(type: "double", nullable: false),
                    Reload = table.Column<double>(type: "double", nullable: false),
                    RawDPS = table.Column<double>(type: "double", nullable: false),
                    LightArmorDPS = table.Column<double>(type: "double", nullable: false),
                    MediumArmorDPS = table.Column<double>(type: "double", nullable: false),
                    HeavyArmorDPS = table.Column<double>(type: "double", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    Spread = table.Column<int>(type: "int", nullable: false),
                    Angle = table.Column<int>(type: "int", nullable: false),
                    Attribute = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AmmoType = table.Column<int>(type: "int", nullable: false),
                    Nation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestroyerGuns", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiveBomberPlanes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aviation = table.Column<int>(type: "int", nullable: false),
                    Reload = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_LightArmor = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_MediumArmor = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_HeavyArmor = table.Column<double>(type: "double", nullable: false),
                    AntiAir_DPS = table.Column<double>(type: "double", nullable: false),
                    AntiAir_Burst = table.Column<double>(type: "double", nullable: false),
                    Crash_Speed = table.Column<int>(type: "int", nullable: false),
                    Crash_Damage = table.Column<int>(type: "int", nullable: false),
                    Nation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiveBomberPlanes", x => x.Id);
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
                name: "FighterPlanes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aviation = table.Column<int>(type: "int", nullable: false),
                    Reload = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_LightArmor = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_MediumArmor = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_HeavyArmor = table.Column<double>(type: "double", nullable: false),
                    AntiAir_DPS = table.Column<double>(type: "double", nullable: false),
                    AntiAir_Burst = table.Column<double>(type: "double", nullable: false),
                    Crash_Speed = table.Column<int>(type: "int", nullable: false),
                    Crash_Damage = table.Column<int>(type: "int", nullable: false),
                    Nation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FighterPlanes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HeavyCruiserGuns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Firepower = table.Column<int>(type: "int", nullable: false),
                    AntiAir = table.Column<int>(type: "int", nullable: false),
                    Rounds = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoundsPerSecond = table.Column<double>(type: "double", nullable: false),
                    DamagePerShot = table.Column<int>(type: "int", nullable: false),
                    DamageCoefficient = table.Column<int>(type: "int", nullable: false),
                    VolleyTime = table.Column<double>(type: "double", nullable: false),
                    Reload = table.Column<double>(type: "double", nullable: false),
                    RawDPS = table.Column<double>(type: "double", nullable: false),
                    LightArmorDPS = table.Column<double>(type: "double", nullable: false),
                    MediumArmorDPS = table.Column<double>(type: "double", nullable: false),
                    HeavyArmorDPS = table.Column<double>(type: "double", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    Spread = table.Column<int>(type: "int", nullable: false),
                    Angle = table.Column<int>(type: "int", nullable: false),
                    Attribute = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AmmoType = table.Column<int>(type: "int", nullable: false),
                    Nation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeavyCruiserGuns", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LargeCruiserGuns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Firepower = table.Column<int>(type: "int", nullable: false),
                    AntiAir = table.Column<int>(type: "int", nullable: false),
                    Rounds = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoundsPerSecond = table.Column<double>(type: "double", nullable: false),
                    DamagePerShot = table.Column<int>(type: "int", nullable: false),
                    DamageCoefficient = table.Column<int>(type: "int", nullable: false),
                    VolleyTime = table.Column<double>(type: "double", nullable: false),
                    Reload = table.Column<double>(type: "double", nullable: false),
                    RawDPS = table.Column<double>(type: "double", nullable: false),
                    LightArmorDPS = table.Column<double>(type: "double", nullable: false),
                    MediumArmorDPS = table.Column<double>(type: "double", nullable: false),
                    HeavyArmorDPS = table.Column<double>(type: "double", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    Spread = table.Column<int>(type: "int", nullable: false),
                    Angle = table.Column<int>(type: "int", nullable: false),
                    Attribute = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AmmoType = table.Column<int>(type: "int", nullable: false),
                    Nation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LargeCruiserGuns", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LightCruiserGuns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Firepower = table.Column<int>(type: "int", nullable: false),
                    AntiAir = table.Column<int>(type: "int", nullable: false),
                    Rounds = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoundsPerSecond = table.Column<double>(type: "double", nullable: false),
                    DamagePerShot = table.Column<int>(type: "int", nullable: false),
                    DamageCoefficient = table.Column<int>(type: "int", nullable: false),
                    VolleyTime = table.Column<double>(type: "double", nullable: false),
                    Reload = table.Column<double>(type: "double", nullable: false),
                    RawDPS = table.Column<double>(type: "double", nullable: false),
                    LightArmorDPS = table.Column<double>(type: "double", nullable: false),
                    MediumArmorDPS = table.Column<double>(type: "double", nullable: false),
                    HeavyArmorDPS = table.Column<double>(type: "double", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    Spread = table.Column<int>(type: "int", nullable: false),
                    Angle = table.Column<int>(type: "int", nullable: false),
                    Attribute = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AmmoType = table.Column<int>(type: "int", nullable: false),
                    Nation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightCruiserGuns", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Seaplanes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aviation = table.Column<int>(type: "int", nullable: false),
                    Reload = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_LightArmor = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_MediumArmor = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_HeavyArmor = table.Column<double>(type: "double", nullable: false),
                    AntiAir_DPS = table.Column<double>(type: "double", nullable: false),
                    AntiAir_Burst = table.Column<double>(type: "double", nullable: false),
                    Crash_Speed = table.Column<int>(type: "int", nullable: false),
                    Crash_Damage = table.Column<int>(type: "int", nullable: false),
                    Nation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seaplanes", x => x.Id);
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
                name: "SubmarineTorpedoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TorpedoPower = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberOfTorpedoes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DamagerPerTorpedo = table.Column<int>(type: "int", nullable: false),
                    Reload = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_LightArmor = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_MediumArmor = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_HeavyArmor = table.Column<double>(type: "double", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    Spread = table.Column<int>(type: "int", nullable: false),
                    Angle = table.Column<int>(type: "int", nullable: false),
                    Attribute = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nation = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PreloadDPS_LightArmor = table.Column<double>(type: "double", nullable: true),
                    PreloadDPS_MediumArmor = table.Column<double>(type: "double", nullable: true),
                    PreloadDPS_HeavyArmor = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmarineTorpedoes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TorpedoBomberPlanes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IconUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aviation = table.Column<int>(type: "int", nullable: false),
                    Reload = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_LightArmor = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_MediumArmor = table.Column<double>(type: "double", nullable: false),
                    SurfaceDPS_HeavyArmor = table.Column<double>(type: "double", nullable: false),
                    AntiAir_DPS = table.Column<double>(type: "double", nullable: false),
                    AntiAir_Burst = table.Column<double>(type: "double", nullable: false),
                    Crash_Speed = table.Column<int>(type: "int", nullable: false),
                    Crash_Damage = table.Column<int>(type: "int", nullable: false),
                    Nation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TorpedoBomberPlanes", x => x.Id);
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
                    BaseStatsId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Level100StatsId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Level100RetrofitStatsId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Level120StatsId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Level120RetrofitStatsId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    EquippableTypeSlot1 = table.Column<int>(type: "int", nullable: false),
                    EquippableTypeSlot2 = table.Column<int>(type: "int", nullable: false),
                    EquippableTypeSlot3 = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_ShipStats_BaseStatsId",
                        column: x => x.BaseStatsId,
                        principalTable: "ShipStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ships_ShipStats_Level100RetrofitStatsId",
                        column: x => x.Level100RetrofitStatsId,
                        principalTable: "ShipStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ships_ShipStats_Level100StatsId",
                        column: x => x.Level100StatsId,
                        principalTable: "ShipStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ships_ShipStats_Level120RetrofitStatsId",
                        column: x => x.Level120RetrofitStatsId,
                        principalTable: "ShipStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ships_ShipStats_Level120StatsId",
                        column: x => x.Level120StatsId,
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
                name: "IX_Ships_BaseStatsId",
                table: "Ships",
                column: "BaseStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_Level100RetrofitStatsId",
                table: "Ships",
                column: "Level100RetrofitStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_Level100StatsId",
                table: "Ships",
                column: "Level100StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_Level120RetrofitStatsId",
                table: "Ships",
                column: "Level120RetrofitStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_Level120StatsId",
                table: "Ships",
                column: "Level120StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipSkins_ShipId",
                table: "ShipSkins",
                column: "ShipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALTokens");

            migrationBuilder.DropTable(
                name: "AntiAirGuns");

            migrationBuilder.DropTable(
                name: "Auxiliaries");

            migrationBuilder.DropTable(
                name: "BattleshipGuns");

            migrationBuilder.DropTable(
                name: "CampaignLevels");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "ConstructionPools");

            migrationBuilder.DropTable(
                name: "DestroyerGuns");

            migrationBuilder.DropTable(
                name: "DiveBomberPlanes");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "FighterPlanes");

            migrationBuilder.DropTable(
                name: "HeavyCruiserGuns");

            migrationBuilder.DropTable(
                name: "LargeCruiserGuns");

            migrationBuilder.DropTable(
                name: "LightCruiserGuns");

            migrationBuilder.DropTable(
                name: "Seaplanes");

            migrationBuilder.DropTable(
                name: "ShipClasses");

            migrationBuilder.DropTable(
                name: "ShipSkins");

            migrationBuilder.DropTable(
                name: "SubmarineTorpedoes");

            migrationBuilder.DropTable(
                name: "TorpedoBomberPlanes");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "ShipStats");
        }
    }
}
