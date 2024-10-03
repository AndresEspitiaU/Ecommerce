using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.BD.Migrations
{
    /// <inheritdoc />
    public partial class AddProductoColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ProductoT__Produ__59C55456",
                table: "ProductoTallas");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductoT__Talla__5AB9788F",
                table: "ProductoTallas");

            migrationBuilder.CreateTable(
                name: "ProductoColor",
                columns: table => new
                {
                    ProductoColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoColor", x => x.ProductoColorId);
                    table.ForeignKey(
                        name: "FK_ProductoColor_Colores_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colores",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoColor_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoColor_ColorId",
                table: "ProductoColor",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoColor_ProductoId",
                table: "ProductoColor",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductoT__Produ__59C55456",
                table: "ProductoTallas",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__ProductoT__Talla__5AB9788F",
                table: "ProductoTallas",
                column: "TallaId",
                principalTable: "Tallas",
                principalColumn: "TallaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ProductoT__Produ__59C55456",
                table: "ProductoTallas");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductoT__Talla__5AB9788F",
                table: "ProductoTallas");

            migrationBuilder.DropTable(
                name: "ProductoColor");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductoT__Produ__59C55456",
                table: "ProductoTallas",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductoT__Talla__5AB9788F",
                table: "ProductoTallas",
                column: "TallaId",
                principalTable: "Tallas",
                principalColumn: "TallaId");
        }
    }
}
