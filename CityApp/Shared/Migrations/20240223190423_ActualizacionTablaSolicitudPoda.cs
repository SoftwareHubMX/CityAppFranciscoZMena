using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class ActualizacionTablaSolicitudPoda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolicitudesPoda",
                columns: table => new
                {
                    IdSolicitudPoda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroArboles = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referencias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latidud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    IdSolicitante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesPoda", x => x.IdSolicitudPoda);
                    table.ForeignKey(
                        name: "FK_SolicitudesPoda_Solicitantes_IdSolicitante",
                        column: x => x.IdSolicitante,
                        principalTable: "Solicitantes",
                        principalColumn: "IdSolicitante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesTipoJustificaciones",
                columns: table => new
                {
                    IdSolicitudTipoJustificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoJustificacionSolicitud = table.Column<int>(type: "int", nullable: false),
                    IdSolicitudPoda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesTipoJustificaciones", x => x.IdSolicitudTipoJustificacion);
                    table.ForeignKey(
                        name: "FK_SolicitudesTipoJustificaciones_SolicitudesPoda_IdSolicitudPoda",
                        column: x => x.IdSolicitudPoda,
                        principalTable: "SolicitudesPoda",
                        principalColumn: "IdSolicitudPoda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudesTipoJustificaciones_TiposJustificacionSolicitud_IdTipoJustificacionSolicitud",
                        column: x => x.IdTipoJustificacionSolicitud,
                        principalTable: "TiposJustificacionSolicitud",
                        principalColumn: "IdTipoJustificacionSolicitud",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesPoda_IdSolicitante",
                table: "SolicitudesPoda",
                column: "IdSolicitante");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesTipoJustificaciones_IdSolicitudPoda",
                table: "SolicitudesTipoJustificaciones",
                column: "IdSolicitudPoda");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesTipoJustificaciones_IdTipoJustificacionSolicitud",
                table: "SolicitudesTipoJustificaciones",
                column: "IdTipoJustificacionSolicitud");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitudesTipoJustificaciones");

            migrationBuilder.DropTable(
                name: "SolicitudesPoda");
        }
    }
}
