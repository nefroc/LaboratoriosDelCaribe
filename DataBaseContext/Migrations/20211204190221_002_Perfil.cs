using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseContext.Migrations
{
    public partial class _002_Perfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    creado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
                    creadoPor = table.Column<int>(type: "int", nullable: false),
                    modificado = table.Column<DateTime>(type: "datetime", nullable: true),
                    modificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.id);
                    table.ForeignKey(
                        name: "FK_Perfil_CreadoPor",
                        column: x => x.creadoPor,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Perfil_ModificadoPor",
                        column: x => x.modificadoPor,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_creadoPor",
                table: "Perfil",
                column: "creadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_modificadoPor",
                table: "Perfil",
                column: "modificadoPor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Perfil");
        }
    }
}
