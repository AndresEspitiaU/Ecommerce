using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.BD.Migrations
{
    /// <inheritdoc />
    public partial class TallaUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TalCadera",
                table: "Tallas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TalCategoria",
                table: "Tallas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TalCintura",
                table: "Tallas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TalColombia",
                table: "Tallas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TalCuello",
                table: "Tallas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TalDescripcion",
                table: "Tallas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TalEU",
                table: "Tallas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TalLargo",
                table: "Tallas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TalLongitudManga",
                table: "Tallas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TalPecho",
                table: "Tallas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TalUS",
                table: "Tallas",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TalCadera",
                table: "Tallas");

            migrationBuilder.DropColumn(
                name: "TalCategoria",
                table: "Tallas");

            migrationBuilder.DropColumn(
                name: "TalCintura",
                table: "Tallas");

            migrationBuilder.DropColumn(
                name: "TalColombia",
                table: "Tallas");

            migrationBuilder.DropColumn(
                name: "TalCuello",
                table: "Tallas");

            migrationBuilder.DropColumn(
                name: "TalDescripcion",
                table: "Tallas");

            migrationBuilder.DropColumn(
                name: "TalEU",
                table: "Tallas");

            migrationBuilder.DropColumn(
                name: "TalLargo",
                table: "Tallas");

            migrationBuilder.DropColumn(
                name: "TalLongitudManga",
                table: "Tallas");

            migrationBuilder.DropColumn(
                name: "TalPecho",
                table: "Tallas");

            migrationBuilder.DropColumn(
                name: "TalUS",
                table: "Tallas");
        }
    }
}
