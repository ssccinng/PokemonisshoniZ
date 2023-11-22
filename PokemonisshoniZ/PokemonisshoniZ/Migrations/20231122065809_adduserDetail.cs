using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonisshoniZ.Migrations
{
    /// <inheritdoc />
    public partial class adduserDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                comment: "头像")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                comment: "城市")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "生日");

            migrationBuilder.AddColumn<int>(
                name: "GSNum",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "GS号");

            migrationBuilder.AddColumn<string>(
                name: "HomeName",
                table: "AspNetUsers",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                comment: "游戏名")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "AspNetUsers",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                comment: "昵称")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "QQ",
                table: "AspNetUsers",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                comment: "QQ号")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "Registertime",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "注册时间");

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "训练家id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GSNum",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HomeName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "QQ",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Registertime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "AspNetUsers");
        }
    }
}
