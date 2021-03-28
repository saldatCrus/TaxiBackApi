using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiBackApi.Migrations
{
    public partial class KEKG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageOrders_ConvertedOrder_ConvertedJsonOrderId",
                table: "PackageOrders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ConvertedOrder");

            migrationBuilder.DropIndex(
                name: "IX_PackageOrders_ConvertedJsonOrderId",
                table: "PackageOrders");

            migrationBuilder.DropColumn(
                name: "ConvertedJsonOrderId",
                table: "PackageOrders");

            migrationBuilder.AddColumn<string>(
                name: "ConvertedJsonOrder",
                table: "PackageOrders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConvertedJsonOrder",
                table: "PackageOrders");

            migrationBuilder.AddColumn<int>(
                name: "ConvertedJsonOrderId",
                table: "PackageOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConvertedOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvertedOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConvertedOrderId = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discountAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paidPrice = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    remoteCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitPrice = table.Column<int>(type: "int", nullable: false),
                    vatPercentage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_ConvertedOrder_ConvertedOrderId",
                        column: x => x.ConvertedOrderId,
                        principalTable: "ConvertedOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageOrders_ConvertedJsonOrderId",
                table: "PackageOrders",
                column: "ConvertedJsonOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ConvertedOrderId",
                table: "Product",
                column: "ConvertedOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageOrders_ConvertedOrder_ConvertedJsonOrderId",
                table: "PackageOrders",
                column: "ConvertedJsonOrderId",
                principalTable: "ConvertedOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
