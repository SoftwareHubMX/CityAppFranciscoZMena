using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class ActualizacionBolsaTrabajo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condiciones",
                columns: table => new
                {
                    IdCondicion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCondicion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condiciones", x => x.IdCondicion);
                });

            migrationBuilder.CreateTable(
                name: "Discapacidades",
                columns: table => new
                {
                    IdDicapacidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDiscapacidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discapacidades", x => x.IdDicapacidad);
                });

            migrationBuilder.CreateTable(
                name: "Escolaridades",
                columns: table => new
                {
                    IdEscolaridad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEscolaridad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolaridades", x => x.IdEscolaridad);
                });

            migrationBuilder.CreateTable(
                name: "Giros",
                columns: table => new
                {
                    IdGiro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoGiro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giros", x => x.IdGiro);
                });

            //migrationBuilder.CreateTable(
            //    name: "StatusBolsas",
            //    columns: table => new
            //    {
            //        IdStatusBolsa = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        StatusBolsaTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StatusBolsas", x => x.IdStatusBolsa);
            //    });

            migrationBuilder.CreateTable(
                name: "BolsasTrabajos",
                columns: table => new
                {
                    IdBolsaTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Puesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Escolaridad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experiencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conocimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habilidades = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Funciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jornada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sueldo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prestaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtrasPrestaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requisitos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Entrevisata = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActividadPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rfc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plaza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdGiro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolsasTrabajos", x => x.IdBolsaTrabajo);
                    table.ForeignKey(
                        name: "FK_BolsasTrabajos_Giros_IdGiro",
                        column: x => x.IdGiro,
                        principalTable: "Giros",
                        principalColumn: "IdGiro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Postulaciones",
                columns: table => new
                {
                    IdPostulacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Folio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombrePostulante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PuestoRequerido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienciaPuesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienciaLaboral1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienciaLaboral2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienciaLaboral3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idioma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PorcentajeIdioma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEscolaridad = table.Column<int>(type: "int", nullable: false),
                    IdDiscapacidad = table.Column<int>(type: "int", nullable: false),
                    IdCondicion = table.Column<int>(type: "int", nullable: false),
                    IdBolsaTrabajo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postulaciones", x => x.IdPostulacion);
                    table.ForeignKey(
                        name: "FK_Postulaciones_BolsasTrabajos_IdBolsaTrabajo",
                        column: x => x.IdBolsaTrabajo,
                        principalTable: "BolsasTrabajos",
                        principalColumn: "IdBolsaTrabajo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postulaciones_Condiciones_IdCondicion",
                        column: x => x.IdCondicion,
                        principalTable: "Condiciones",
                        principalColumn: "IdCondicion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postulaciones_Discapacidades_IdDiscapacidad",
                        column: x => x.IdDiscapacidad,
                        principalTable: "Discapacidades",
                        principalColumn: "IdDicapacidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postulaciones_Escolaridades_IdEscolaridad",
                        column: x => x.IdEscolaridad,
                        principalTable: "Escolaridades",
                        principalColumn: "IdEscolaridad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BolsasTrabajos_IdGiro",
                table: "BolsasTrabajos",
                column: "IdGiro");

            migrationBuilder.CreateIndex(
                name: "IX_Postulaciones_IdBolsaTrabajo",
                table: "Postulaciones",
                column: "IdBolsaTrabajo");

            migrationBuilder.CreateIndex(
                name: "IX_Postulaciones_IdCondicion",
                table: "Postulaciones",
                column: "IdCondicion");

            migrationBuilder.CreateIndex(
                name: "IX_Postulaciones_IdDiscapacidad",
                table: "Postulaciones",
                column: "IdDiscapacidad");

            migrationBuilder.CreateIndex(
                name: "IX_Postulaciones_IdEscolaridad",
                table: "Postulaciones",
                column: "IdEscolaridad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Postulaciones");

            //migrationBuilder.DropTable(
            //    name: "StatusBolsas");

            migrationBuilder.DropTable(
                name: "BolsasTrabajos");

            migrationBuilder.DropTable(
                name: "Condiciones");

            migrationBuilder.DropTable(
                name: "Discapacidades");

            migrationBuilder.DropTable(
                name: "Escolaridades");

            migrationBuilder.DropTable(
                name: "Giros");
        }
    }
}
