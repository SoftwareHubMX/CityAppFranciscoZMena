using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class Agenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    IdAgenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnlaceWeb = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.IdAgenda);
                });

            migrationBuilder.CreateTable(
                name: "ArchivosAgenda",
                columns: table => new
                {
                    IdArchivoAgenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    IdAgenda = table.Column<int>(type: "int", nullable: false),
                    IdNoticia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosAgenda", x => x.IdArchivoAgenda);
                    table.ForeignKey(
                        name: "FK_ArchivosAgenda_Agendas_IdNoticia",
                        column: x => x.IdNoticia,
                        principalTable: "Agendas",
                        principalColumn: "IdAgenda");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosAgenda_IdNoticia",
                table: "ArchivosAgenda",
                column: "IdNoticia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivosAgenda");

            migrationBuilder.DropTable(
                name: "Agendas");
        }
    }
}
