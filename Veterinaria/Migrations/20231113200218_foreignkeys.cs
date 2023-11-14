using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class foreignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Servicios_ClienteId",
                table: "Servicios",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_DoctorId",
                table: "Servicios",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Clientes_ClienteId",
                table: "Servicios",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Doctores_DoctorId",
                table: "Servicios",
                column: "DoctorId",
                principalTable: "Doctores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Clientes_ClienteId",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Doctores_DoctorId",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_ClienteId",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_DoctorId",
                table: "Servicios");
        }
    }
}
