using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class noticiasv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    IdNoticia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fuente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.IdNoticia);
                });

            migrationBuilder.CreateTable(
                name: "ArchivosNoticia",
                columns: table => new
                {
                    IdArchivoNoticia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    IdNoticia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosNoticia", x => x.IdArchivoNoticia);
                    table.ForeignKey(
                        name: "FK_ArchivosNoticia_Noticias_IdNoticia",
                        column: x => x.IdNoticia,
                        principalTable: "Noticias",
                        principalColumn: "IdNoticia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosNoticia_IdNoticia",
                table: "ArchivosNoticia",
                column: "IdNoticia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivosNoticia");

            migrationBuilder.DropTable(
                name: "Noticias");
        }
    }
}
