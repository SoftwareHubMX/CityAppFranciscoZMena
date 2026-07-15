using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class Tokens2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TokensLogin_TiposTokenLogic_IdTipoTokenLogin",
                table: "TokensLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposTokenLogic",
                table: "TiposTokenLogic");

            migrationBuilder.RenameTable(
                name: "TiposTokenLogic",
                newName: "TiposTokenLogin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposTokenLogin",
                table: "TiposTokenLogin",
                column: "IdTipoTokenLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_TokensLogin_TiposTokenLogin_IdTipoTokenLogin",
                table: "TokensLogin",
                column: "IdTipoTokenLogin",
                principalTable: "TiposTokenLogin",
                principalColumn: "IdTipoTokenLogin",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TokensLogin_TiposTokenLogin_IdTipoTokenLogin",
                table: "TokensLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposTokenLogin",
                table: "TiposTokenLogin");

            migrationBuilder.RenameTable(
                name: "TiposTokenLogin",
                newName: "TiposTokenLogic");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposTokenLogic",
                table: "TiposTokenLogic",
                column: "IdTipoTokenLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_TokensLogin_TiposTokenLogic_IdTipoTokenLogin",
                table: "TokensLogin",
                column: "IdTipoTokenLogin",
                principalTable: "TiposTokenLogic",
                principalColumn: "IdTipoTokenLogin",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
