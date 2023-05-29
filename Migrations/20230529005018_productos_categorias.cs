 using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemasWeb01.Migrations
{
    /// <inheritdoc />
    public partial class productos_categorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasDbSet",
                columns: table => new
                {
                    categoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoriaNombre = table.Column<string>(type: "TEXT", nullable: false),
                    descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasDbSet", x => x.categoriaId);
                });

            migrationBuilder.CreateTable(
                name: "ProductosDbSet",
                columns: table => new
                {
                    productoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productoNombre = table.Column<string>(type: "TEXT", nullable: false),
                    precio = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    imagen = table.Column<string>(type: "TEXT", nullable: false),
                    detalle = table.Column<string>(type: "TEXT", nullable: false),
                    deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosDbSet", x => x.productoId);
                    table.ForeignKey(
                        name: "FK_ProductosDbSet_CategoriasDbSet_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriasDbSet",
                        principalColumn: "categoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductosDbSet_CategoriaId",
                table: "ProductosDbSet",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductosDbSet");

            migrationBuilder.DropTable(
                name: "CategoriasDbSet");
        }
    }
}
