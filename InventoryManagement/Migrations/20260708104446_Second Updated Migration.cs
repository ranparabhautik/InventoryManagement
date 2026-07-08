using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class SecondUpdatedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WareHouseId",
                table: "Purchase_Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Order_WareHouseId",
                table: "Purchase_Order",
                column: "WareHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Order_WareHouse_WareHouseId",
                table: "Purchase_Order",
                column: "WareHouseId",
                principalTable: "WareHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Order_WareHouse_WareHouseId",
                table: "Purchase_Order");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_Order_WareHouseId",
                table: "Purchase_Order");

            migrationBuilder.DropColumn(
                name: "WareHouseId",
                table: "Purchase_Order");
        }
    }
}
