using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class ActualizacionAnuncioArchivoAnuncio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAnuncio",
                table: "ArchivosAnuncio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosAnuncio_IdAnuncio",
                table: "ArchivosAnuncio",
                column: "IdAnuncio");

            migrationBuilder.AddForeignKey(
                name: "FK_ArchivosAnuncio_Anuncios_IdAnuncio",
                table: "ArchivosAnuncio",
                column: "IdAnuncio",
                principalTable: "Anuncios",
                principalColumn: "IdAnuncio",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArchivosAnuncio_Anuncios_IdAnuncio",
                table: "ArchivosAnuncio");

            migrationBuilder.DropIndex(
                name: "IX_ArchivosAnuncio_IdAnuncio",
                table: "ArchivosAnuncio");

            migrationBuilder.DropColumn(
                name: "IdAnuncio",
                table: "ArchivosAnuncio");
        }
    }
}
