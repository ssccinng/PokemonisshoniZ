using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonisshoniZ.Migrations
{
    /// <inheritdoc />
    public partial class addMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PCLMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MatchStartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MatchEndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MatchStatus = table.Column<int>(type: "int", nullable: false),
                    MatchType = table.Column<int>(type: "int", nullable: false),
                    IsOnline = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    HasUsage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AllowGuest = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    IsTeamCompeition = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TeamNumberLimit = table.Column<int>(type: "int", nullable: false),
                    MaxPlayerNumber = table.Column<int>(type: "int", nullable: false),
                    NotShow = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ConcurrencyToken = table.Column<DateTime>(type: "timestamp(6)", rowVersion: true, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCLMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PCLMatches_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PCLMatches_UserId",
                table: "PCLMatches",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PCLMatches");
        }
    }
}
