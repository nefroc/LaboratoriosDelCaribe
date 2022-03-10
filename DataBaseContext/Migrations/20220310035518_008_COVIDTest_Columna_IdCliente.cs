using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseContext.Migrations
{
    public partial class _008_COVIDTest_Columna_IdCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idCliente",
                table: "COVIDTest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_COVIDTest_idCliente",
                table: "COVIDTest",
                column: "idCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_COVIDTest_Cliente",
                table: "COVIDTest",
                column: "idCliente",
                principalTable: "Cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_COVIDTest_Cliente",
            //    table: "COVIDTest");

            //migrationBuilder.DropIndex(
            //    name: "IX_COVIDTest_idCliente",
            //    table: "COVIDTest");

            //migrationBuilder.DropColumn(
            //    name: "idCliente",
            //    table: "COVIDTest");
        }
    }
}
