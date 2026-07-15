using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class ReporteCiudadano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "MantenerSesion",
                table: "TokensLogin",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EstadosReporteCiudadano",
                columns: table => new
                {
                    IdEstadoReporteCiudadano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosReporteCiudadano", x => x.IdEstadoReporteCiudadano);
                });

            migrationBuilder.CreateTable(
                name: "ReportesCiudadanos",
                columns: table => new
                {
                    IdReporteCiudadano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reporte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstadoReporteCiudadano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportesCiudadanos", x => x.IdReporteCiudadano);
                    table.ForeignKey(
                        name: "FK_ReportesCiudadanos_EstadosReporteCiudadano_IdEstadoReporteCiudadano",
                        column: x => x.IdEstadoReporteCiudadano,
                        principalTable: "EstadosReporteCiudadano",
                        principalColumn: "IdEstadoReporteCiudadano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DireccionesReporteCiudadano",
                columns: table => new
                {
                    IdDireccionReporteCiudadano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntreCalle1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntreCalle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitud = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdReporteCiudadano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DireccionesReporteCiudadano", x => x.IdDireccionReporteCiudadano);
                    table.ForeignKey(
                        name: "FK_DireccionesReporteCiudadano_ReportesCiudadanos_IdReporteCiudadano",
                        column: x => x.IdReporteCiudadano,
                        principalTable: "ReportesCiudadanos",
                        principalColumn: "IdReporteCiudadano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvidenciasReporteCiudadano",
                columns: table => new
                {
                    IdEnvidenciaReporteCiudadano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdReporteCiudadano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenciasReporteCiudadano", x => x.IdEnvidenciaReporteCiudadano);
                    table.ForeignKey(
                        name: "FK_EvidenciasReporteCiudadano_ReportesCiudadanos_IdReporteCiudadano",
                        column: x => x.IdReporteCiudadano,
                        principalTable: "ReportesCiudadanos",
                        principalColumn: "IdReporteCiudadano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DireccionesReporteCiudadano_IdReporteCiudadano",
                table: "DireccionesReporteCiudadano",
                column: "IdReporteCiudadano",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EvidenciasReporteCiudadano_IdReporteCiudadano",
                table: "EvidenciasReporteCiudadano",
                column: "IdReporteCiudadano");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesCiudadanos_IdEstadoReporteCiudadano",
                table: "ReportesCiudadanos",
                column: "IdEstadoReporteCiudadano");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DireccionesReporteCiudadano");

            migrationBuilder.DropTable(
                name: "EvidenciasReporteCiudadano");

            migrationBuilder.DropTable(
                name: "ReportesCiudadanos");

            migrationBuilder.DropTable(
                name: "EstadosReporteCiudadano");

            migrationBuilder.DropColumn(
                name: "MantenerSesion",
                table: "TokensLogin");
        }
    }
}
