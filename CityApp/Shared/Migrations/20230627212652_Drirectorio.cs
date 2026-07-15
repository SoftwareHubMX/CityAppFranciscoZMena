using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class Drirectorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directorios",
                columns: table => new
                {
                    IdDirectorio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDirecctorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetodoContacto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directorios", x => x.IdDirectorio);
                });

            migrationBuilder.CreateTable(
                name: "ArchivosDirectorio",
                columns: table => new
                {
                    IdArchivoDirectorio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    IdDirectorio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosDirectorio", x => x.IdArchivoDirectorio);
                    table.ForeignKey(
                        name: "FK_ArchivosDirectorio_Directorios_IdDirectorio",
                        column: x => x.IdDirectorio,
                        principalTable: "Directorios",
                        principalColumn: "IdDirectorio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosDirectorio_IdDirectorio",
                table: "ArchivosDirectorio",
                column: "IdDirectorio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivosDirectorio");

            migrationBuilder.DropTable(
                name: "Directorios");
        }
    }
}
