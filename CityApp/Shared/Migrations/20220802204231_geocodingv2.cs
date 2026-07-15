using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class geocodingv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportesCiudadanos_EstatusReporteCiudadano_IdEstadoReporteCiudadano",
                table: "ReportesCiudadanos");

            migrationBuilder.DropIndex(
                name: "IX_ReportesCiudadanos_IdEstadoReporteCiudadano",
                table: "ReportesCiudadanos");

            migrationBuilder.DropColumn(
                name: "IdEstadoReporteCiudadano",
                table: "ReportesCiudadanos");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesCiudadanos_IdEstatusReporteCiudadano",
                table: "ReportesCiudadanos",
                column: "IdEstatusReporteCiudadano");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportesCiudadanos_EstatusReporteCiudadano_IdEstatusReporteCiudadano",
                table: "ReportesCiudadanos",
                column: "IdEstatusReporteCiudadano",
                principalTable: "EstatusReporteCiudadano",
                principalColumn: "IdEstatusReporteCiudadano",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportesCiudadanos_EstatusReporteCiudadano_IdEstatusReporteCiudadano",
                table: "ReportesCiudadanos");

            migrationBuilder.DropIndex(
                name: "IX_ReportesCiudadanos_IdEstatusReporteCiudadano",
                table: "ReportesCiudadanos");

            migrationBuilder.AddColumn<int>(
                name: "IdEstadoReporteCiudadano",
                table: "ReportesCiudadanos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportesCiudadanos_IdEstadoReporteCiudadano",
                table: "ReportesCiudadanos",
                column: "IdEstadoReporteCiudadano");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportesCiudadanos_EstatusReporteCiudadano_IdEstadoReporteCiudadano",
                table: "ReportesCiudadanos",
                column: "IdEstadoReporteCiudadano",
                principalTable: "EstatusReporteCiudadano",
                principalColumn: "IdEstatusReporteCiudadano");
        }
    }
}
