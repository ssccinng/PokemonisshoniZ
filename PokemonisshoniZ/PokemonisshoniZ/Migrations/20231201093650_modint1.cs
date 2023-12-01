using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonisshoniZ.Migrations
{
    /// <inheritdoc />
    public partial class modint1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "PCLPokemons",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PCLPokemons",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PCLPokemons_UserId",
                table: "PCLPokemons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PCLPokemons_AspNetUsers_UserId",
                table: "PCLPokemons",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCLPokemons_AspNetUsers_UserId",
                table: "PCLPokemons");

            migrationBuilder.DropIndex(
                name: "IX_PCLPokemons_UserId",
                table: "PCLPokemons");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "PCLPokemons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PCLPokemons");
        }
    }
}
