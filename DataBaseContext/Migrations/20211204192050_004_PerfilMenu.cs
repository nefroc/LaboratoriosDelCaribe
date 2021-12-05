using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseContext.Migrations
{
    public partial class _004_PerfilMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PerfilMenu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idPerfil = table.Column<int>(type: "int", nullable: false),
                    idMenu = table.Column<int>(type: "int", nullable: false),
                    creadoPor = table.Column<int>(type: "int", nullable: false),
                    creado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
                    modificadoPor = table.Column<int>(type: "int", nullable: true),
                    modificado = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilMenu", x => x.id);
                    table.ForeignKey(
                        name: "FK_PerfilMenu_CreadoPor",
                        column: x => x.creadoPor,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PerfilMenu_ModificadoPor",
                        column: x => x.modificadoPor,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilMenu_creadoPor",
                table: "PerfilMenu",
                column: "creadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilMenu_modificadoPor",
                table: "PerfilMenu",
                column: "modificadoPor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "PerfilMenu");
        }
    }
}
