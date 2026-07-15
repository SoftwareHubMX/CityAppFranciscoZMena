using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class SocialMunicipio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactosMunicipio",
                columns: table => new
                {
                    IdContactoMunicipio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Web = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactosMunicipio", x => x.IdContactoMunicipio);
                });

            migrationBuilder.CreateTable(
                name: "TiposRedesSociales",
                columns: table => new
                {
                    IdTipoRedSocial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedSocial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposRedesSociales", x => x.IdTipoRedSocial);
                });

            migrationBuilder.CreateTable(
                name: "RedesSocialesMunicipio",
                columns: table => new
                {
                    IdRedSocialMunicipio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoRedSocial = table.Column<int>(type: "int", nullable: false),
                    IdContactoMunicipio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedesSocialesMunicipio", x => x.IdRedSocialMunicipio);
                    table.ForeignKey(
                        name: "FK_RedesSocialesMunicipio_ContactosMunicipio_IdContactoMunicipio",
                        column: x => x.IdContactoMunicipio,
                        principalTable: "ContactosMunicipio",
                        principalColumn: "IdContactoMunicipio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RedesSocialesMunicipio_TiposRedesSociales_IdTipoRedSocial",
                        column: x => x.IdTipoRedSocial,
                        principalTable: "TiposRedesSociales",
                        principalColumn: "IdTipoRedSocial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RedesSocialesMunicipio_IdContactoMunicipio",
                table: "RedesSocialesMunicipio",
                column: "IdContactoMunicipio");

            migrationBuilder.CreateIndex(
                name: "IX_RedesSocialesMunicipio_IdTipoRedSocial",
                table: "RedesSocialesMunicipio",
                column: "IdTipoRedSocial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RedesSocialesMunicipio");

            migrationBuilder.DropTable(
                name: "ContactosMunicipio");

            migrationBuilder.DropTable(
                name: "TiposRedesSociales");
        }
    }
}
