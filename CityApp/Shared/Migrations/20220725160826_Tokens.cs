using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class Tokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstatusCuentas_Cuentas_IdCuenta",
                table: "EstatusCuentas");

            migrationBuilder.DropIndex(
                name: "IX_EstatusCuentas_IdCuenta",
                table: "EstatusCuentas");

            migrationBuilder.AlterColumn<int>(
                name: "IdCuenta",
                table: "EstatusCuentas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TiposTokenLogic",
                columns: table => new
                {
                    IdTipoTokenLogin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTokenLogic", x => x.IdTipoTokenLogin);
                });

            migrationBuilder.CreateTable(
                name: "TokensLogin",
                columns: table => new
                {
                    IdTokenLogin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAcceso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTipoTokenLogin = table.Column<int>(type: "int", nullable: false),
                    IdCuenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokensLogin", x => x.IdTokenLogin);
                    table.ForeignKey(
                        name: "FK_TokensLogin_TiposTokenLogic_IdTipoTokenLogin",
                        column: x => x.IdTipoTokenLogin,
                        principalTable: "TiposTokenLogic",
                        principalColumn: "IdTipoTokenLogin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TokensVerificacionCorreo_IdCuenta",
                table: "TokensVerificacionCorreo",
                column: "IdCuenta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TokensContadorAcceso_IdCuenta",
                table: "TokensContadorAcceso",
                column: "IdCuenta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TokensActualizarPassword_IdCuenta",
                table: "TokensActualizarPassword",
                column: "IdCuenta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstatusCuentas_IdCuenta",
                table: "EstatusCuentas",
                column: "IdCuenta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TokensLogin_IdTipoTokenLogin",
                table: "TokensLogin",
                column: "IdTipoTokenLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_EstatusCuentas_Cuentas_IdCuenta",
                table: "EstatusCuentas",
                column: "IdCuenta",
                principalTable: "Cuentas",
                principalColumn: "IdCuenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokensActualizarPassword_Cuentas_IdCuenta",
                table: "TokensActualizarPassword",
                column: "IdCuenta",
                principalTable: "Cuentas",
                principalColumn: "IdCuenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokensContadorAcceso_Cuentas_IdCuenta",
                table: "TokensContadorAcceso",
                column: "IdCuenta",
                principalTable: "Cuentas",
                principalColumn: "IdCuenta",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokensVerificacionCorreo_Cuentas_IdCuenta",
                table: "TokensVerificacionCorreo",
                column: "IdCuenta",
                principalTable: "Cuentas",
                principalColumn: "IdCuenta",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstatusCuentas_Cuentas_IdCuenta",
                table: "EstatusCuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_TokensActualizarPassword_Cuentas_IdCuenta",
                table: "TokensActualizarPassword");

            migrationBuilder.DropForeignKey(
                name: "FK_TokensContadorAcceso_Cuentas_IdCuenta",
                table: "TokensContadorAcceso");

            migrationBuilder.DropForeignKey(
                name: "FK_TokensVerificacionCorreo_Cuentas_IdCuenta",
                table: "TokensVerificacionCorreo");

            migrationBuilder.DropTable(
                name: "TokensLogin");

            migrationBuilder.DropTable(
                name: "TiposTokenLogic");

            migrationBuilder.DropIndex(
                name: "IX_TokensVerificacionCorreo_IdCuenta",
                table: "TokensVerificacionCorreo");

            migrationBuilder.DropIndex(
                name: "IX_TokensContadorAcceso_IdCuenta",
                table: "TokensContadorAcceso");

            migrationBuilder.DropIndex(
                name: "IX_TokensActualizarPassword_IdCuenta",
                table: "TokensActualizarPassword");

            migrationBuilder.DropIndex(
                name: "IX_EstatusCuentas_IdCuenta",
                table: "EstatusCuentas");

            migrationBuilder.AlterColumn<int>(
                name: "IdCuenta",
                table: "EstatusCuentas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_EstatusCuentas_IdCuenta",
                table: "EstatusCuentas",
                column: "IdCuenta",
                unique: true,
                filter: "[IdCuenta] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EstatusCuentas_Cuentas_IdCuenta",
                table: "EstatusCuentas",
                column: "IdCuenta",
                principalTable: "Cuentas",
                principalColumn: "IdCuenta");
        }
    }
}
