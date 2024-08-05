using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItems_Item_ItemId",
                table: "OrderedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItems_Order_OrderId",
                table: "OrderedItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderedItems",
                table: "OrderedItems");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Profit");

            migrationBuilder.DropColumn(
                name: "OrderTime",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "OrderedItems",
                newName: "Ordered_Items");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedItems_OrderId",
                table: "Ordered_Items",
                newName: "IX_Ordered_Items_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderedItems_ItemId",
                table: "Ordered_Items",
                newName: "IX_Ordered_Items_ItemId");

            migrationBuilder.AlterColumn<string>(
                name: "NID",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ordered_Items",
                table: "Ordered_Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordered_Items_Item_ItemId",
                table: "Ordered_Items",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordered_Items_Order_OrderId",
                table: "Ordered_Items",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordered_Items_Item_ItemId",
                table: "Ordered_Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordered_Items_Order_OrderId",
                table: "Ordered_Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ordered_Items",
                table: "Ordered_Items");

            migrationBuilder.RenameTable(
                name: "Ordered_Items",
                newName: "OrderedItems");

            migrationBuilder.RenameIndex(
                name: "IX_Ordered_Items_OrderId",
                table: "OrderedItems",
                newName: "IX_OrderedItems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Ordered_Items_ItemId",
                table: "OrderedItems",
                newName: "IX_OrderedItems_ItemId");

            migrationBuilder.AlterColumn<int>(
                name: "NID",
                table: "Staff",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Staff",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Profit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderTime",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderedItems",
                table: "OrderedItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItems_Item_ItemId",
                table: "OrderedItems",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItems_Order_OrderId",
                table: "OrderedItems",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
