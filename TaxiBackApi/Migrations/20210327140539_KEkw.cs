using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiBackApi.Migrations
{
    public partial class KEkw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConvertedJsonOrder",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "ConvertedJsonOrderid",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Root",
                columns: table => new
                {
                    RootId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderNumber = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Root", x => x.RootId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    paidPrice = table.Column<int>(type: "int", nullable: false),
                    unitPrice = table.Column<int>(type: "int", nullable: false),
                    remoteCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vatPercentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discountAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Root_RootId",
                        column: x => x.RootId,
                        principalTable: "Root",
                        principalColumn: "RootId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConvertedJsonOrder",
                columns: table => new
                {
                    ConvertedJsonOrderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productid = table.Column<int>(type: "int", nullable: true),
                    RootId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ConvertedJsonOrderid",
                table: "Orders",
                column: "ConvertedJsonOrderid");

            migrationBuilder.CreateIndex(
                name: "IX_ConvertedJsonOrder_productid",
                table: "ConvertedJsonOrder",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_ConvertedJsonOrder_RootId",
                table: "ConvertedJsonOrder",
                column: "RootId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_RootId",
                table: "Product",
                column: "RootId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ConvertedJsonOrder_ConvertedJsonOrderid",
                table: "Orders",
                column: "ConvertedJsonOrderid",
                principalTable: "ConvertedJsonOrder",
                principalColumn: "ConvertedJsonOrderid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ConvertedJsonOrder_ConvertedJsonOrderid",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "ConvertedJsonOrder");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Root");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ConvertedJsonOrderid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ConvertedJsonOrderid",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "ConvertedJsonOrder",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
