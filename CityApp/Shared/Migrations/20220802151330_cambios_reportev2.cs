using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class cambios_reportev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reporte",
                table: "ReportesCiudadanos");

            migrationBuilder.AddColumn<int>(
                name: "IdTipoReporteCiudadano",
                table: "ReportesCiudadanos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TiposReporteCiudadano",
                columns: table => new
                {
                    IdTipoReporteCiudadano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoReporte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposReporteCiudadano", x => x.IdTipoReporteCiudadano);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportesCiudadanos_IdTipoReporteCiudadano",
                table: "ReportesCiudadanos",
                column: "IdTipoReporteCiudadano");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportesCiudadanos_TiposReporteCiudadano_IdTipoReporteCiudadano",
                table: "ReportesCiudadanos",
                column: "IdTipoReporteCiudadano",
                principalTable: "TiposReporteCiudadano",
                principalColumn: "IdTipoReporteCiudadano",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportesCiudadanos_TiposReporteCiudadano_IdTipoReporteCiudadano",
                table: "ReportesCiudadanos");

            migrationBuilder.DropTable(
                name: "TiposReporteCiudadano");

            migrationBuilder.DropIndex(
                name: "IX_ReportesCiudadanos_IdTipoReporteCiudadano",
                table: "ReportesCiudadanos");

            migrationBuilder.DropColumn(
                name: "IdTipoReporteCiudadano",
                table: "ReportesCiudadanos");

            migrationBuilder.AddColumn<string>(
                name: "Reporte",
                table: "ReportesCiudadanos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
