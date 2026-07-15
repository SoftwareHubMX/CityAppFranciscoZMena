using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class Sliders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposSliders",
                columns: table => new
                {
                    IdTipoSlider = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slider = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSliders", x => x.IdTipoSlider);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    IdSlider = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoSlider = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.IdSlider);
                    table.ForeignKey(
                        name: "FK_Sliders_TiposSliders_IdTipoSlider",
                        column: x => x.IdTipoSlider,
                        principalTable: "TiposSliders",
                        principalColumn: "IdTipoSlider",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchivosSlider",
                columns: table => new
                {
                    IdArchivoSlider = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    IdSlider = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosSlider", x => x.IdArchivoSlider);
                    table.ForeignKey(
                        name: "FK_ArchivosSlider_Sliders_IdSlider",
                        column: x => x.IdSlider,
                        principalTable: "Sliders",
                        principalColumn: "IdSlider",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosSlider_IdSlider",
                table: "ArchivosSlider",
                column: "IdSlider");

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_IdTipoSlider",
                table: "Sliders",
                column: "IdTipoSlider");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivosSlider");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "TiposSliders");
        }
    }
}
