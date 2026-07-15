using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityApp.Shared.Migrations
{
    public partial class rutasrecolecciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.CreateTable(
                name: "Colonias",
                columns: table => new
                {
                    IdColonia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreColonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Lonitud = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colonias", x => x.IdColonia);
                });

            migrationBuilder.CreateTable(
                name: "RutasRecoleccion",
                columns: table => new
                {
                    IdRutaRecoleccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Concecionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreRuta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCuenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutasRecoleccion", x => x.IdRutaRecoleccion);
                    table.ForeignKey(
                        name: "FK_RutasRecoleccion_Cuentas_IdCuenta",
                        column: x => x.IdCuenta,
                        principalTable: "Cuentas",
                        principalColumn: "IdCuenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusAlertasRuta",
                columns: table => new
                {
                    IdStatusAlertaRuta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusAlerta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusAlertasRuta", x => x.IdStatusAlertaRuta);
                });

            migrationBuilder.CreateTable(
                name: "StatusBolsas",
                columns: table => new
                {
                    IdStatusBolsa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusBolsaTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusBolsas", x => x.IdStatusBolsa);
                });

            migrationBuilder.CreateTable(
                name: "TiposAlertaRuta",
                columns: table => new
                {
                    IdTipoAlertaRuta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoAlerta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAlertaRuta", x => x.IdTipoAlertaRuta);
                });

            migrationBuilder.CreateTable(
                name: "ColoniasRutaRecoleccion",
                columns: table => new
                {
                    IdColoniaRutaRecoleccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdColonia = table.Column<int>(type: "int", nullable: false),
                    IdRutaRecoleccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColoniasRutaRecoleccion", x => x.IdColoniaRutaRecoleccion);
                    table.ForeignKey(
                        name: "FK_ColoniasRutaRecoleccion_Colonias_IdColonia",
                        column: x => x.IdColonia,
                        principalTable: "Colonias",
                        principalColumn: "IdColonia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColoniasRutaRecoleccion_RutasRecoleccion_IdRutaRecoleccion",
                        column: x => x.IdRutaRecoleccion,
                        principalTable: "RutasRecoleccion",
                        principalColumn: "IdRutaRecoleccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiasRuta",
                columns: table => new
                {
                    IdDiaRuta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRutaRecoleccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasRuta", x => x.IdDiaRuta);
                    table.ForeignKey(
                        name: "FK_DiasRuta_RutasRecoleccion_IdRutaRecoleccion",
                        column: x => x.IdRutaRecoleccion,
                        principalTable: "RutasRecoleccion",
                        principalColumn: "IdRutaRecoleccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlertasRutas",
                columns: table => new
                {
                    IdAlertaRuta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAlerta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTipoAlertaRuta = table.Column<int>(type: "int", nullable: false),
                    IdStatusAlertaRuta = table.Column<int>(type: "int", nullable: false),
                    IdRutaRecoleccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertasRutas", x => x.IdAlertaRuta);
                    table.ForeignKey(
                        name: "FK_AlertasRutas_RutasRecoleccion_IdRutaRecoleccion",
                        column: x => x.IdRutaRecoleccion,
                        principalTable: "RutasRecoleccion",
                        principalColumn: "IdRutaRecoleccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertasRutas_StatusAlertasRuta_IdStatusAlertaRuta",
                        column: x => x.IdStatusAlertaRuta,
                        principalTable: "StatusAlertasRuta",
                        principalColumn: "IdStatusAlertaRuta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertasRutas_TiposAlertaRuta_IdTipoAlertaRuta",
                        column: x => x.IdTipoAlertaRuta,
                        principalTable: "TiposAlertaRuta",
                        principalColumn: "IdTipoAlertaRuta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertasRutas_IdRutaRecoleccion",
                table: "AlertasRutas",
                column: "IdRutaRecoleccion");

            migrationBuilder.CreateIndex(
                name: "IX_AlertasRutas_IdStatusAlertaRuta",
                table: "AlertasRutas",
                column: "IdStatusAlertaRuta");

            migrationBuilder.CreateIndex(
                name: "IX_AlertasRutas_IdTipoAlertaRuta",
                table: "AlertasRutas",
                column: "IdTipoAlertaRuta");

            migrationBuilder.CreateIndex(
                name: "IX_ColoniasRutaRecoleccion_IdColonia",
                table: "ColoniasRutaRecoleccion",
                column: "IdColonia");

            migrationBuilder.CreateIndex(
                name: "IX_ColoniasRutaRecoleccion_IdRutaRecoleccion",
                table: "ColoniasRutaRecoleccion",
                column: "IdRutaRecoleccion");

            migrationBuilder.CreateIndex(
                name: "IX_DiasRuta_IdRutaRecoleccion",
                table: "DiasRuta",
                column: "IdRutaRecoleccion");

            migrationBuilder.CreateIndex(
                name: "IX_RutasRecoleccion_IdCuenta",
                table: "RutasRecoleccion",
                column: "IdCuenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertasRutas");

            migrationBuilder.DropTable(
                name: "ColoniasRutaRecoleccion");

            migrationBuilder.DropTable(
                name: "DiasRuta");

            migrationBuilder.DropTable(
                name: "StatusBolsas");

            migrationBuilder.DropTable(
                name: "StatusAlertasRuta");

            migrationBuilder.DropTable(
                name: "TiposAlertaRuta");

            migrationBuilder.DropTable(
                name: "Colonias");

            migrationBuilder.DropTable(
                name: "RutasRecoleccion");   
        }
    }
}
