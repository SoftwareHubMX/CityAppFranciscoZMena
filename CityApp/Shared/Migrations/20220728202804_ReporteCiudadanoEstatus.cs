using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class ReporteCiudadanoEstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportesCiudadanos_EstadosReporteCiudadano_IdEstadoReporteCiudadano",
                table: "ReportesCiudadanos");

            migrationBuilder.DropTable(
                name: "EstadosReporteCiudadano");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstadoReporteCiudadano",
                table: "ReportesCiudadanos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdEstatusReporteCiudadano",
                table: "ReportesCiudadanos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstatusReporteCiudadano",
                columns: table => new
                {
                    IdEstatusReporteCiudadano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusReporteCiudadano", x => x.IdEstatusReporteCiudadano);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ReportesCiudadanos_EstatusReporteCiudadano_IdEstadoReporteCiudadano",
                table: "ReportesCiudadanos",
                column: "IdEstadoReporteCiudadano",
                principalTable: "EstatusReporteCiudadano",
                principalColumn: "IdEstatusReporteCiudadano");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportesCiudadanos_EstatusReporteCiudadano_IdEstadoReporteCiudadano",
                table: "ReportesCiudadanos");

            migrationBuilder.DropTable(
                name: "EstatusReporteCiudadano");

            migrationBuilder.DropColumn(
                name: "IdEstatusReporteCiudadano",
                table: "ReportesCiudadanos");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstadoReporteCiudadano",
                table: "ReportesCiudadanos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EstadosReporteCiudadano",
                columns: table => new
                {
                    IdEstadoReporteCiudadano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosReporteCiudadano", x => x.IdEstadoReporteCiudadano);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ReportesCiudadanos_EstadosReporteCiudadano_IdEstadoReporteCiudadano",
                table: "ReportesCiudadanos",
                column: "IdEstadoReporteCiudadano",
                principalTable: "EstadosReporteCiudadano",
                principalColumn: "IdEstadoReporteCiudadano",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
