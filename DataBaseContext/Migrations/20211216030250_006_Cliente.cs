using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseContext.Migrations
{
    public partial class _006_Cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    edad = table.Column<int>(type: "int", nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    sexo = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    telefono = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    nombreDoctor = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    numeroPasaporte = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    creadoPor = table.Column<int>(type: "int", nullable: false),
                    creado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
                    modificadoPor = table.Column<int>(type: "int", nullable: true),
                    modificado = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cliente_CreadoPor",
                        column: x => x.creadoPor,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_ModificadoPor",
                        column: x => x.modificadoPor,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_creadoPor",
                table: "Cliente",
                column: "creadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_modificadoPor",
                table: "Cliente",
                column: "modificadoPor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
