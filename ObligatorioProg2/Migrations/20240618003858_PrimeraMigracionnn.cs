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
            migrationBuilder.DropForeignKey(
                name: "FK_Locales_Responsables_ResponsableId",
                table: "Locales");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsableId",
                table: "Locales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locales_Responsables_ResponsableId",
                table: "Locales",
                column: "ResponsableId",
                principalTable: "Responsables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locales_Responsables_ResponsableId",
                table: "Locales");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsableId",
                table: "Locales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Locales_Responsables_ResponsableId",
                table: "Locales",
                column: "ResponsableId",
                principalTable: "Responsables",
                principalColumn: "Id");
        }
    }
}
