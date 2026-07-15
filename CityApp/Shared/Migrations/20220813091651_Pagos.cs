using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class Pagos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstatusPago",
                columns: table => new
                {
                    IdEstatusPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusPago", x => x.IdEstatusPago);
                });

            migrationBuilder.CreateTable(
                name: "TiposPago",
                columns: table => new
                {
                    IdTipoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pago = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPago", x => x.IdTipoPago);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identificador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    IdTipoPago = table.Column<int>(type: "int", nullable: false),
                    IdCuenta = table.Column<int>(type: "int", nullable: false),
                    IdEstatusPago = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pagos_Cuentas_IdCuenta",
                        column: x => x.IdCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "IdCuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_EstatusPago_IdEstatusPago",
                        column: x => x.IdEstatusPago,
                        principalTable: "EstatusPago",
                        principalColumn: "IdEstatusPago",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_TiposPago_IdTipoPago",
                        column: x => x.IdTipoPago,
                        principalTable: "TiposPago",
                        principalColumn: "IdTipoPago",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdCuenta",
                table: "Pagos",
                column: "IdCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdEstatusPago",
                table: "Pagos",
                column: "IdEstatusPago");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdTipoPago",
                table: "Pagos",
                column: "IdTipoPago");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "EstatusPago");

            migrationBuilder.DropTable(
                name: "TiposPago");
        }
    }
}
