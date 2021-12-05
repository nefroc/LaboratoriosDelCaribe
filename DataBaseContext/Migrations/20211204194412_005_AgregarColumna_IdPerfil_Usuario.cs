using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseContext.Migrations
{
    public partial class _005_AgregarColumna_IdPerfil_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idPerfil",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idPerfil",
                table: "Usuario",
                column: "idPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil",
                table: "Usuario",
                column: "idPerfil",
                principalTable: "Perfil",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Usuario_Perfil",
            //    table: "Usuario");

            //migrationBuilder.DropIndex(
            //    name: "IX_Usuario_idPerfil",
            //    table: "Usuario");

            //migrationBuilder.DropColumn(
            //    name: "idPerfil",
            //    table: "Usuario");
        }
    }
}
