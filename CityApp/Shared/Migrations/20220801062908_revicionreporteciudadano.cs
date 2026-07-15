using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class revicionreporteciudadano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntreCalle1",
                table: "DireccionesReporteCiudadano");

            migrationBuilder.DropColumn(
                name: "EntreCalle2",
                table: "DireccionesReporteCiudadano");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaReporte",
                table: "ReportesCiudadanos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdCuenta",
                table: "ReportesCiudadanos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReportesCiudadanos_IdCuenta",
                table: "ReportesCiudadanos",
                column: "IdCuenta");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportesCiudadanos_Cuentas_IdCuenta",
                table: "ReportesCiudadanos",
                column: "IdCuenta",
                principalTable: "Cuentas",
                principalColumn: "IdCuenta",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportesCiudadanos_Cuentas_IdCuenta",
                table: "ReportesCiudadanos");

            migrationBuilder.DropIndex(
                name: "IX_ReportesCiudadanos_IdCuenta",
                table: "ReportesCiudadanos");

            migrationBuilder.DropColumn(
                name: "FechaReporte",
                table: "ReportesCiudadanos");

            migrationBuilder.DropColumn(
                name: "IdCuenta",
                table: "ReportesCiudadanos");

            migrationBuilder.AddColumn<string>(
                name: "EntreCalle1",
                table: "DireccionesReporteCiudadano",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EntreCalle2",
                table: "DireccionesReporteCiudadano",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
