using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeCommon.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    AbilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Chs = table.Column<string>(type: "nvarchar(20)", nullable: true, comment: "中文名"),
                    Name_Eng = table.Column<string>(type: "varchar(40)", nullable: true, comment: "英文名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_Jpn = table.Column<string>(type: "nvarchar(20)", nullable: true, comment: "日文名"),
                    description_Chs = table.Column<string>(type: "nvarchar(100)", nullable: true, comment: "中文描述"),
                    description_Eng = table.Column<string>(type: "varchar(200)", nullable: true, comment: "英文描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description_Jpn = table.Column<string>(type: "nvarchar(100)", nullable: true, comment: "日文描述")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.AbilityId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Chs = table.Column<string>(type: "nvarchar(2)", nullable: true, comment: "中文名"),
                    Name_Eng = table.Column<string>(type: "varchar(10)", nullable: true, comment: "英文名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_Jpn = table.Column<string>(type: "nvarchar(10)", nullable: true, comment: "日文名")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Egg_Groups",
                columns: table => new
                {
                    EggGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Chs = table.Column<string>(type: "nvarchar(20)", nullable: true, comment: "中文名"),
                    Name_Eng = table.Column<string>(type: "varchar(40)", nullable: true, comment: "英文名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_Jpn = table.Column<string>(type: "nvarchar(20)", nullable: true, comment: "日文名")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egg_Groups", x => x.EggGroupId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Chs = table.Column<string>(type: "nvarchar(20)", nullable: true, comment: "中文名"),
                    Name_Eng = table.Column<string>(type: "varchar(40)", nullable: true, comment: "英文名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_Jpn = table.Column<string>(type: "nvarchar(20)", nullable: true, comment: "日文名"),
                    description_Chs = table.Column<string>(type: "nvarchar(100)", nullable: true, comment: "中文描述"),
                    description_Eng = table.Column<string>(type: "varchar(200)", nullable: true, comment: "英文描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description_Jpn = table.Column<string>(type: "nvarchar(100)", nullable: true, comment: "日文描述"),
                    Item_Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Performances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Chs = table.Column<string>(type: "nvarchar(2)", nullable: true, comment: "中文名"),
                    Name_Eng = table.Column<string>(type: "varchar(10)", nullable: true, comment: "英文名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_Jpn = table.Column<string>(type: "nvarchar(6)", nullable: true, comment: "日文名")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performances", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PokeDex",
                columns: table => new
                {
                    PokeDexId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    National_Dex_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokeDex", x => x.PokeDexId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PokeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Chs = table.Column<string>(type: "nvarchar(5)", nullable: true, comment: "中文名"),
                    Name_Eng = table.Column<string>(type: "varchar(20)", nullable: true, comment: "英文名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_Jpn = table.Column<string>(type: "nvarchar(10)", nullable: true, comment: "日文名")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokeTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Flavors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Chs = table.Column<string>(type: "nvarchar(1)", nullable: true, comment: "中文名"),
                    Name_Eng = table.Column<string>(type: "varchar(10)", nullable: true, comment: "英文名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_Jpn = table.Column<string>(type: "nvarchar(5)", nullable: true, comment: "日文名"),
                    Condition_UpId = table.Column<int>(type: "int", nullable: true),
                    Performance_UpId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flavors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flavors_Conditions_Condition_UpId",
                        column: x => x.Condition_UpId,
                        principalTable: "Conditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flavors_Performances_Performance_UpId",
                        column: x => x.Performance_UpId,
                        principalTable: "Performances",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    MoveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Chs = table.Column<string>(type: "nvarchar(20)", nullable: true, comment: "中文名"),
                    Name_Eng = table.Column<string>(type: "varchar(40)", nullable: true, comment: "英文名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_Jpn = table.Column<string>(type: "nvarchar(20)", nullable: true, comment: "日文名"),
                    description_Chs = table.Column<string>(type: "nvarchar(100)", nullable: true, comment: "中文描述"),
                    description_Eng = table.Column<string>(type: "varchar(200)", nullable: true, comment: "英文描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description_Jpn = table.Column<string>(type: "nvarchar(100)", nullable: true, comment: "日文描述"),
                    Pow = table.Column<int>(type: "int", nullable: true),
                    Acc = table.Column<int>(type: "int", nullable: true),
                    PP = table.Column<int>(type: "int", nullable: false),
                    MoveTypeId = table.Column<int>(type: "int", nullable: true),
                    Damage_Type = table.Column<string>(type: "nvarchar(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.MoveId);
                    table.ForeignKey(
                        name: "FK_Moves_PokeTypes_MoveTypeId",
                        column: x => x.MoveTypeId,
                        principalTable: "PokeTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DexId = table.Column<int>(type: "int", nullable: false, comment: "全国图鉴编号"),
                    NameChs = table.Column<string>(type: "nvarchar(20)", nullable: true, comment: "中文名"),
                    NameEng = table.Column<string>(type: "varchar(40)", nullable: true, comment: "英文名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameJpn = table.Column<string>(type: "nvarchar(20)", nullable: true, comment: "日文名"),
                    PokeFormId = table.Column<int>(type: "int", nullable: false, comment: "形态编号"),
                    FormNameChs = table.Column<string>(type: "nvarchar(30)", nullable: true, comment: "形态名"),
                    FormNameEng = table.Column<string>(type: "varchar(40)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormNameJpn = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    FullNameChs = table.Column<string>(type: "nvarchar(30)", nullable: true, comment: "全名"),
                    FullNameEng = table.Column<string>(type: "varchar(60)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullNameJpn = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Stage = table.Column<int>(type: "int", nullable: false, comment: "意味無し"),
                    DMax = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "能否极巨化"),
                    BaseHP = table.Column<int>(type: "int", nullable: false),
                    BaseAtk = table.Column<int>(type: "int", nullable: false),
                    BaseDef = table.Column<int>(type: "int", nullable: false),
                    BaseSpa = table.Column<int>(type: "int", nullable: false),
                    BaseSpd = table.Column<int>(type: "int", nullable: false),
                    BaseSpe = table.Column<int>(type: "int", nullable: false),
                    EVHP = table.Column<int>(type: "int", nullable: false),
                    EVAtk = table.Column<int>(type: "int", nullable: false),
                    EVDef = table.Column<int>(type: "int", nullable: false),
                    EVSpa = table.Column<int>(type: "int", nullable: false),
                    EVSpd = table.Column<int>(type: "int", nullable: false),
                    EVSpe = table.Column<int>(type: "int", nullable: false),
                    GenderRatio = table.Column<int>(type: "int", nullable: false, comment: "♀/(♂+♀)=(GenderRatio+1)/(255+1),254雌性,255无性别"),
                    CatchRate = table.Column<int>(type: "int", nullable: false),
                    Ability1AbilityId = table.Column<int>(type: "int", nullable: true),
                    Ability2AbilityId = table.Column<int>(type: "int", nullable: true),
                    AbilityHAbilityId = table.Column<int>(type: "int", nullable: true),
                    Type1Id = table.Column<int>(type: "int", nullable: true),
                    Type2Id = table.Column<int>(type: "int", nullable: true),
                    EXPGroup = table.Column<int>(type: "int", nullable: false, comment: "1:Erratic,2:Fast,3:Medium Fast,4:Medium Slow,5:Slow"),
                    EggGroup1EggGroupId = table.Column<int>(type: "int", nullable: true),
                    EggGroup2EggGroupId = table.Column<int>(type: "int", nullable: true),
                    HatchCycles = table.Column<int>(type: "int", nullable: false, comment: "孵化周期"),
                    Height = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false, comment: "0-9:红色,蓝色,绿色,黄色,紫色,粉红色,褐色,黑色,灰色,白色"),
                    PokeDexId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemons_Abilities_Ability1AbilityId",
                        column: x => x.Ability1AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "AbilityId");
                    table.ForeignKey(
                        name: "FK_Pokemons_Abilities_Ability2AbilityId",
                        column: x => x.Ability2AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "AbilityId");
                    table.ForeignKey(
                        name: "FK_Pokemons_Abilities_AbilityHAbilityId",
                        column: x => x.AbilityHAbilityId,
                        principalTable: "Abilities",
                        principalColumn: "AbilityId");
                    table.ForeignKey(
                        name: "FK_Pokemons_Egg_Groups_EggGroup1EggGroupId",
                        column: x => x.EggGroup1EggGroupId,
                        principalTable: "Egg_Groups",
                        principalColumn: "EggGroupId");
                    table.ForeignKey(
                        name: "FK_Pokemons_Egg_Groups_EggGroup2EggGroupId",
                        column: x => x.EggGroup2EggGroupId,
                        principalTable: "Egg_Groups",
                        principalColumn: "EggGroupId");
                    table.ForeignKey(
                        name: "FK_Pokemons_PokeDex_PokeDexId",
                        column: x => x.PokeDexId,
                        principalTable: "PokeDex",
                        principalColumn: "PokeDexId");
                    table.ForeignKey(
                        name: "FK_Pokemons_PokeTypes_Type1Id",
                        column: x => x.Type1Id,
                        principalTable: "PokeTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pokemons_PokeTypes_Type2Id",
                        column: x => x.Type2Id,
                        principalTable: "PokeTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypeEffect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type1Id = table.Column<int>(type: "int", nullable: true),
                    Type2Id = table.Column<int>(type: "int", nullable: true),
                    Effect = table.Column<decimal>(type: "decimal(2,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEffect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeEffect_PokeTypes_Type1Id",
                        column: x => x.Type1Id,
                        principalTable: "PokeTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TypeEffect_PokeTypes_Type2Id",
                        column: x => x.Type2Id,
                        principalTable: "PokeTypes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Chs = table.Column<string>(type: "nvarchar(3)", nullable: true, comment: "中文名"),
                    Name_Eng = table.Column<string>(type: "varchar(20)", nullable: true, comment: "英文名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_Jpn = table.Column<string>(type: "nvarchar(10)", nullable: true, comment: "日文名"),
                    FlavorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistics_Flavors_FlavorId",
                        column: x => x.FlavorId,
                        principalTable: "Flavors",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PSPokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PSName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PSImgName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PSChsName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    AllValue = table.Column<int>(type: "int", nullable: false),
                    PokemonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSPokemons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PSPokemons_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Natures",
                columns: table => new
                {
                    NatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Chs = table.Column<string>(type: "nvarchar(5)", nullable: true, comment: "中文名"),
                    Name_Eng = table.Column<string>(type: "varchar(15)", nullable: true, comment: "英文名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name_Jpn = table.Column<string>(type: "nvarchar(10)", nullable: true, comment: "日文名"),
                    Stat_UpId = table.Column<int>(type: "int", nullable: true),
                    Stat_DownId = table.Column<int>(type: "int", nullable: true),
                    Perf_UpId = table.Column<int>(type: "int", nullable: true),
                    Perf_DownId = table.Column<int>(type: "int", nullable: true),
                    Flavor_UpId = table.Column<int>(type: "int", nullable: true),
                    Flavor_DownId = table.Column<int>(type: "int", nullable: true),
                    Performance_value = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Natures", x => x.NatureId);
                    table.ForeignKey(
                        name: "FK_Natures_Flavors_Flavor_DownId",
                        column: x => x.Flavor_DownId,
                        principalTable: "Flavors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Natures_Flavors_Flavor_UpId",
                        column: x => x.Flavor_UpId,
                        principalTable: "Flavors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Natures_Performances_Perf_DownId",
                        column: x => x.Perf_DownId,
                        principalTable: "Performances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Natures_Performances_Perf_UpId",
                        column: x => x.Perf_UpId,
                        principalTable: "Performances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Natures_Statistics_Stat_DownId",
                        column: x => x.Stat_DownId,
                        principalTable: "Statistics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Natures_Statistics_Stat_UpId",
                        column: x => x.Stat_UpId,
                        principalTable: "Statistics",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Flavors_Condition_UpId",
                table: "Flavors",
                column: "Condition_UpId");

            migrationBuilder.CreateIndex(
                name: "IX_Flavors_Performance_UpId",
                table: "Flavors",
                column: "Performance_UpId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_MoveTypeId",
                table: "Moves",
                column: "MoveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Natures_Flavor_DownId",
                table: "Natures",
                column: "Flavor_DownId");

            migrationBuilder.CreateIndex(
                name: "IX_Natures_Flavor_UpId",
                table: "Natures",
                column: "Flavor_UpId");

            migrationBuilder.CreateIndex(
                name: "IX_Natures_Perf_DownId",
                table: "Natures",
                column: "Perf_DownId");

            migrationBuilder.CreateIndex(
                name: "IX_Natures_Perf_UpId",
                table: "Natures",
                column: "Perf_UpId");

            migrationBuilder.CreateIndex(
                name: "IX_Natures_Stat_DownId",
                table: "Natures",
                column: "Stat_DownId");

            migrationBuilder.CreateIndex(
                name: "IX_Natures_Stat_UpId",
                table: "Natures",
                column: "Stat_UpId");

            migrationBuilder.CreateIndex(
                name: "IX_PSPokemons_PokemonId",
                table: "PSPokemons",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_Ability1AbilityId",
                table: "Pokemons",
                column: "Ability1AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_Ability2AbilityId",
                table: "Pokemons",
                column: "Ability2AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_AbilityHAbilityId",
                table: "Pokemons",
                column: "AbilityHAbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_EggGroup1EggGroupId",
                table: "Pokemons",
                column: "EggGroup1EggGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_EggGroup2EggGroupId",
                table: "Pokemons",
                column: "EggGroup2EggGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_PokeDexId",
                table: "Pokemons",
                column: "PokeDexId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_Type1Id",
                table: "Pokemons",
                column: "Type1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_Type2Id",
                table: "Pokemons",
                column: "Type2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_FlavorId",
                table: "Statistics",
                column: "FlavorId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeEffect_Type1Id",
                table: "TypeEffect",
                column: "Type1Id");

            migrationBuilder.CreateIndex(
                name: "IX_TypeEffect_Type2Id",
                table: "TypeEffect",
                column: "Type2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Natures");

            migrationBuilder.DropTable(
                name: "PSPokemons");

            migrationBuilder.DropTable(
                name: "TypeEffect");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "Flavors");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Egg_Groups");

            migrationBuilder.DropTable(
                name: "PokeDex");

            migrationBuilder.DropTable(
                name: "PokeTypes");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Performances");
        }
    }
}
