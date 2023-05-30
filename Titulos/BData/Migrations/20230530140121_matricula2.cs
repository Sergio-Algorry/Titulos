using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Titulos.BData.Migrations
{
    /// <inheritdoc />
    public partial class matricula2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matriculas_EspecialidadId",
                table: "Matriculas");

            migrationBuilder.CreateIndex(
                name: "Matricula_EspecialidadId_PersonaId_UQ",
                table: "Matriculas",
                columns: new[] { "EspecialidadId", "PersonaId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Matricula_EspecialidadId_PersonaId_UQ",
                table: "Matriculas");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_EspecialidadId",
                table: "Matriculas",
                column: "EspecialidadId");
        }
    }
}
