using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseContext.Migrations
{
    public partial class _008_COVIDTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COVIDTest",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idCatalogoTest = table.Column<int>(type: "int", nullable: false),
                    resultado = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    numeroAutorizacion = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    RdRP = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    creadoPor = table.Column<int>(type: "int", nullable: false),
                    creado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
                    modificadoPor = table.Column<int>(type: "int", nullable: true),
                    modificado = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COVIDTest", x => x.id);
                    table.ForeignKey(
                        name: "FK_COVIDTest_CatalogoTest",
                        column: x => x.modificadoPor,
                        principalTable: "CatalogoTest",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COVIDTest_CreadoPor",
                        column: x => x.creadoPor,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COVIDTest_ModificadoPor",
                        column: x => x.modificadoPor,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COVIDTest_creadoPor",
                table: "COVIDTest",
                column: "creadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_COVIDTest_modificadoPor",
                table: "COVIDTest",
                column: "modificadoPor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "COVIDTest");
        }
    }
}
