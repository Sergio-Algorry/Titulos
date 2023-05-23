using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Titulos.BData.Migrations
{
    /// <inheritdoc />
    public partial class profesion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Profesiones");
        }
    }
}
