using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.DataAccess.Persistence.Migrations
{
    public partial class SampleMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attribute_Products_ProductId",
                table: "Attribute");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Attribute",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Attribute_Products_ProductId",
                table: "Attribute",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attribute_Products_ProductId",
                table: "Attribute");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Attribute",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attribute_Products_ProductId",
                table: "Attribute",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
