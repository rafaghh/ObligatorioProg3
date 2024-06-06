using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObligatorioProg3.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Socio",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Socio",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Socio",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Socio");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Socio");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Socio");
        }
    }
}
