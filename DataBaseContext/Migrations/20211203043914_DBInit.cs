using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseContext.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    correo = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    contrasena = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    nombre = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    apellidos = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    activo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    creadoPor = table.Column<int>(type: "int", nullable: false),
                    creado = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(CURRENT_TIMESTAMP)"),
                    modificadoPor = table.Column<int>(type: "int", nullable: true),
                    modificado = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Usuario");
        }
    }
}
