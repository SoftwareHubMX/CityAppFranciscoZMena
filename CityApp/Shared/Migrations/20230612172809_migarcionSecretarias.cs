using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class migarcionSecretarias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Secretarias",
                columns: table => new
                {
                    IdSecretaria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSecretaria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretarias", x => x.IdSecretaria);
                });

            migrationBuilder.CreateTable(
                name: "TiposTramites",
                columns: table => new
                {
                    IdTipoTramite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTramite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTramites", x => x.IdTipoTramite);
                });

            migrationBuilder.CreateTable(
                name: "Dependencias",
                columns: table => new
                {
                    IdDependencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDependencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSecretaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependencias", x => x.IdDependencia);
                    table.ForeignKey(
                        name: "FK_Dependencias_Secretarias_IdSecretaria",
                        column: x => x.IdSecretaria,
                        principalTable: "Secretarias",
                        principalColumn: "IdSecretaria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tramites",
                columns: table => new
                {
                    IdTramite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDependencia = table.Column<int>(type: "int", nullable: false),
                    IdTipoTramite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramites", x => x.IdTramite);
                    table.ForeignKey(
                        name: "FK_Tramites_Dependencias_IdDependencia",
                        column: x => x.IdDependencia,
                        principalTable: "Dependencias",
                        principalColumn: "IdDependencia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tramites_TiposTramites_IdTipoTramite",
                        column: x => x.IdTipoTramite,
                        principalTable: "TiposTramites",
                        principalColumn: "IdTipoTramite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependencias_IdSecretaria",
                table: "Dependencias",
                column: "IdSecretaria");

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_IdDependencia",
                table: "Tramites",
                column: "IdDependencia");

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_IdTipoTramite",
                table: "Tramites",
                column: "IdTipoTramite");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tramites");

            migrationBuilder.DropTable(
                name: "Dependencias");

            migrationBuilder.DropTable(
                name: "TiposTramites");

            migrationBuilder.DropTable(
                name: "Secretarias");
        }
    }
}
