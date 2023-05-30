using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Titulos.BData.Migrations
{
    /// <inheritdoc />
    public partial class matricula3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Pago",
                table: "Matriculas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Matriculas");
        }
    }
}
