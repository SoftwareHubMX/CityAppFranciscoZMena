using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class PrediosvFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DireccionesPropietarioPredio");

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

            migrationBuilder.DropColumn(
                name: "Atrasado",
                table: "Predios");

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Predios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoPostal",
                table: "Predios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Predios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Predios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaUltimoPago",
                table: "Predios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Poblacion",
                table: "Predios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Propietario",
                table: "Predios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Resago",
                table: "Predios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Predios",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "DescuentosPredios",
                columns: table => new
                {
                    IdDescuentoPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TituloDescuento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearResago = table.Column<int>(type: "int", nullable: false),
                    PorsentajeMonto = table.Column<bool>(type: "bit", nullable: false),
                    Descuento = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescuentosPredios", x => x.IdDescuentoPredio);
                });

            migrationBuilder.CreateTable(
                name: "HistoricosPredios",
                columns: table => new
                {
                    IdHistoricoPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotaActualizacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaHistorico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCuenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosPredios", x => x.IdHistoricoPredio);
                    table.ForeignKey(
                        name: "FK_HistoricosPredios_Cuentas_IdCuenta",
                        column: x => x.IdCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "IdCuenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArchivoHistoricoPredio",
                columns: table => new
                {
                    IdArchivoHistoricoPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    IdHistoricoPredio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivoHistoricoPredio", x => x.IdArchivoHistoricoPredio);
                    table.ForeignKey(
                        name: "FK_ArchivoHistoricoPredio_HistoricosPredios_IdHistoricoPredio",
                        column: x => x.IdHistoricoPredio,
                        principalTable: "HistoricosPredios",
                        principalColumn: "IdHistoricoPredio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoHistoricoPredio_IdHistoricoPredio",
                table: "ArchivoHistoricoPredio",
                column: "IdHistoricoPredio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosPredios_IdCuenta",
                table: "HistoricosPredios",
                column: "IdCuenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivoHistoricoPredio");

            migrationBuilder.DropTable(
                name: "DescuentosPredios");

            migrationBuilder.DropTable(
                name: "HistoricosPredios");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Predios");

            migrationBuilder.DropColumn(
                name: "CodigoPostal",
                table: "Predios");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Predios");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Predios");

            migrationBuilder.DropColumn(
                name: "FechaUltimoPago",
                table: "Predios");

            migrationBuilder.DropColumn(
                name: "Poblacion",
                table: "Predios");

            migrationBuilder.DropColumn(
                name: "Propietario",
                table: "Predios");

            migrationBuilder.DropColumn(
                name: "Resago",
                table: "Predios");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Predios");

            migrationBuilder.AddColumn<bool>(
                name: "Atrasado",
                table: "Predios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DomiciliosPredio",
                columns: table => new
                {
                    IdDomicilioPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPredio = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Letra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Poblacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "PropietariosPredio",
                columns: table => new
                {
                    IdPropietarioPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPredio = table.Column<int>(type: "int", nullable: false),
                    IdCuenta = table.Column<int>(type: "int", nullable: false),
                    Propietario = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "InformacionDomicilioPredio",
                columns: table => new
                {
                    IdInformacionDomicilioPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDomicilioPredio = table.Column<int>(type: "int", nullable: false),
                    CalidadConstruccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaConstruccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MtsArea = table.Column<double>(type: "float", nullable: false),
                    MtsConstruccion = table.Column<double>(type: "float", nullable: false),
                    MtsFondo = table.Column<double>(type: "float", nullable: false),
                    MtsFrente = table.Column<double>(type: "float", nullable: false),
                    TipoConstruccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsoConstruccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorComercial = table.Column<double>(type: "float", nullable: false),
                    ZonaEconomica = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "DireccionesPropietarioPredio",
                columns: table => new
                {
                    IdDireccionPropietarioPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPropietarioPredio = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Letra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Poblacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "ServiciosDomicilioPredio",
                columns: table => new
                {
                    IdServicioDomicilioPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDomicilioPredio = table.Column<int>(type: "int", nullable: false),
                    IdServicioPredio = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<double>(type: "float", nullable: false)
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
                name: "ValoresCatastralesPredio",
                columns: table => new
                {
                    IdValorCatastralPredio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInformacionDomicilioPredio = table.Column<int>(type: "int", nullable: false),
                    FechaValorCatastral = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
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
                    IdInformacionDomicilioPredio = table.Column<int>(type: "int", nullable: false),
                    FechaValorFiscal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
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
    }
}
