using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObligatorioProg3.Migrations
{
    /// <inheritdoc />
    public partial class holaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maquina_Local_LocalIdLocal",
                table: "Maquina");

            migrationBuilder.DropForeignKey(
                name: "FK_Maquina_TipoMaquina_TipoMaquinaIdTipoMaq",
                table: "Maquina");

            migrationBuilder.RenameColumn(
                name: "IdTipoSocio",
                table: "TipoSocio",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdTipoMaq",
                table: "TipoMaquina",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TipoMaquinaIdTipoMaq",
                table: "Maquina",
                newName: "TipoMaquinaId");

            migrationBuilder.RenameColumn(
                name: "LocalIdLocal",
                table: "Maquina",
                newName: "LocalId");

            migrationBuilder.RenameColumn(
                name: "IdMaquina",
                table: "Maquina",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Maquina_TipoMaquinaIdTipoMaq",
                table: "Maquina",
                newName: "IX_Maquina_TipoMaquinaId");

            migrationBuilder.RenameIndex(
                name: "IX_Maquina_LocalIdLocal",
                table: "Maquina",
                newName: "IX_Maquina_LocalId");

            migrationBuilder.RenameColumn(
                name: "IdLocal",
                table: "Local",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "TipoRutina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRutina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rutina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    TipoRutinaId = table.Column<int>(type: "int", nullable: true),
                    idTipoRutina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rutina_TipoRutina_TipoRutinaId",
                        column: x => x.TipoRutinaId,
                        principalTable: "TipoRutina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rutina_TipoRutinaId",
                table: "Rutina",
                column: "TipoRutinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maquina_Local_LocalId",
                table: "Maquina",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maquina_TipoMaquina_TipoMaquinaId",
                table: "Maquina",
                column: "TipoMaquinaId",
                principalTable: "TipoMaquina",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maquina_Local_LocalId",
                table: "Maquina");

            migrationBuilder.DropForeignKey(
                name: "FK_Maquina_TipoMaquina_TipoMaquinaId",
                table: "Maquina");

            migrationBuilder.DropTable(
                name: "Rutina");

            migrationBuilder.DropTable(
                name: "TipoRutina");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TipoSocio",
                newName: "IdTipoSocio");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TipoMaquina",
                newName: "IdTipoMaq");

            migrationBuilder.RenameColumn(
                name: "TipoMaquinaId",
                table: "Maquina",
                newName: "TipoMaquinaIdTipoMaq");

            migrationBuilder.RenameColumn(
                name: "LocalId",
                table: "Maquina",
                newName: "LocalIdLocal");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Maquina",
                newName: "IdMaquina");

            migrationBuilder.RenameIndex(
                name: "IX_Maquina_TipoMaquinaId",
                table: "Maquina",
                newName: "IX_Maquina_TipoMaquinaIdTipoMaq");

            migrationBuilder.RenameIndex(
                name: "IX_Maquina_LocalId",
                table: "Maquina",
                newName: "IX_Maquina_LocalIdLocal");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Local",
                newName: "IdLocal");

            migrationBuilder.AddForeignKey(
                name: "FK_Maquina_Local_LocalIdLocal",
                table: "Maquina",
                column: "LocalIdLocal",
                principalTable: "Local",
                principalColumn: "IdLocal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Maquina_TipoMaquina_TipoMaquinaIdTipoMaq",
                table: "Maquina",
                column: "TipoMaquinaIdTipoMaq",
                principalTable: "TipoMaquina",
                principalColumn: "IdTipoMaq");
        }
    }
}
