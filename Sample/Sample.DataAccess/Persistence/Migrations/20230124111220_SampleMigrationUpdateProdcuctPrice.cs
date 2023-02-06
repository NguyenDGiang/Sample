using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.DataAccess.Persistence.Migrations
{
    public partial class SampleMigrationUpdateProdcuctPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProductVariant",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductVariant");
        }
    }
}
