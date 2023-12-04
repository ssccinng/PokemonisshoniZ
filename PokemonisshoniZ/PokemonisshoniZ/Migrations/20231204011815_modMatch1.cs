using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonisshoniZ.Migrations
{
    /// <inheritdoc />
    public partial class modMatch1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "PCLMatches");

            migrationBuilder.RenameColumn(
                name: "IsTeamCompeition",
                table: "PCLMatches",
                newName: "NeedCheck");

            migrationBuilder.AddColumn<int>(
                name: "MatchMode",
                table: "PCLMatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchOnline",
                table: "PCLMatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "PCLMatches",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "RoundIdx",
                table: "PCLMatches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchMode",
                table: "PCLMatches");

            migrationBuilder.DropColumn(
                name: "MatchOnline",
                table: "PCLMatches");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "PCLMatches");

            migrationBuilder.DropColumn(
                name: "RoundIdx",
                table: "PCLMatches");

            migrationBuilder.RenameColumn(
                name: "NeedCheck",
                table: "PCLMatches",
                newName: "IsTeamCompeition");

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "PCLMatches",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
