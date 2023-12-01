using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonisshoniZ.Migrations
{
    /// <inheritdoc />
    public partial class addremark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "PokeTeams",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "PokeTeams");
        }
    }
}
