using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonisshoniZ.Migrations
{
    /// <inheritdoc />
    public partial class addMatchRound1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PCLMatchPlayer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(270)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PCLMatchId = table.Column<int>(type: "int", nullable: false),
                    Declaration = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ShadowId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    QQ = table.Column<string>(type: "varchar(15)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsChecked = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PreTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCLMatchPlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PCLMatchPlayer_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCLMatchPlayer_PCLMatches_PCLMatchId",
                        column: x => x.PCLMatchId,
                        principalTable: "PCLMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCLMatchPlayer_PokeTeams_PreTeamId",
                        column: x => x.PreTeamId,
                        principalTable: "PokeTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PCLMatchRound",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PCLMatchId = table.Column<int>(type: "int", nullable: false),
                    PCLRoundType = table.Column<int>(type: "int", nullable: false),
                    IsGroup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GroupCnt = table.Column<int>(type: "int", nullable: false),
                    PCLRoundState = table.Column<int>(type: "int", nullable: false),
                    LockTeam = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AcceptTeamSubmit = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CanSeeOppTeam = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BO = table.Column<int>(type: "int", nullable: false),
                    RoundPromotion = table.Column<int>(type: "int", nullable: false),
                    WinScore = table.Column<int>(type: "int", nullable: false),
                    DrawScore = table.Column<int>(type: "int", nullable: false),
                    LoseScore = table.Column<int>(type: "int", nullable: false),
                    SwissCount = table.Column<int>(type: "int", nullable: false),
                    Swissidx = table.Column<int>(type: "int", nullable: false),
                    SwissPromotionType = table.Column<int>(type: "int", nullable: false),
                    EliminationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCLMatchRound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PCLMatchRound_PCLMatches_PCLMatchId",
                        column: x => x.PCLMatchId,
                        principalTable: "PCLMatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PCLMatchPlayer_PCLMatchId",
                table: "PCLMatchPlayer",
                column: "PCLMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PCLMatchPlayer_PreTeamId",
                table: "PCLMatchPlayer",
                column: "PreTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PCLMatchPlayer_UserId",
                table: "PCLMatchPlayer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PCLMatchRound_PCLMatchId",
                table: "PCLMatchRound",
                column: "PCLMatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PCLMatchPlayer");

            migrationBuilder.DropTable(
                name: "PCLMatchRound");
        }
    }
}
