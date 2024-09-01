using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class Restaurantid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestaurantID",
                table: "Hall",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hall_RestaurantID",
                table: "Hall",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hall_Restaurant_RestaurantID",
                table: "Hall",
                column: "RestaurantID",
                principalTable: "Restaurant",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hall_Restaurant_RestaurantID",
                table: "Hall");

            migrationBuilder.DropIndex(
                name: "IX_Hall_RestaurantID",
                table: "Hall");

            migrationBuilder.DropColumn(
                name: "RestaurantID",
                table: "Hall");
        }
    }
}
