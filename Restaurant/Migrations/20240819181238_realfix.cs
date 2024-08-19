using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class realfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hall_Restaurant_RestaurantId",
                table: "Hall");

            migrationBuilder.DropIndex(
                name: "IX_Hall_RestaurantId",
                table: "Hall");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Hall");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestaurantId",
                table: "Hall",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hall_RestaurantId",
                table: "Hall",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hall_Restaurant_RestaurantId",
                table: "Hall",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id");
        }
    }
}
