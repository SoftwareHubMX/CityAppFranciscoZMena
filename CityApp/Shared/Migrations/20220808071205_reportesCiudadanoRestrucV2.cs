using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class reportesCiudadanoRestrucV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DireccionesReporteCiudadano_ReportesCiudadanos_IdReporteCiudadano",
                table: "DireccionesReporteCiudadano");

            migrationBuilder.DropForeignKey(
                name: "FK_EvidenciasReporteCiudadano_ReportesCiudadanos_IdReporteCiudadano",
                table: "EvidenciasReporteCiudadano");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportesCiudadanos_Cuentas_IdCuenta",
                table: "ReportesCiudadanos");

            migrationBuilder.DropIndex(
                name: "IX_ReportesCiudadanos_IdCuenta",
                table: "ReportesCiudadanos");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "ReportesCiudadanos");

            migrationBuilder.DropColumn(
                name: "FechaReporte",
                table: "ReportesCiudadanos");

            migrationBuilder.DropColumn(
                name: "IdCuenta",
                table: "ReportesCiudadanos");

            migrationBuilder.RenameColumn(
                name: "IdReporteCiudadano",
                table: "EvidenciasReporteCiudadano",
                newName: "IdVercionReporteCiudadano");

            migrationBuilder.RenameIndex(
                name: "IX_EvidenciasReporteCiudadano_IdReporteCiudadano",
                table: "EvidenciasReporteCiudadano",
                newName: "IX_EvidenciasReporteCiudadano_IdVercionReporteCiudadano");

            migrationBuilder.RenameColumn(
                name: "IdReporteCiudadano",
                table: "DireccionesReporteCiudadano",
                newName: "IdVercionReporteCiudadano");

            migrationBuilder.RenameIndex(
                name: "IX_DireccionesReporteCiudadano_IdReporteCiudadano",
                table: "DireccionesReporteCiudadano",
                newName: "IX_DireccionesReporteCiudadano_IdVercionReporteCiudadano");

            migrationBuilder.AddColumn<int>(
                name: "CuentaIdCuenta",
                table: "ReportesCiudadanos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCuenta",
                table: "EvidenciasSolucionReporteCiudadano",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Longitud",
                table: "DireccionesReporteCiudadano",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Latitud",
                table: "DireccionesReporteCiudadano",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "VercionesReporteCiudadano",
                columns: table => new
                {
                    IdVercionReporteCiudadano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaReporte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdReporteCiudadano = table.Column<int>(type: "int", nullable: false),
                    IdCuenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VercionesReporteCiudadano", x => x.IdVercionReporteCiudadano);
                    table.ForeignKey(
                        name: "FK_VercionesReporteCiudadano_Cuentas_IdCuenta",
                        column: x => x.IdCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "IdCuenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VercionesReporteCiudadano_ReportesCiudadanos_IdReporteCiudadano",
                        column: x => x.IdReporteCiudadano,
                        principalTable: "ReportesCiudadanos",
                        principalColumn: "IdReporteCiudadano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportesCiudadanos_CuentaIdCuenta",
                table: "ReportesCiudadanos",
                column: "CuentaIdCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_EvidenciasSolucionReporteCiudadano_IdCuenta",
                table: "EvidenciasSolucionReporteCiudadano",
                column: "IdCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_VercionesReporteCiudadano_IdCuenta",
                table: "VercionesReporteCiudadano",
                column: "IdCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_VercionesReporteCiudadano_IdReporteCiudadano",
                table: "VercionesReporteCiudadano",
                column: "IdReporteCiudadano");

            migrationBuilder.AddForeignKey(
                name: "FK_DireccionesReporteCiudadano_VercionesReporteCiudadano_IdVercionReporteCiudadano",
                table: "DireccionesReporteCiudadano",
                column: "IdVercionReporteCiudadano",
                principalTable: "VercionesReporteCiudadano",
                principalColumn: "IdVercionReporteCiudadano",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvidenciasReporteCiudadano_VercionesReporteCiudadano_IdVercionReporteCiudadano",
                table: "EvidenciasReporteCiudadano",
                column: "IdVercionReporteCiudadano",
                principalTable: "VercionesReporteCiudadano",
                principalColumn: "IdVercionReporteCiudadano",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvidenciasSolucionReporteCiudadano_Cuentas_IdCuenta",
                table: "EvidenciasSolucionReporteCiudadano",
                column: "IdCuenta",
                principalTable: "Cuentas",
                principalColumn: "IdCuenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportesCiudadanos_Cuentas_CuentaIdCuenta",
                table: "ReportesCiudadanos",
                column: "CuentaIdCuenta",
                principalTable: "Cuentas",
                principalColumn: "IdCuenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DireccionesReporteCiudadano_VercionesReporteCiudadano_IdVercionReporteCiudadano",
                table: "DireccionesReporteCiudadano");

            migrationBuilder.DropForeignKey(
                name: "FK_EvidenciasReporteCiudadano_VercionesReporteCiudadano_IdVercionReporteCiudadano",
                table: "EvidenciasReporteCiudadano");

            migrationBuilder.DropForeignKey(
                name: "FK_EvidenciasSolucionReporteCiudadano_Cuentas_IdCuenta",
                table: "EvidenciasSolucionReporteCiudadano");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportesCiudadanos_Cuentas_CuentaIdCuenta",
                table: "ReportesCiudadanos");

            migrationBuilder.DropTable(
                name: "VercionesReporteCiudadano");

            migrationBuilder.DropIndex(
                name: "IX_ReportesCiudadanos_CuentaIdCuenta",
                table: "ReportesCiudadanos");

            migrationBuilder.DropIndex(
                name: "IX_EvidenciasSolucionReporteCiudadano_IdCuenta",
                table: "EvidenciasSolucionReporteCiudadano");

            migrationBuilder.DropColumn(
                name: "CuentaIdCuenta",
                table: "ReportesCiudadanos");

            migrationBuilder.DropColumn(
                name: "IdCuenta",
                table: "EvidenciasSolucionReporteCiudadano");

            migrationBuilder.RenameColumn(
                name: "IdVercionReporteCiudadano",
                table: "EvidenciasReporteCiudadano",
                newName: "IdReporteCiudadano");

            migrationBuilder.RenameIndex(
                name: "IX_EvidenciasReporteCiudadano_IdVercionReporteCiudadano",
                table: "EvidenciasReporteCiudadano",
                newName: "IX_EvidenciasReporteCiudadano_IdReporteCiudadano");

            migrationBuilder.RenameColumn(
                name: "IdVercionReporteCiudadano",
                table: "DireccionesReporteCiudadano",
                newName: "IdReporteCiudadano");

            migrationBuilder.RenameIndex(
                name: "IX_DireccionesReporteCiudadano_IdVercionReporteCiudadano",
                table: "DireccionesReporteCiudadano",
                newName: "IX_DireccionesReporteCiudadano_IdReporteCiudadano");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "ReportesCiudadanos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaReporte",
                table: "ReportesCiudadanos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdCuenta",
                table: "ReportesCiudadanos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Longitud",
                table: "DireccionesReporteCiudadano",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Latitud",
                table: "DireccionesReporteCiudadano",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_ReportesCiudadanos_IdCuenta",
                table: "ReportesCiudadanos",
                column: "IdCuenta");

            migrationBuilder.AddForeignKey(
                name: "FK_DireccionesReporteCiudadano_ReportesCiudadanos_IdReporteCiudadano",
                table: "DireccionesReporteCiudadano",
                column: "IdReporteCiudadano",
                principalTable: "ReportesCiudadanos",
                principalColumn: "IdReporteCiudadano",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EvidenciasReporteCiudadano_ReportesCiudadanos_IdReporteCiudadano",
                table: "EvidenciasReporteCiudadano",
                column: "IdReporteCiudadano",
                principalTable: "ReportesCiudadanos",
                principalColumn: "IdReporteCiudadano",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportesCiudadanos_Cuentas_IdCuenta",
                table: "ReportesCiudadanos",
                column: "IdCuenta",
                principalTable: "Cuentas",
                principalColumn: "IdCuenta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
