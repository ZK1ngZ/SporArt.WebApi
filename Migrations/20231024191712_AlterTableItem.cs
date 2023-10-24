using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporArt.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Itens");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Itens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Itens_CategoriaId",
                table: "Itens",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Categorias_CategoriaId",
                table: "Itens",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Categorias_CategoriaId",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Itens_CategoriaId",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Itens");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Itens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
