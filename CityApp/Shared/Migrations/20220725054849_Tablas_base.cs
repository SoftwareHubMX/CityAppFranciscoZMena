using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class Tablas_base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Curp",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EstatusCuentas",
                columns: table => new
                {
                    IdEstatusCuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorreoVerificado = table.Column<bool>(type: "bit", nullable: false),
                    PerfilCompleto = table.Column<bool>(type: "bit", nullable: false),
                    IdCuenta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusCuentas", x => x.IdEstatusCuenta);
                    table.ForeignKey(
                        name: "FK_EstatusCuentas_Cuentas_IdCuenta",
                        column: x => x.IdCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "IdCuenta");
                });

            migrationBuilder.CreateTable(
                name: "TokensActualizarPassword",
                columns: table => new
                {
                    IdTokenActualizarPassword = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCuenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokensActualizarPassword", x => x.IdTokenActualizarPassword);
                });

            migrationBuilder.CreateTable(
                name: "TokensContadorAcceso",
                columns: table => new
                {
                    IdTokenContadorAccesos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCuenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokensContadorAcceso", x => x.IdTokenContadorAccesos);
                });

            migrationBuilder.CreateTable(
                name: "TokensVerificacionCorreo",
                columns: table => new
                {
                    IdTokenVerificacionCorreo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCuenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokensVerificacionCorreo", x => x.IdTokenVerificacionCorreo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstatusCuentas_IdCuenta",
                table: "EstatusCuentas",
                column: "IdCuenta",
                unique: true,
                filter: "[IdCuenta] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstatusCuentas");

            migrationBuilder.DropTable(
                name: "TokensActualizarPassword");

            migrationBuilder.DropTable(
                name: "TokensContadorAcceso");

            migrationBuilder.DropTable(
                name: "TokensVerificacionCorreo");

            migrationBuilder.DropColumn(
                name: "Curp",
                table: "Usuarios");
        }
    }
}
