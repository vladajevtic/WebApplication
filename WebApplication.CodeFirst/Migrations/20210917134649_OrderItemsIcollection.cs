using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.CodeFirst.Migrations
{
    public partial class OrderItemsIcollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderItem_OrderItemOrderId_OrderItemProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderItemOrderId_OrderItemProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderItemOrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderItemProductId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderItemOrderId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderItemProductId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItemOrderId_OrderItemProductId",
                table: "Orders",
                columns: new[] { "OrderItemOrderId", "OrderItemProductId" },
                unique: true,
                filter: "[OrderItemOrderId] IS NOT NULL AND [OrderItemProductId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderItem_OrderItemOrderId_OrderItemProductId",
                table: "Orders",
                columns: new[] { "OrderItemOrderId", "OrderItemProductId" },
                principalTable: "OrderItem",
                principalColumns: new[] { "OrderId", "ProductId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
