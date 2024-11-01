using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SO_ITEM_SO_ORDER_SO_ORDER_ID",
                table: "SO_ITEM");

            migrationBuilder.DropForeignKey(
                name: "FK_SO_ORDER_COM_CUSTOMER_COM_CUSTOMER_ID",
                table: "SO_ORDER");

            migrationBuilder.DropIndex(
                name: "IX_SO_ORDER_COM_CUSTOMER_ID",
                table: "SO_ORDER");

            migrationBuilder.DropIndex(
                name: "IX_SO_ITEM_SO_ORDER_ID",
                table: "SO_ITEM");

            migrationBuilder.AddColumn<long>(
                name: "SOOrderSO_ORDER_ID",
                table: "SO_ITEM",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SO_ITEM_SOOrderSO_ORDER_ID",
                table: "SO_ITEM",
                column: "SOOrderSO_ORDER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SO_ITEM_SO_ORDER_SOOrderSO_ORDER_ID",
                table: "SO_ITEM",
                column: "SOOrderSO_ORDER_ID",
                principalTable: "SO_ORDER",
                principalColumn: "SO_ORDER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SO_ITEM_SO_ORDER_SOOrderSO_ORDER_ID",
                table: "SO_ITEM");

            migrationBuilder.DropIndex(
                name: "IX_SO_ITEM_SOOrderSO_ORDER_ID",
                table: "SO_ITEM");

            migrationBuilder.DropColumn(
                name: "SOOrderSO_ORDER_ID",
                table: "SO_ITEM");

            migrationBuilder.CreateIndex(
                name: "IX_SO_ORDER_COM_CUSTOMER_ID",
                table: "SO_ORDER",
                column: "COM_CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SO_ITEM_SO_ORDER_ID",
                table: "SO_ITEM",
                column: "SO_ORDER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SO_ITEM_SO_ORDER_SO_ORDER_ID",
                table: "SO_ITEM",
                column: "SO_ORDER_ID",
                principalTable: "SO_ORDER",
                principalColumn: "SO_ORDER_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SO_ORDER_COM_CUSTOMER_COM_CUSTOMER_ID",
                table: "SO_ORDER",
                column: "COM_CUSTOMER_ID",
                principalTable: "COM_CUSTOMER",
                principalColumn: "COM_CUSTOMER_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
