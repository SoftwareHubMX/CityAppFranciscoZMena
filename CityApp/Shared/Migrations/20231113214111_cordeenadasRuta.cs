using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class cordeenadasRuta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CordeenadasRuta",
                columns: table => new
                {
                    IdCordeenadaRuta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    IdRutaRecoleccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CordeenadasRuta", x => x.IdCordeenadaRuta);
                    table.ForeignKey(
                        name: "FK_CordeenadasRuta_RutasRecoleccion_IdRutaRecoleccion",
                        column: x => x.IdRutaRecoleccion,
                        principalTable: "RutasRecoleccion",
                        principalColumn: "IdRutaRecoleccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CordeenadasRuta_IdRutaRecoleccion",
                table: "CordeenadasRuta",
                column: "IdRutaRecoleccion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CordeenadasRuta");
        }
    }
}
