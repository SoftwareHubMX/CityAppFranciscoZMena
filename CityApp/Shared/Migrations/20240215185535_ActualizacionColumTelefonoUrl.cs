using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class ActualizacionColumTelefonoUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "LugaresTuristicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UrlWebFacebook",
                table: "LugaresTuristicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "LugaresTuristicos");

            migrationBuilder.DropColumn(
                name: "UrlWebFacebook",
                table: "LugaresTuristicos");
        }
    }
}
