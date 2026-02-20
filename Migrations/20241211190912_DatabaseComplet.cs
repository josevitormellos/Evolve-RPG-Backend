using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evolve_Game.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseComplet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtributteElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtributteElements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EffectsConections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffectsConections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EvolutionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvolutionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rarities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdIcon = table.Column<int>(type: "int", nullable: false),
                    IdDrop = table.Column<int>(type: "int", nullable: false),
                    DropId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chests_Drops_DropId",
                        column: x => x.DropId,
                        principalTable: "Drops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Effects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectActive = table.Column<int>(type: "int", nullable: false),
                    IsEffectContinue = table.Column<bool>(type: "bit", nullable: false),
                    IsEffectPlayer = table.Column<bool>(type: "bit", nullable: false),
                    IsEffectAttackContinue = table.Column<bool>(type: "bit", nullable: false),
                    IsEffectDamageContinue = table.Column<bool>(type: "bit", nullable: false),
                    EffectsConectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Effects_EffectsConections_EffectsConectionId",
                        column: x => x.EffectsConectionId,
                        principalTable: "EffectsConections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdIcon = table.Column<int>(type: "int", nullable: false),
                    IdAtributteElement = table.Column<int>(type: "int", nullable: false),
                    IdEffectsConection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_AtributteElements_IdAtributteElement",
                        column: x => x.IdAtributteElement,
                        principalTable: "AtributteElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skills_EffectsConections_IdEffectsConection",
                        column: x => x.IdEffectsConection,
                        principalTable: "EffectsConections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdIcon = table.Column<int>(type: "int", nullable: false),
                    LifeMin = table.Column<int>(type: "int", nullable: false),
                    LifeMax = table.Column<int>(type: "int", nullable: false),
                    MagicolaMin = table.Column<int>(type: "int", nullable: false),
                    MagicolaMax = table.Column<int>(type: "int", nullable: false),
                    PhysicalDamageMin = table.Column<int>(type: "int", nullable: false),
                    PhysicalDamageMax = table.Column<int>(type: "int", nullable: false),
                    MagicDamageMin = table.Column<int>(type: "int", nullable: false),
                    MagicDamageMax = table.Column<int>(type: "int", nullable: false),
                    PhysicalDefenseMin = table.Column<int>(type: "int", nullable: false),
                    PhysicalDefenseMax = table.Column<int>(type: "int", nullable: false),
                    MagicDefenseMin = table.Column<int>(type: "int", nullable: false),
                    MagicDefenseMax = table.Column<int>(type: "int", nullable: false),
                    SpeedAttackMin = table.Column<float>(type: "real", nullable: false),
                    SpeedAttackMax = table.Column<float>(type: "real", nullable: false),
                    CriticalChanceMin = table.Column<float>(type: "real", nullable: false),
                    CriticalChanceMax = table.Column<float>(type: "real", nullable: false),
                    CriticalDamageMin = table.Column<float>(type: "real", nullable: false),
                    CriticalDamageMax = table.Column<float>(type: "real", nullable: false),
                    IdEquipType = table.Column<int>(type: "int", nullable: false),
                    IdRarity = table.Column<int>(type: "int", nullable: false),
                    IdEffectsConection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equips_EffectsConections_IdEffectsConection",
                        column: x => x.IdEffectsConection,
                        principalTable: "EffectsConections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equips_EquipTypes_IdEquipType",
                        column: x => x.IdEquipType,
                        principalTable: "EquipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equips_Rarities_IdRarity",
                        column: x => x.IdRarity,
                        principalTable: "Rarities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConsumable = table.Column<bool>(type: "bit", nullable: false),
                    Gold = table.Column<int>(type: "int", nullable: false),
                    IdRarity = table.Column<int>(type: "int", nullable: false),
                    IdEffectsConection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_EffectsConections_IdEffectsConection",
                        column: x => x.IdEffectsConection,
                        principalTable: "EffectsConections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_Rarities_IdRarity",
                        column: x => x.IdRarity,
                        principalTable: "Rarities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Life = table.Column<int>(type: "int", nullable: false),
                    Magicola = table.Column<int>(type: "int", nullable: false),
                    PhysicalDamage = table.Column<int>(type: "int", nullable: false),
                    MagicDamage = table.Column<int>(type: "int", nullable: false),
                    PhysicalDefense = table.Column<int>(type: "int", nullable: false),
                    MagicDefense = table.Column<int>(type: "int", nullable: false),
                    SpeedAttack = table.Column<float>(type: "real", nullable: false),
                    CriticalChance = table.Column<float>(type: "real", nullable: false),
                    CriticalDamage = table.Column<float>(type: "real", nullable: false),
                    SpecialFire = table.Column<float>(type: "real", nullable: false),
                    SpecialWater = table.Column<float>(type: "real", nullable: false),
                    SpecialLight = table.Column<float>(type: "real", nullable: false),
                    SpecialShadow = table.Column<float>(type: "real", nullable: false),
                    SpecialFairy = table.Column<float>(type: "real", nullable: false),
                    DefenseFire = table.Column<float>(type: "real", nullable: false),
                    DefenseWater = table.Column<float>(type: "real", nullable: false),
                    DefenseLight = table.Column<float>(type: "real", nullable: false),
                    DefenseShadow = table.Column<float>(type: "real", nullable: false),
                    DefenseFairy = table.Column<float>(type: "real", nullable: false),
                    Skin = table.Column<int>(type: "int", nullable: false),
                    XpKill = table.Column<int>(type: "int", nullable: false),
                    GoldKill = table.Column<int>(type: "int", nullable: false),
                    ScaleSize = table.Column<float>(type: "real", nullable: false),
                    PosRotation = table.Column<bool>(type: "bit", nullable: false),
                    IdSpecie = table.Column<int>(type: "int", nullable: false),
                    IdRarity = table.Column<int>(type: "int", nullable: false),
                    IdDrop = table.Column<int>(type: "int", nullable: false),
                    IdEffectsConection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monsters_Drops_IdDrop",
                        column: x => x.IdDrop,
                        principalTable: "Drops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Monsters_EffectsConections_IdEffectsConection",
                        column: x => x.IdEffectsConection,
                        principalTable: "EffectsConections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Monsters_Rarities_IdRarity",
                        column: x => x.IdRarity,
                        principalTable: "Rarities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Monsters_Species_IdSpecie",
                        column: x => x.IdSpecie,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dungeons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMap = table.Column<int>(type: "int", nullable: false),
                    PosMax = table.Column<int>(type: "int", nullable: false),
                    ChestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dungeons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dungeons_Chests_ChestId",
                        column: x => x.ChestId,
                        principalTable: "Chests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EffectList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEffect = table.Column<int>(type: "int", nullable: false),
                    IdEffectsConection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffectList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EffectList_EffectsConections_IdEffectsConection",
                        column: x => x.IdEffectsConection,
                        principalTable: "EffectsConections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EffectList_Effects_IdEffect",
                        column: x => x.IdEffect,
                        principalTable: "Effects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DropEquips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEquip = table.Column<int>(type: "int", nullable: false),
                    IdDrop = table.Column<int>(type: "int", nullable: false),
                    ChanceDrop = table.Column<float>(type: "real", nullable: false),
                    IsBoss = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropEquips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DropEquips_Drops_IdDrop",
                        column: x => x.IdDrop,
                        principalTable: "Drops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DropEquips_Equips_IdEquip",
                        column: x => x.IdEquip,
                        principalTable: "Equips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DropItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdItem = table.Column<int>(type: "int", nullable: false),
                    IdDrop = table.Column<int>(type: "int", nullable: false),
                    ChanceDrop = table.Column<float>(type: "real", nullable: false),
                    IsBoss = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DropItems_Drops_IdDrop",
                        column: x => x.IdDrop,
                        principalTable: "Drops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DropItems_Itens_IdItem",
                        column: x => x.IdItem,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvolutionMonsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMonster = table.Column<int>(type: "int", nullable: false),
                    IdMonsterEvolution = table.Column<int>(type: "int", nullable: false),
                    MinLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvolutionMonsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvolutionMonsters_Monsters_IdMonster",
                        column: x => x.IdMonster,
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvolutionMonsters_Monsters_IdMonsterEvolution",
                        column: x => x.IdMonsterEvolution,
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonsterSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMonster = table.Column<int>(type: "int", nullable: false),
                    IdSkill = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterSkills_Monsters_IdMonster",
                        column: x => x.IdMonster,
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonsterSkills_Skills_IdSkill",
                        column: x => x.IdSkill,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DungeonChests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDungeon = table.Column<int>(type: "int", nullable: false),
                    IdChest = table.Column<int>(type: "int", nullable: false),
                    ChanceApper = table.Column<float>(type: "real", nullable: false),
                    DungeonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DungeonChests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DungeonChests_Chests_IdChest",
                        column: x => x.IdChest,
                        principalTable: "Chests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DungeonChests_Dungeons_DungeonId",
                        column: x => x.DungeonId,
                        principalTable: "Dungeons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DungeonChests_Dungeons_IdDungeon",
                        column: x => x.IdDungeon,
                        principalTable: "Dungeons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DungeonMonsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDungeon = table.Column<int>(type: "int", nullable: false),
                    IdMonster = table.Column<int>(type: "int", nullable: false),
                    MinLevel = table.Column<int>(type: "int", nullable: false),
                    MaxLevel = table.Column<int>(type: "int", nullable: false),
                    IsBoss = table.Column<bool>(type: "bit", nullable: false),
                    DungeonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DungeonMonsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DungeonMonsters_Dungeons_DungeonId",
                        column: x => x.DungeonId,
                        principalTable: "Dungeons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DungeonMonsters_Dungeons_IdDungeon",
                        column: x => x.IdDungeon,
                        principalTable: "Dungeons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DungeonMonsters_Monsters_IdMonster",
                        column: x => x.IdMonster,
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gold = table.Column<int>(type: "int", nullable: false),
                    IdDungeon = table.Column<int>(type: "int", nullable: false),
                    PosX = table.Column<int>(type: "int", nullable: false),
                    PosY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Dungeons_IdDungeon",
                        column: x => x.IdDungeon,
                        principalTable: "Dungeons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvolutionTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEvolutionType = table.Column<int>(type: "int", nullable: false),
                    IdEvolutionMonster = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvolutionTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvolutionTerms_EvolutionMonsters_IdEvolutionMonster",
                        column: x => x.IdEvolutionMonster,
                        principalTable: "EvolutionMonsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvolutionTerms_EvolutionTypes_IdEvolutionType",
                        column: x => x.IdEvolutionType,
                        principalTable: "EvolutionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerEquips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdEquip = table.Column<int>(type: "int", nullable: false),
                    Life = table.Column<int>(type: "int", nullable: false),
                    Magicula = table.Column<int>(type: "int", nullable: false),
                    PhysicalDamage = table.Column<int>(type: "int", nullable: false),
                    MagicDamage = table.Column<int>(type: "int", nullable: false),
                    PhysicalDefense = table.Column<int>(type: "int", nullable: false),
                    MagicDefense = table.Column<int>(type: "int", nullable: false),
                    SpeedAttack = table.Column<float>(type: "real", nullable: false),
                    CriticalChance = table.Column<float>(type: "real", nullable: false),
                    CriticalDamage = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerEquips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerEquips_Equips_IdEquip",
                        column: x => x.IdEquip,
                        principalTable: "Equips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerEquips_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerEquips_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdItem = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerItems_Itens_IdItem",
                        column: x => x.IdItem,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerItems_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMonsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdMonster = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Xp = table.Column<int>(type: "int", nullable: false),
                    IdRarity = table.Column<int>(type: "int", nullable: false),
                    ColorMagicGreen = table.Column<int>(type: "int", nullable: false),
                    ColorMagicBlue = table.Column<int>(type: "int", nullable: false),
                    ColorMagicRed = table.Column<int>(type: "int", nullable: false),
                    ColorMagicBlack = table.Column<int>(type: "int", nullable: false),
                    ColorMagicWhite = table.Column<int>(type: "int", nullable: false),
                    ColorMagicPink = table.Column<int>(type: "int", nullable: false),
                    ColorMagicPurple = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMonsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMonsters_Monsters_IdMonster",
                        column: x => x.IdMonster,
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMonsters_Rarities_IdRarity",
                        column: x => x.IdRarity,
                        principalTable: "Rarities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMonsters_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerEvolutionMonsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPlayerMonster = table.Column<int>(type: "int", nullable: false),
                    IdEvolutionMonster = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerEvolutionMonsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerEvolutionMonsters_EvolutionMonsters_IdEvolutionMonster",
                        column: x => x.IdEvolutionMonster,
                        principalTable: "EvolutionMonsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerEvolutionMonsters_PlayerMonsters_IdPlayerMonster",
                        column: x => x.IdPlayerMonster,
                        principalTable: "PlayerMonsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMonsterEquips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPlayerMonster = table.Column<int>(type: "int", nullable: false),
                    IdEquip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMonsterEquips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMonsterEquips_Equips_IdEquip",
                        column: x => x.IdEquip,
                        principalTable: "Equips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMonsterEquips_PlayerMonsters_IdPlayerMonster",
                        column: x => x.IdPlayerMonster,
                        principalTable: "PlayerMonsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMonsterSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPlayerMonster = table.Column<int>(type: "int", nullable: false),
                    IdSkill = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMonsterSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMonsterSkills_PlayerMonsters_IdPlayerMonster",
                        column: x => x.IdPlayerMonster,
                        principalTable: "PlayerMonsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerMonsterSkills_Skills_IdSkill",
                        column: x => x.IdSkill,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chests_DropId",
                table: "Chests",
                column: "DropId");

            migrationBuilder.CreateIndex(
                name: "IX_DropEquips_IdDrop",
                table: "DropEquips",
                column: "IdDrop");

            migrationBuilder.CreateIndex(
                name: "IX_DropEquips_IdEquip",
                table: "DropEquips",
                column: "IdEquip");

            migrationBuilder.CreateIndex(
                name: "IX_DropItems_IdDrop",
                table: "DropItems",
                column: "IdDrop");

            migrationBuilder.CreateIndex(
                name: "IX_DropItems_IdItem",
                table: "DropItems",
                column: "IdItem");

            migrationBuilder.CreateIndex(
                name: "IX_DungeonChests_DungeonId",
                table: "DungeonChests",
                column: "DungeonId");

            migrationBuilder.CreateIndex(
                name: "IX_DungeonChests_IdChest",
                table: "DungeonChests",
                column: "IdChest");

            migrationBuilder.CreateIndex(
                name: "IX_DungeonChests_IdDungeon",
                table: "DungeonChests",
                column: "IdDungeon");

            migrationBuilder.CreateIndex(
                name: "IX_DungeonMonsters_DungeonId",
                table: "DungeonMonsters",
                column: "DungeonId");

            migrationBuilder.CreateIndex(
                name: "IX_DungeonMonsters_IdDungeon",
                table: "DungeonMonsters",
                column: "IdDungeon");

            migrationBuilder.CreateIndex(
                name: "IX_DungeonMonsters_IdMonster",
                table: "DungeonMonsters",
                column: "IdMonster");

            migrationBuilder.CreateIndex(
                name: "IX_Dungeons_ChestId",
                table: "Dungeons",
                column: "ChestId");

            migrationBuilder.CreateIndex(
                name: "IX_EffectList_IdEffect",
                table: "EffectList",
                column: "IdEffect");

            migrationBuilder.CreateIndex(
                name: "IX_EffectList_IdEffectsConection",
                table: "EffectList",
                column: "IdEffectsConection");

            migrationBuilder.CreateIndex(
                name: "IX_Effects_EffectsConectionId",
                table: "Effects",
                column: "EffectsConectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Equips_IdEffectsConection",
                table: "Equips",
                column: "IdEffectsConection");

            migrationBuilder.CreateIndex(
                name: "IX_Equips_IdEquipType",
                table: "Equips",
                column: "IdEquipType");

            migrationBuilder.CreateIndex(
                name: "IX_Equips_IdRarity",
                table: "Equips",
                column: "IdRarity");

            migrationBuilder.CreateIndex(
                name: "IX_EvolutionMonsters_IdMonster",
                table: "EvolutionMonsters",
                column: "IdMonster");

            migrationBuilder.CreateIndex(
                name: "IX_EvolutionMonsters_IdMonsterEvolution",
                table: "EvolutionMonsters",
                column: "IdMonsterEvolution");

            migrationBuilder.CreateIndex(
                name: "IX_EvolutionTerms_IdEvolutionMonster",
                table: "EvolutionTerms",
                column: "IdEvolutionMonster");

            migrationBuilder.CreateIndex(
                name: "IX_EvolutionTerms_IdEvolutionType",
                table: "EvolutionTerms",
                column: "IdEvolutionType");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_IdEffectsConection",
                table: "Itens",
                column: "IdEffectsConection");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_IdRarity",
                table: "Itens",
                column: "IdRarity");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_IdDrop",
                table: "Monsters",
                column: "IdDrop");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_IdEffectsConection",
                table: "Monsters",
                column: "IdEffectsConection");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_IdRarity",
                table: "Monsters",
                column: "IdRarity");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_IdSpecie",
                table: "Monsters",
                column: "IdSpecie");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterSkills_IdMonster",
                table: "MonsterSkills",
                column: "IdMonster");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterSkills_IdSkill",
                table: "MonsterSkills",
                column: "IdSkill");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerEquips_IdEquip",
                table: "PlayerEquips",
                column: "IdEquip");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerEquips_IdUser",
                table: "PlayerEquips",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerEquips_UserId",
                table: "PlayerEquips",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerEvolutionMonsters_IdEvolutionMonster",
                table: "PlayerEvolutionMonsters",
                column: "IdEvolutionMonster");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerEvolutionMonsters_IdPlayerMonster",
                table: "PlayerEvolutionMonsters",
                column: "IdPlayerMonster");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerItems_IdItem",
                table: "PlayerItems",
                column: "IdItem");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerItems_IdUser",
                table: "PlayerItems",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMonsterEquips_IdEquip",
                table: "PlayerMonsterEquips",
                column: "IdEquip");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMonsterEquips_IdPlayerMonster",
                table: "PlayerMonsterEquips",
                column: "IdPlayerMonster");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMonsters_IdMonster",
                table: "PlayerMonsters",
                column: "IdMonster");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMonsters_IdRarity",
                table: "PlayerMonsters",
                column: "IdRarity");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMonsters_IdUser",
                table: "PlayerMonsters",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMonsterSkills_IdPlayerMonster",
                table: "PlayerMonsterSkills",
                column: "IdPlayerMonster");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMonsterSkills_IdSkill",
                table: "PlayerMonsterSkills",
                column: "IdSkill");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_IdAtributteElement",
                table: "Skills",
                column: "IdAtributteElement");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_IdEffectsConection",
                table: "Skills",
                column: "IdEffectsConection");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdDungeon",
                table: "Users",
                column: "IdDungeon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DropEquips");

            migrationBuilder.DropTable(
                name: "DropItems");

            migrationBuilder.DropTable(
                name: "DungeonChests");

            migrationBuilder.DropTable(
                name: "DungeonMonsters");

            migrationBuilder.DropTable(
                name: "EffectList");

            migrationBuilder.DropTable(
                name: "EvolutionTerms");

            migrationBuilder.DropTable(
                name: "MonsterSkills");

            migrationBuilder.DropTable(
                name: "PlayerEquips");

            migrationBuilder.DropTable(
                name: "PlayerEvolutionMonsters");

            migrationBuilder.DropTable(
                name: "PlayerItems");

            migrationBuilder.DropTable(
                name: "PlayerMonsterEquips");

            migrationBuilder.DropTable(
                name: "PlayerMonsterSkills");

            migrationBuilder.DropTable(
                name: "Versions");

            migrationBuilder.DropTable(
                name: "Effects");

            migrationBuilder.DropTable(
                name: "EvolutionTypes");

            migrationBuilder.DropTable(
                name: "EvolutionMonsters");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Equips");

            migrationBuilder.DropTable(
                name: "PlayerMonsters");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "EquipTypes");

            migrationBuilder.DropTable(
                name: "Monsters");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AtributteElements");

            migrationBuilder.DropTable(
                name: "EffectsConections");

            migrationBuilder.DropTable(
                name: "Rarities");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Dungeons");

            migrationBuilder.DropTable(
                name: "Chests");

            migrationBuilder.DropTable(
                name: "Drops");
        }
    }
}
