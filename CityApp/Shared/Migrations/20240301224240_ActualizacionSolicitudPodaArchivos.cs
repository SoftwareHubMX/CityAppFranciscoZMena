using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class ActualizacionSolicitudPodaArchivos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArchivosSolicitidPoda",
                columns: table => new
                {
                    IdArchivoSolicitudPoda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    IdSolicitudPoda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosSolicitidPoda", x => x.IdArchivoSolicitudPoda);
                    table.ForeignKey(
                        name: "FK_ArchivosSolicitidPoda_SolicitudesPoda_IdSolicitudPoda",
                        column: x => x.IdSolicitudPoda,
                        principalTable: "SolicitudesPoda",
                        principalColumn: "IdSolicitudPoda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosSolicitidPoda_IdSolicitudPoda",
                table: "ArchivosSolicitidPoda",
                column: "IdSolicitudPoda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivosSolicitidPoda");
        }
    }
}
