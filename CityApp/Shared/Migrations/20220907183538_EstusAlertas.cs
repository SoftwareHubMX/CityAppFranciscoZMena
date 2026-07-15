using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class EstusAlertas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstatusAlertas",
                columns: table => new
                {
                    IdEstatusAlerta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusAlertas", x => x.IdEstatusAlerta);
                });

            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    IdAlerta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAlerta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCuenta = table.Column<int>(type: "int", nullable: false),
                    IdEstatusAlerta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.IdAlerta);
                    table.ForeignKey(
                        name: "FK_Alertas_Cuentas_IdCuenta",
                        column: x => x.IdCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "IdCuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alertas_EstatusAlertas_IdEstatusAlerta",
                        column: x => x.IdEstatusAlerta,
                        principalTable: "EstatusAlertas",
                        principalColumn: "IdEstatusAlerta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DireccionesAlertas",
                columns: table => new
                {
                    IdDireccionAlerta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    IdAlerta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DireccionesAlertas", x => x.IdDireccionAlerta);
                    table.ForeignKey(
                        name: "FK_DireccionesAlertas_Alertas_IdAlerta",
                        column: x => x.IdAlerta,
                        principalTable: "Alertas",
                        principalColumn: "IdAlerta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_IdCuenta",
                table: "Alertas",
                column: "IdCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_IdEstatusAlerta",
                table: "Alertas",
                column: "IdEstatusAlerta");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionesAlertas_IdAlerta",
                table: "DireccionesAlertas",
                column: "IdAlerta",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DireccionesAlertas");

            migrationBuilder.DropTable(
                name: "Alertas");

            migrationBuilder.DropTable(
                name: "EstatusAlertas");
        }
    }
}
