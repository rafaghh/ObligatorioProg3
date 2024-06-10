using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObligatorioProg3.Migrations
{
    /// <inheritdoc />
    public partial class Primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responsable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMaquina",
                columns: table => new
                {
                    IdTipoMaq = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaquinaNombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMaquina", x => x.IdTipoMaq);
                });

            migrationBuilder.CreateTable(
                name: "TipoSocio",
                columns: table => new
                {
                    IdTipoSocio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Beneficios = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSocio", x => x.IdTipoSocio);
                });

            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    IdLocal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ResponsableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local", x => x.IdLocal);
                    table.ForeignKey(
                        name: "FK_Local_Responsable_ResponsableId",
                        column: x => x.ResponsableId,
                        principalTable: "Responsable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maquina",
                columns: table => new
                {
                    IdMaquina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalIdLocal = table.Column<int>(type: "int", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioCompra = table.Column<int>(type: "int", nullable: false),
                    VidaUtil = table.Column<int>(type: "int", nullable: false),
                    TipoMId = table.Column<int>(type: "int", nullable: false),
                    TipoMaquinaIdTipoMaq = table.Column<int>(type: "int", nullable: true),
                    Disponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.IdMaquina);
                    table.ForeignKey(
                        name: "FK_Maquina_Local_LocalIdLocal",
                        column: x => x.LocalIdLocal,
                        principalTable: "Local",
                        principalColumn: "IdLocal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maquina_TipoMaquina_TipoMaquinaIdTipoMaq",
                        column: x => x.TipoMaquinaIdTipoMaq,
                        principalTable: "TipoMaquina",
                        principalColumn: "IdTipoMaq");
                });

            migrationBuilder.CreateTable(
                name: "Socio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Socio_Local_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Local",
                        principalColumn: "IdLocal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Socio_TipoSocio_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoSocio",
                        principalColumn: "IdTipoSocio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Local_ResponsableId",
                table: "Local",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_LocalIdLocal",
                table: "Maquina",
                column: "LocalIdLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_TipoMaquinaIdTipoMaq",
                table: "Maquina",
                column: "TipoMaquinaIdTipoMaq");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_LocalId",
                table: "Socio",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_TipoId",
                table: "Socio",
                column: "TipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maquina");

            migrationBuilder.DropTable(
                name: "Socio");

            migrationBuilder.DropTable(
                name: "TipoMaquina");

            migrationBuilder.DropTable(
                name: "Local");

            migrationBuilder.DropTable(
                name: "TipoSocio");

            migrationBuilder.DropTable(
                name: "Responsable");
        }
    }
}
