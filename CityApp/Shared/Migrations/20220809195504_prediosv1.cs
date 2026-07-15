using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class prediosv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Predios",
                columns: table => new
                {
                    IdPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaveCatastral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Atrasado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predios", x => x.IdPredio);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosPredio",
                columns: table => new
                {
                    IdServicioPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Servicio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosPredio", x => x.IdServicioPredio);
                });

            migrationBuilder.CreateTable(
                name: "DomiciliosPredio",
                columns: table => new
                {
                    IdDomicilioPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Letra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poblacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPredio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomiciliosPredio", x => x.IdDomicilioPredio);
                    table.ForeignKey(
                        name: "FK_DomiciliosPredio_Predios_IdPredio",
                        column: x => x.IdPredio,
                        principalTable: "Predios",
                        principalColumn: "IdPredio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagosPredio",
                columns: table => new
                {
                    IdPagoPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PredioId = table.Column<int>(type: "int", nullable: false),
                    FehcaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valuado = table.Column<double>(type: "float", nullable: false),
                    Rezago = table.Column<double>(type: "float", nullable: false),
                    Recargo = table.Column<double>(type: "float", nullable: false),
                    Normal = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Anotaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPredio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosPredio", x => x.IdPagoPredio);
                    table.ForeignKey(
                        name: "FK_PagosPredio_Predios_IdPredio",
                        column: x => x.IdPredio,
                        principalTable: "Predios",
                        principalColumn: "IdPredio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropietariosPredio",
                columns: table => new
                {
                    IdPropietarioPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCuenta = table.Column<int>(type: "int", nullable: false),
                    IdPredio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropietariosPredio", x => x.IdPropietarioPredio);
                    table.ForeignKey(
                        name: "FK_PropietariosPredio_Predios_IdPredio",
                        column: x => x.IdPredio,
                        principalTable: "Predios",
                        principalColumn: "IdPredio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformacionDomicilioPredio",
                columns: table => new
                {
                    IdInformacionDomicilioPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZonaEconomica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoConstruccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsoConstruccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaConstruccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalidadConstruccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MtsFrente = table.Column<double>(type: "float", nullable: false),
                    MtsFondo = table.Column<double>(type: "float", nullable: false),
                    MtsArea = table.Column<double>(type: "float", nullable: false),
                    MtsConstruccion = table.Column<double>(type: "float", nullable: false),
                    ValorComercial = table.Column<double>(type: "float", nullable: false),
                    IdDomicilioPredio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionDomicilioPredio", x => x.IdInformacionDomicilioPredio);
                    table.ForeignKey(
                        name: "FK_InformacionDomicilioPredio_DomiciliosPredio_IdDomicilioPredio",
                        column: x => x.IdDomicilioPredio,
                        principalTable: "DomiciliosPredio",
                        principalColumn: "IdDomicilioPredio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosDomicilioPredio",
                columns: table => new
                {
                    IdServicioDomicilioPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdServicioPredio = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<double>(type: "float", nullable: false),
                    IdDomicilioPredio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosDomicilioPredio", x => x.IdServicioDomicilioPredio);
                    table.ForeignKey(
                        name: "FK_ServiciosDomicilioPredio_DomiciliosPredio_IdDomicilioPredio",
                        column: x => x.IdDomicilioPredio,
                        principalTable: "DomiciliosPredio",
                        principalColumn: "IdDomicilioPredio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiciosDomicilioPredio_ServiciosPredio_IdServicioPredio",
                        column: x => x.IdServicioPredio,
                        principalTable: "ServiciosPredio",
                        principalColumn: "IdServicioPredio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DireccionesPropietarioPredio",
                columns: table => new
                {
                    IdDireccionPropietarioPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Letra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poblacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPropietarioPredio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DireccionesPropietarioPredio", x => x.IdDireccionPropietarioPredio);
                    table.ForeignKey(
                        name: "FK_DireccionesPropietarioPredio_PropietariosPredio_IdPropietarioPredio",
                        column: x => x.IdPropietarioPredio,
                        principalTable: "PropietariosPredio",
                        principalColumn: "IdPropietarioPredio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValoresCatastralesPredio",
                columns: table => new
                {
                    IdValorCatastralPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    FechaValorCatastral = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdInformacionDomicilioPredio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValoresCatastralesPredio", x => x.IdValorCatastralPredio);
                    table.ForeignKey(
                        name: "FK_ValoresCatastralesPredio_InformacionDomicilioPredio_IdInformacionDomicilioPredio",
                        column: x => x.IdInformacionDomicilioPredio,
                        principalTable: "InformacionDomicilioPredio",
                        principalColumn: "IdInformacionDomicilioPredio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValoresFiscalesPredio",
                columns: table => new
                {
                    IdValorFiscalPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    FechaValorFiscal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdInformacionDomicilioPredio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValoresFiscalesPredio", x => x.IdValorFiscalPredio);
                    table.ForeignKey(
                        name: "FK_ValoresFiscalesPredio_InformacionDomicilioPredio_IdInformacionDomicilioPredio",
                        column: x => x.IdInformacionDomicilioPredio,
                        principalTable: "InformacionDomicilioPredio",
                        principalColumn: "IdInformacionDomicilioPredio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DireccionesPropietarioPredio_IdPropietarioPredio",
                table: "DireccionesPropietarioPredio",
                column: "IdPropietarioPredio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DomiciliosPredio_IdPredio",
                table: "DomiciliosPredio",
                column: "IdPredio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformacionDomicilioPredio_IdDomicilioPredio",
                table: "InformacionDomicilioPredio",
                column: "IdDomicilioPredio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PagosPredio_IdPredio",
                table: "PagosPredio",
                column: "IdPredio");

            migrationBuilder.CreateIndex(
                name: "IX_PropietariosPredio_IdPredio",
                table: "PropietariosPredio",
                column: "IdPredio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosDomicilioPredio_IdDomicilioPredio",
                table: "ServiciosDomicilioPredio",
                column: "IdDomicilioPredio");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosDomicilioPredio_IdServicioPredio",
                table: "ServiciosDomicilioPredio",
                column: "IdServicioPredio");

            migrationBuilder.CreateIndex(
                name: "IX_ValoresCatastralesPredio_IdInformacionDomicilioPredio",
                table: "ValoresCatastralesPredio",
                column: "IdInformacionDomicilioPredio");

            migrationBuilder.CreateIndex(
                name: "IX_ValoresFiscalesPredio_IdInformacionDomicilioPredio",
                table: "ValoresFiscalesPredio",
                column: "IdInformacionDomicilioPredio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DireccionesPropietarioPredio");

            migrationBuilder.DropTable(
                name: "PagosPredio");

            migrationBuilder.DropTable(
                name: "ServiciosDomicilioPredio");

            migrationBuilder.DropTable(
                name: "ValoresCatastralesPredio");

            migrationBuilder.DropTable(
                name: "ValoresFiscalesPredio");

            migrationBuilder.DropTable(
                name: "PropietariosPredio");

            migrationBuilder.DropTable(
                name: "ServiciosPredio");

            migrationBuilder.DropTable(
                name: "InformacionDomicilioPredio");

            migrationBuilder.DropTable(
                name: "DomiciliosPredio");

            migrationBuilder.DropTable(
                name: "Predios");
        }
    }
}
