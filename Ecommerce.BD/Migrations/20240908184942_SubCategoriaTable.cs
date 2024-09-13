using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.BD.Migrations
{
    /// <inheritdoc />
    public partial class SubCategoriaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubcategoriaId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subcategorias",
                columns: table => new
                {
                    SubcategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategorias", x => x.SubcategoriaId);
                    table.ForeignKey(
                        name: "FK_Subcategorias_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_SubcategoriaId",
                table: "Productos",
                column: "SubcategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategorias_CategoriaId",
                table: "Subcategorias",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Subcategorias_SubcategoriaId",
                table: "Productos",
                column: "SubcategoriaId",
                principalTable: "Subcategorias",
                principalColumn: "SubcategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Subcategorias_SubcategoriaId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Subcategorias");

            migrationBuilder.DropIndex(
                name: "IX_Productos_SubcategoriaId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "SubcategoriaId",
                table: "Productos");
        }
    }
}
