using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class storageanditem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageRoom_Item_ItemId",
                table: "StorageRoom");

            migrationBuilder.DropIndex(
                name: "IX_StorageRoom_ItemId",
                table: "StorageRoom");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "StorageRoom");

            migrationBuilder.AddColumn<string>(
                name: "StorageID",
                table: "Item",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_StorageID",
                table: "Item",
                column: "StorageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_StorageRoom_StorageID",
                table: "Item",
                column: "StorageID",
                principalTable: "StorageRoom",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_StorageRoom_StorageID",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_StorageID",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "StorageID",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "ItemId",
                table: "StorageRoom",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StorageRoom_ItemId",
                table: "StorageRoom",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageRoom_Item_ItemId",
                table: "StorageRoom",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
