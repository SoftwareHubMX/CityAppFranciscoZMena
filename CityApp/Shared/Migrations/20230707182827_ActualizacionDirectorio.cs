using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class ActualizacionDirectorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTipoDirectorio",
                table: "Directorios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Directorios_IdTipoDirectorio",
                table: "Directorios",
                column: "IdTipoDirectorio");

            migrationBuilder.AddForeignKey(
                name: "FK_Directorios_TiposDirectorio_IdTipoDirectorio",
                table: "Directorios",
                column: "IdTipoDirectorio",
                principalTable: "TiposDirectorio",
                principalColumn: "IdTipoDirectorio",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directorios_TiposDirectorio_IdTipoDirectorio",
                table: "Directorios");

            migrationBuilder.DropIndex(
                name: "IX_Directorios_IdTipoDirectorio",
                table: "Directorios");

            migrationBuilder.DropColumn(
                name: "IdTipoDirectorio",
                table: "Directorios");
        }
    }
}
