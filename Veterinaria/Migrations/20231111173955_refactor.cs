using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Clientes_ClienteId",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Doctores_DoctorId",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Veterinarias_VeterinariasId",
                table: "Servicios");

            migrationBuilder.DropTable(
                name: "Veterinarias");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_ClienteId",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_DoctorId",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_VeterinariasId",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "VeterinariasId",
                table: "Servicios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VeterinariasId",
                table: "Servicios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Veterinarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veterinarias_Doctores_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_ClienteId",
                table: "Servicios",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_DoctorId",
                table: "Servicios",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_VeterinariasId",
                table: "Servicios",
                column: "VeterinariasId");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarias_DoctorId",
                table: "Veterinarias",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Veterinarias_VeterinariasId",
                table: "Servicios",
                column: "VeterinariasId",
                principalTable: "Veterinarias",
                principalColumn: "Id");
        }
    }
}
