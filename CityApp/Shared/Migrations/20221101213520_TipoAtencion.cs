using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class TipoAtencion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposAtencionesContacto",
                columns: table => new
                {
                    IdTipoAtencionContacto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAtencion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAtencionesContacto", x => x.IdTipoAtencionContacto);
                });

            migrationBuilder.CreateTable(
                name: "ContactosSeguridadPublica",
                columns: table => new
                {
                    IdContactoSeguridadPublica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoAtencionContacto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactosSeguridadPublica", x => x.IdContactoSeguridadPublica);
                    table.ForeignKey(
                        name: "FK_ContactosSeguridadPublica_TiposAtencionesContacto_IdTipoAtencionContacto",
                        column: x => x.IdTipoAtencionContacto,
                        principalTable: "TiposAtencionesContacto",
                        principalColumn: "IdTipoAtencionContacto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactosSeguridadPublica_IdTipoAtencionContacto",
                table: "ContactosSeguridadPublica",
                column: "IdTipoAtencionContacto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactosSeguridadPublica");

            migrationBuilder.DropTable(
                name: "TiposAtencionesContacto");
        }
    }
}
