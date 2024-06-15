using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObligatorioProg3.Migrations
{
    /// <inheritdoc />
    public partial class holadf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socio_Local_LocalId",
                table: "Socio");

            migrationBuilder.AlterColumn<int>(
                name: "LocalId",
                table: "Socio",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Socio_Local_LocalId",
                table: "Socio",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "IdLocal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socio_Local_LocalId",
                table: "Socio");

            migrationBuilder.AlterColumn<int>(
                name: "LocalId",
                table: "Socio",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Socio_Local_LocalId",
                table: "Socio",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "IdLocal",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
