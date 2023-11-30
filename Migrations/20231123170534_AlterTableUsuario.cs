using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SporArt.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Usuarios");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Contribuicoes", "Conversas", "Email", "Nome", "Senha" },
                values: new object[,]
                {
                    { 1, (short)0, (short)0, "senaiadm@gmail.com", "Senai ADMIN", "Senai321" },
                    { 2, (short)0, (short)0, "senaialuno@gmail.com", "Senai Aluno", "Senai123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
