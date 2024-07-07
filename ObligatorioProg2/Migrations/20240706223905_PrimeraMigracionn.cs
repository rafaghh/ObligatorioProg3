using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObligatorioProg3.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracionn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocioRutinas_Maquinas_MaquinaId",
                table: "SocioRutinas");

            migrationBuilder.AlterColumn<int>(
                name: "MaquinaId",
                table: "SocioRutinas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SocioRutinas_Maquinas_MaquinaId",
                table: "SocioRutinas",
                column: "MaquinaId",
                principalTable: "Maquinas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocioRutinas_Maquinas_MaquinaId",
                table: "SocioRutinas");

            migrationBuilder.AlterColumn<int>(
                name: "MaquinaId",
                table: "SocioRutinas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SocioRutinas_Maquinas_MaquinaId",
                table: "SocioRutinas",
                column: "MaquinaId",
                principalTable: "Maquinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
