using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseContext.Migrations
{
    public partial class _001_AddForeignKey_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuario_creadoPor",
                table: "Usuario",
                column: "creadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_modificadoPor",
                table: "Usuario",
                column: "modificadoPor");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_CreadoPor",
                table: "Usuario",
                column: "creadoPor",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_ModificadoPor",
                table: "Usuario",
                column: "modificadoPor",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Usuario_CreadoPor",
            //    table: "Usuario");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Usuario_ModificadoPor",
            //    table: "Usuario");

            //migrationBuilder.DropIndex(
            //    name: "IX_Usuario_creadoPor",
            //    table: "Usuario");

            //migrationBuilder.DropIndex(
            //    name: "IX_Usuario_modificadoPor",
            //    table: "Usuario");
        }
    }
}
