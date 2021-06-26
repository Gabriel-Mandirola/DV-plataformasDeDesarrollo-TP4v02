using Microsoft.EntityFrameworkCore.Migrations;

namespace TP2_Grupo4.Migrations
{
    public partial class tercero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuarioId",
                table: "Reservas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_usuarioId",
                table: "Reservas",
                column: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Usuarios_usuarioId",
                table: "Reservas",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_usuarioId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_usuarioId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Reservas");
        }
    }
}
