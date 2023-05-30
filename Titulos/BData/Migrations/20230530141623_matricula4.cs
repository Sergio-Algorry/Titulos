using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Titulos.BData.Migrations
{
    /// <inheritdoc />
    public partial class matricula4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pago",
                table: "Matriculas",
                type: "Decimal(10,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pago",
                table: "Matriculas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(10,8)");
        }
    }
}
