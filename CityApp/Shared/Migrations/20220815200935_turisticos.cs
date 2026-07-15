using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class turisticos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LugaresTuristicos",
                columns: table => new
                {
                    IdLugarTuristico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugaresTuristicos", x => x.IdLugarTuristico);
                });

            migrationBuilder.CreateTable(
                name: "ArchivosLugaresTuristicos",
                columns: table => new
                {
                    IdArchivoLugarTuristico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    FechaArchivo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdLugarTuristico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosLugaresTuristicos", x => x.IdArchivoLugarTuristico);
                    table.ForeignKey(
                        name: "FK_ArchivosLugaresTuristicos_LugaresTuristicos_IdLugarTuristico",
                        column: x => x.IdLugarTuristico,
                        principalTable: "LugaresTuristicos",
                        principalColumn: "IdLugarTuristico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaracteristicasLugaresTuristicos",
                columns: table => new
                {
                    IdCaracteristicaLugarTuristico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCaracteristica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caracteristica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLugarTuristico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaracteristicasLugaresTuristicos", x => x.IdCaracteristicaLugarTuristico);
                    table.ForeignKey(
                        name: "FK_CaracteristicasLugaresTuristicos_LugaresTuristicos_IdLugarTuristico",
                        column: x => x.IdLugarTuristico,
                        principalTable: "LugaresTuristicos",
                        principalColumn: "IdLugarTuristico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DireccionesLugaresTuristicos",
                columns: table => new
                {
                    IdDireccionLugarTuristico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    IdLugarTuristico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DireccionesLugaresTuristicos", x => x.IdDireccionLugarTuristico);
                    table.ForeignKey(
                        name: "FK_DireccionesLugaresTuristicos_LugaresTuristicos_IdLugarTuristico",
                        column: x => x.IdLugarTuristico,
                        principalTable: "LugaresTuristicos",
                        principalColumn: "IdLugarTuristico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosLugaresTuristicos_IdLugarTuristico",
                table: "ArchivosLugaresTuristicos",
                column: "IdLugarTuristico");

            migrationBuilder.CreateIndex(
                name: "IX_CaracteristicasLugaresTuristicos_IdLugarTuristico",
                table: "CaracteristicasLugaresTuristicos",
                column: "IdLugarTuristico");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionesLugaresTuristicos_IdLugarTuristico",
                table: "DireccionesLugaresTuristicos",
                column: "IdLugarTuristico",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivosLugaresTuristicos");

            migrationBuilder.DropTable(
                name: "CaracteristicasLugaresTuristicos");

            migrationBuilder.DropTable(
                name: "DireccionesLugaresTuristicos");

            migrationBuilder.DropTable(
                name: "LugaresTuristicos");
        }
    }
}
