using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class tipolugaresturisticos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Principal",
                table: "ArchivosLugaresTuristicos");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFundacionConstruccionApertura",
                table: "LugaresTuristicos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdTipoLugarTuristico",
                table: "LugaresTuristicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TiposLugarTuristico",
                columns: table => new
                {
                    IdTipoLugarTuristico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposLugarTuristico", x => x.IdTipoLugarTuristico);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LugaresTuristicos_IdTipoLugarTuristico",
                table: "LugaresTuristicos",
                column: "IdTipoLugarTuristico");

            migrationBuilder.AddForeignKey(
                name: "FK_LugaresTuristicos_TiposLugarTuristico_IdTipoLugarTuristico",
                table: "LugaresTuristicos",
                column: "IdTipoLugarTuristico",
                principalTable: "TiposLugarTuristico",
                principalColumn: "IdTipoLugarTuristico",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LugaresTuristicos_TiposLugarTuristico_IdTipoLugarTuristico",
                table: "LugaresTuristicos");

            migrationBuilder.DropTable(
                name: "TiposLugarTuristico");

            migrationBuilder.DropIndex(
                name: "IX_LugaresTuristicos_IdTipoLugarTuristico",
                table: "LugaresTuristicos");

            migrationBuilder.DropColumn(
                name: "FechaFundacionConstruccionApertura",
                table: "LugaresTuristicos");

            migrationBuilder.DropColumn(
                name: "IdTipoLugarTuristico",
                table: "LugaresTuristicos");

            migrationBuilder.AddColumn<bool>(
                name: "Principal",
                table: "ArchivosLugaresTuristicos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
