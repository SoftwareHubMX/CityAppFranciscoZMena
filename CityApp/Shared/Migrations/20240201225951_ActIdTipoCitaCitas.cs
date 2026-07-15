using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class ActIdTipoCitaCitas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTipoCita",
                table: "Citas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdTipoCita",
                table: "Citas",
                column: "IdTipoCita");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_TiposCita_IdTipoCita",
                table: "Citas",
                column: "IdTipoCita",
                principalTable: "TiposCita",
                principalColumn: "IdTipoCita",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_TiposCita_IdTipoCita",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_IdTipoCita",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "IdTipoCita",
                table: "Citas");
        }
    }
}
