using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Titulos.BData.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodProfesion = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodEspecialidad = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    DescEspecialidad = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ProfesionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidades_Profesiones_ProfesionId",
                        column: x => x.ProfesionId,
                        principalTable: "Profesiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "Especialidad_CodEspecialidad_UQ",
                table: "Especialidades",
                column: "CodEspecialidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_ProfesionId",
                table: "Especialidades",
                column: "ProfesionId");

            migrationBuilder.CreateIndex(
                name: "Persona_DNI_UQ",
                table: "Personas",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Profesion_CodProfesion_UQ",
                table: "Profesiones",
                column: "CodProfesion",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Profesiones");
        }
    }
}
