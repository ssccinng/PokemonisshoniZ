using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonisshoniZ.Migrations
{
    /// <inheritdoc />
    public partial class addTeamName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PokeTeams",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeamType",
                table: "PokeTeams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "PokeTeams");

            migrationBuilder.DropColumn(
                name: "TeamType",
                table: "PokeTeams");
        }
    }
}
