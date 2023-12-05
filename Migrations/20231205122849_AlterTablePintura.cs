using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporArt.Migrations
{
    /// <inheritdoc />
    public partial class AlterTablePintura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Pinturas",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Musicas",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Fotos",
                newName: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Pinturas",
                newName: "AutorId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Musicas",
                newName: "AutorId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Fotos",
                newName: "AutorId");
        }
    }
}
