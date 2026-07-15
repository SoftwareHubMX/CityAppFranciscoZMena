using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class reportesCiudadanoRestrucV22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportesCiudadanos_Cuentas_CuentaIdCuenta",
                table: "ReportesCiudadanos");

            migrationBuilder.DropIndex(
                name: "IX_ReportesCiudadanos_CuentaIdCuenta",
                table: "ReportesCiudadanos");

            migrationBuilder.DropColumn(
                name: "CuentaIdCuenta",
                table: "ReportesCiudadanos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuentaIdCuenta",
                table: "ReportesCiudadanos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportesCiudadanos_CuentaIdCuenta",
                table: "ReportesCiudadanos",
                column: "CuentaIdCuenta");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportesCiudadanos_Cuentas_CuentaIdCuenta",
                table: "ReportesCiudadanos",
                column: "CuentaIdCuenta",
                principalTable: "Cuentas",
                principalColumn: "IdCuenta");
        }
    }
}
