using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiBackApi.Migrations
{
    public partial class KEKX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Root_RootId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ConvertedJsonOrder");

            migrationBuilder.DropTable(
                name: "Root");

            migrationBuilder.RenameColumn(
                name: "RootId",
                table: "Product",
                newName: "ConvertedOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_RootId",
                table: "Product",
                newName: "IX_Product_ConvertedOrderId");

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
                name: "PackageOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    JsonOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConvertedJsonOrderId = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageOrders_ConvertedOrder_ConvertedJsonOrderId",
                        column: x => x.ConvertedJsonOrderId,
                        principalTable: "ConvertedOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageOrders_ConvertedJsonOrderId",
                table: "PackageOrders",
                column: "ConvertedJsonOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ConvertedOrder_ConvertedOrderId",
                table: "Product",
                column: "ConvertedOrderId",
                principalTable: "ConvertedOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ConvertedOrder_ConvertedOrderId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "PackageOrders");

            migrationBuilder.DropTable(
                name: "ConvertedOrder");

            migrationBuilder.RenameColumn(
                name: "ConvertedOrderId",
                table: "Product",
                newName: "RootId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ConvertedOrderId",
                table: "Product",
                newName: "IX_Product_RootId");

            migrationBuilder.CreateTable(
                name: "Root",
                columns: table => new
                {
                    RootId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    orderNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Root", x => x.RootId);
                });

            migrationBuilder.CreateTable(
                name: "ConvertedJsonOrder",
                columns: table => new
                {
                    ConvertedJsonOrderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RootId = table.Column<int>(type: "int", nullable: true),
                    productid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvertedJsonOrder", x => x.ConvertedJsonOrderid);
                    table.ForeignKey(
                        name: "FK_ConvertedJsonOrder_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConvertedJsonOrder_Root_RootId",
                        column: x => x.RootId,
                        principalTable: "Root",
                        principalColumn: "RootId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConvertedJsonOrderid = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JsonOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    OrderType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_ConvertedJsonOrder_ConvertedJsonOrderid",
                        column: x => x.ConvertedJsonOrderid,
                        principalTable: "ConvertedJsonOrder",
                        principalColumn: "ConvertedJsonOrderid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConvertedJsonOrder_productid",
                table: "ConvertedJsonOrder",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_ConvertedJsonOrder_RootId",
                table: "ConvertedJsonOrder",
                column: "RootId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ConvertedJsonOrderid",
                table: "Orders",
                column: "ConvertedJsonOrderid");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Root_RootId",
                table: "Product",
                column: "RootId",
                principalTable: "Root",
                principalColumn: "RootId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
