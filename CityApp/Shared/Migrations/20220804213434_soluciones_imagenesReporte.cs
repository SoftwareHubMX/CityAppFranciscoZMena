using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class soluciones_imagenesReporte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvidenciasSolucionReporteCiudadano",
                columns: table => new
                {
                    IdEnvidenciaSolucionReporteCiudadano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdReporteCiudadano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenciasSolucionReporteCiudadano", x => x.IdEnvidenciaSolucionReporteCiudadano);
                    table.ForeignKey(
                        name: "FK_EvidenciasSolucionReporteCiudadano_ReportesCiudadanos_IdReporteCiudadano",
                        column: x => x.IdReporteCiudadano,
                        principalTable: "ReportesCiudadanos",
                        principalColumn: "IdReporteCiudadano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EvidenciasSolucionReporteCiudadano_IdReporteCiudadano",
                table: "EvidenciasSolucionReporteCiudadano",
                column: "IdReporteCiudadano");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvidenciasSolucionReporteCiudadano");
        }
    }
}
