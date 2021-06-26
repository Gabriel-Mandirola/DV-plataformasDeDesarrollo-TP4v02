using Microsoft.EntityFrameworkCore.Migrations;

namespace TP2_Grupo4.Migrations
{
    public partial class segundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "alojamientoid",
                table: "Reservas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_alojamientoid",
                table: "Reservas",
                column: "alojamientoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Alojamientos_alojamientoid",
                table: "Reservas",
                column: "alojamientoid",
                principalTable: "Alojamientos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Alojamientos_alojamientoid",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_alojamientoid",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "alojamientoid",
                table: "Reservas");
        }
    }
}
