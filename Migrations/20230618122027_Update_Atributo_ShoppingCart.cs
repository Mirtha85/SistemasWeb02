using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemasWeb01.Migrations
{
    /// <inheritdoc />
    public partial class Update_Atributo_ShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItemsDbSet_Pies_PieId",
                table: "ShoppingCartItemsDbSet");

            migrationBuilder.RenameColumn(
                name: "PieId",
                table: "ShoppingCartItemsDbSet",
                newName: "productoId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItemsDbSet_PieId",
                table: "ShoppingCartItemsDbSet",
                newName: "IX_ShoppingCartItemsDbSet_productoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItemsDbSet_ProductosDbSet_productoId",
                table: "ShoppingCartItemsDbSet",
                column: "productoId",
                principalTable: "ProductosDbSet",
                principalColumn: "productoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItemsDbSet_ProductosDbSet_productoId",
                table: "ShoppingCartItemsDbSet");

            migrationBuilder.RenameColumn(
                name: "productoId",
                table: "ShoppingCartItemsDbSet",
                newName: "PieId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItemsDbSet_productoId",
                table: "ShoppingCartItemsDbSet",
                newName: "IX_ShoppingCartItemsDbSet_PieId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItemsDbSet_Pies_PieId",
                table: "ShoppingCartItemsDbSet",
                column: "PieId",
                principalTable: "Pies",
                principalColumn: "PieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
