using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class prediosv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "PropietariosPredio");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "PropietariosPredio",
                newName: "Propietario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Propietario",
                table: "PropietariosPredio",
                newName: "Nombre");

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "PropietariosPredio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
