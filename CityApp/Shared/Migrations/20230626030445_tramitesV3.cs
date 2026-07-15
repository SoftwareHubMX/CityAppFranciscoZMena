using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class tramitesV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Costo",
                table: "Tramites",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Latitud",
                table: "Tramites",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitud",
                table: "Tramites",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Requisitos",
                table: "Tramites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Tramites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Costo",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "Requisitos",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Tramites");
        }
    }
}
