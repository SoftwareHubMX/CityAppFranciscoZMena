using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class reportesCiudadanoRestrucV223 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPrimerReporte",
                table: "ReportesCiudadanos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaPrimerReporte",
                table: "ReportesCiudadanos");
        }
    }
}
