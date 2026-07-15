using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class ActTipoCita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "TipoCitas",
                columns: table => new
                {
                    IdTipoCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCitas", x => x.IdTipoCita);
                });

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
                name: "FK_Citas_TipoCitas_IdTipoCita",
                table: "Citas",
                column: "IdTipoCita",
                principalTable: "TipoCitas",
                principalColumn: "IdTipoCita",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_TipoCitas_IdTipoCita",
                table: "Citas");

            migrationBuilder.DropTable(
                name: "TipoCitas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_IdTipoCita",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "IdTipoCita",
                table: "Citas");
        }
    }
}
