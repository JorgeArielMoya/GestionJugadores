using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionJugadores.Migrations
{
    /// <inheritdoc />
    public partial class NewCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "Jugadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Empates",
                table: "Jugadores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "Empates",
                table: "Jugadores");
        }
    }
}
