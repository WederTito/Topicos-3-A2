using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciarArmazen.Migrations
{
    /// <inheritdoc />
    public partial class Ingrediente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ingrediente_ArmazenamentoId",
                table: "Ingrediente");

            migrationBuilder.DropIndex(
                name: "IX_Ingrediente_CategoriaId",
                table: "Ingrediente");

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_ArmazenamentoId",
                table: "Ingrediente",
                column: "ArmazenamentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_CategoriaId",
                table: "Ingrediente",
                column: "CategoriaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ingrediente_ArmazenamentoId",
                table: "Ingrediente");

            migrationBuilder.DropIndex(
                name: "IX_Ingrediente_CategoriaId",
                table: "Ingrediente");

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_ArmazenamentoId",
                table: "Ingrediente",
                column: "ArmazenamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_CategoriaId",
                table: "Ingrediente",
                column: "CategoriaId");
        }
    }
}
