using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ObligatorioProg3.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "TiposMaquina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaquinaNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMaquina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposRutina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposRutina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposSocio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beneficios = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSocio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locales_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ejercicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoMaquinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ejercicios_TiposMaquina_TipoMaquinaId",
                        column: x => x.TipoMaquinaId,
                        principalTable: "TiposMaquina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rutinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoRutinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rutinas_TiposRutina_TipoRutinaId",
                        column: x => x.TipoRutinaId,
                        principalTable: "TiposRutina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Maquinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalId = table.Column<int>(type: "int", nullable: true),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecioCompra = table.Column<int>(type: "int", nullable: false),
                    VidaUtil = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    TipoMaquinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maquinas_Locales_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Locales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Maquinas_TiposMaquina_TipoMaquinaId",
                        column: x => x.TipoMaquinaId,
                        principalTable: "TiposMaquina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Responsables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalId = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsables_Locales_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Socios_Locales_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Socios_TiposSocio_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TiposSocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RutinaEjercicios",
                columns: table => new
                {
                    RutinaId = table.Column<int>(type: "int", nullable: false),
                    EjercicioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutinaEjercicios", x => new { x.RutinaId, x.EjercicioId });
                    table.ForeignKey(
                        name: "FK_RutinaEjercicios_Ejercicios_EjercicioId",
                        column: x => x.EjercicioId,
                        principalTable: "Ejercicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RutinaEjercicios_Rutinas_RutinaId",
                        column: x => x.RutinaId,
                        principalTable: "Rutinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocioRutinas",
                columns: table => new
                {
                    SocioId = table.Column<int>(type: "int", nullable: false),
                    RutinaId = table.Column<int>(type: "int", nullable: false),
                    MaquinaId = table.Column<int>(type: "int", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocioRutinas", x => new { x.SocioId, x.RutinaId });
                    table.ForeignKey(
                        name: "FK_SocioRutinas_Maquinas_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "Maquinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocioRutinas_Rutinas_RutinaId",
                        column: x => x.RutinaId,
                        principalTable: "Rutinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocioRutinas_Socios_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Montevideo" },
                    { 2, "Colonia" }
                });

            migrationBuilder.InsertData(
                table: "TiposMaquina",
                columns: new[] { "Id", "Descripcion", "MaquinaNombre" },
                values: new object[,]
                {
                    { 1, "Máquina para correr y caminar", "Cinta de correr" },
                    { 2, "Máquina para ejercicio cardiovascular", "Bicicleta estática" }
                });

            migrationBuilder.InsertData(
                table: "TiposRutina",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Salud" },
                    { 2, "Competición amateur" },
                    { 3, "Competición profesional" }
                });

            migrationBuilder.InsertData(
                table: "TiposSocio",
                columns: new[] { "Id", "Beneficios", "TipoNombre" },
                values: new object[,]
                {
                    { 1, "Acceso limitado a áreas generales", "Estándar" },
                    { 2, "Acceso ilimitado a áreas generales", "Premium" }
                });

            migrationBuilder.InsertData(
                table: "Ejercicios",
                columns: new[] { "Id", "Descripcion", "TipoMaquinaId" },
                values: new object[,]
                {
                    { 1, "Correr en Cinta", 1 },
                    { 2, "Pedaleo en Bicicleta", 2 }
                });

            migrationBuilder.InsertData(
                table: "Locales",
                columns: new[] { "Id", "CiudadId", "Direccion", "Nombre", "ResponsableId", "Telefono" },
                values: new object[,]
                {
                    { 1, 1, "Calle Falsa 123", "Gimnasio Central", 1, "22001234" },
                    { 2, 2, "Avenida Siempreviva 742", "Gimnasio Este", 2, "23004567" }
                });

            migrationBuilder.InsertData(
                table: "Rutinas",
                columns: new[] { "Id", "Descripcion", "TipoRutinaId" },
                values: new object[,]
                {
                    { 1, "Rutina de Salud Básica", 1 },
                    { 2, "Rutina de Competición Amateur", 2 }
                });

            migrationBuilder.InsertData(
                table: "Maquinas",
                columns: new[] { "Id", "Disponible", "FechaCompra", "LocalId", "PrecioCompra", "TipoMaquinaId", "VidaUtil" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1500, 1, 5 },
                    { 2, false, new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1300, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Responsables",
                columns: new[] { "Id", "Email", "LocalId", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "juan.perez@example.com", 1, "Juan Perez", "099123456" },
                    { 2, "maria.gomez@example.com", 2, "Maria Gomez", "099654321" }
                });

            migrationBuilder.InsertData(
                table: "RutinaEjercicios",
                columns: new[] { "EjercicioId", "RutinaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Socios",
                columns: new[] { "Id", "Email", "LocalId", "Nombre", "Telefono", "TipoId" },
                values: new object[,]
                {
                    { 1, "carlos.ramirez@example.com", 1, "Carlos Ramirez", "098765432", 1 },
                    { 2, "ana.fernandez@example.com", 2, "Ana Fernandez", "097654321", 2 }
                });

            migrationBuilder.InsertData(
                table: "SocioRutinas",
                columns: new[] { "RutinaId", "SocioId", "Calificacion", "MaquinaId" },
                values: new object[,]
                {
                    { 1, 1, 5, 1 },
                    { 2, 2, 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicios_TipoMaquinaId",
                table: "Ejercicios",
                column: "TipoMaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Locales_CiudadId",
                table: "Locales",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Maquinas_LocalId",
                table: "Maquinas",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Maquinas_TipoMaquinaId",
                table: "Maquinas",
                column: "TipoMaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsables_LocalId",
                table: "Responsables",
                column: "LocalId",
                unique: true,
                filter: "[LocalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RutinaEjercicios_EjercicioId",
                table: "RutinaEjercicios",
                column: "EjercicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Rutinas_TipoRutinaId",
                table: "Rutinas",
                column: "TipoRutinaId");

            migrationBuilder.CreateIndex(
                name: "IX_SocioRutinas_MaquinaId",
                table: "SocioRutinas",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_SocioRutinas_RutinaId",
                table: "SocioRutinas",
                column: "RutinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_LocalId",
                table: "Socios",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_TipoId",
                table: "Socios",
                column: "TipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responsables");

            migrationBuilder.DropTable(
                name: "RutinaEjercicios");

            migrationBuilder.DropTable(
                name: "SocioRutinas");

            migrationBuilder.DropTable(
                name: "Ejercicios");

            migrationBuilder.DropTable(
                name: "Maquinas");

            migrationBuilder.DropTable(
                name: "Rutinas");

            migrationBuilder.DropTable(
                name: "Socios");

            migrationBuilder.DropTable(
                name: "TiposMaquina");

            migrationBuilder.DropTable(
                name: "TiposRutina");

            migrationBuilder.DropTable(
                name: "Locales");

            migrationBuilder.DropTable(
                name: "TiposSocio");

            migrationBuilder.DropTable(
                name: "Ciudades");
        }
    }
}
