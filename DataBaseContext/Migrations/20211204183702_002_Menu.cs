using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseContext.Migrations
{
    public partial class _002_Menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    padreId = table.Column<int>(type: "int", nullable: true),
                    nombre = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    url = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    iconClass = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    creadoPor = table.Column<int>(type: "int", nullable: false),
                    creado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
                    modificadoPor = table.Column<int>(type: "int", nullable: true),
                    modificado = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.id);
                    table.ForeignKey(
                        name: "FK_Menu_CreadoPor",
                        column: x => x.creadoPor,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Menu_ModificadoPor",
                        column: x => x.modificadoPor,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_creadoPor",
                table: "Menu",
                column: "creadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_modificadoPor",
                table: "Menu",
                column: "modificadoPor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Menu");
        }
    }
}
