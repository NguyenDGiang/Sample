using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.DataAccess.Persistence.Migrations
{
    public partial class ProductUpdateQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ProductVariant",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ProductVariant",
                newName: "Price");
        }
    }
}
