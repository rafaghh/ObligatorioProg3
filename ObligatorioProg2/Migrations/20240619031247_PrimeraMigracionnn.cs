using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObligatorioProg3.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracionnn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Locales");

            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "Locales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locales_CiudadId",
                table: "Locales",
                column: "CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locales_Ciudades_CiudadId",
                table: "Locales",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locales_Ciudades_CiudadId",
                table: "Locales");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_Locales_CiudadId",
                table: "Locales");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "Locales");

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Locales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
