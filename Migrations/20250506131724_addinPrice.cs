using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaishenManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class addinPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "InPrice",
                table: "Products",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InPrice",
                table: "Products");
        }
    }
}
