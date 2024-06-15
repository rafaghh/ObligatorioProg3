using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObligatorioProg3.Migrations
{
    /// <inheritdoc />
    public partial class holad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Local_Responsable_ResponsableId",
                table: "Local");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsableId",
                table: "Local",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdResponsable",
                table: "Local",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Local_Responsable_ResponsableId",
                table: "Local",
                column: "ResponsableId",
                principalTable: "Responsable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Local_Responsable_ResponsableId",
                table: "Local");

            migrationBuilder.DropColumn(
                name: "IdResponsable",
                table: "Local");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsableId",
                table: "Local",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Local_Responsable_ResponsableId",
                table: "Local",
                column: "ResponsableId",
                principalTable: "Responsable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
