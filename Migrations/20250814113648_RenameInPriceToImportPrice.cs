using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaishenManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameInPriceToImportPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "SellPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "ImportPrice",
                table: "Products",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductTypeid",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTypeid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SellPrice",
                table: "Products",
                newName: "Price");

            migrationBuilder.AddColumn<decimal>(
                name: "InPrice",
                table: "Products",
                type: "numeric",
                nullable: true);
        }
    }
}
