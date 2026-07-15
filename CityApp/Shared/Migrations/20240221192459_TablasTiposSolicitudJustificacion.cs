using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class TablasTiposSolicitudJustificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposJustificacionSolicitud",
                columns: table => new
                {
                    IdTipoJustificacionSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposJustificacionSolicitud", x => x.IdTipoJustificacionSolicitud);
                });

            migrationBuilder.CreateTable(
                name: "TiposSolicitud",
                columns: table => new
                {
                    IdTipoSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSolicitud", x => x.IdTipoSolicitud);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposJustificacionSolicitud");

            migrationBuilder.DropTable(
                name: "TiposSolicitud");
        }
    }
}
