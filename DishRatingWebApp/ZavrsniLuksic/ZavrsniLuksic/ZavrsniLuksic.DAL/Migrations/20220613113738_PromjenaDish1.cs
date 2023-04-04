using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZavrsniLuksic.DAL.Migrations
{
    public partial class PromjenaDish1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantID",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Spicinesses_SpicinessID",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "SpicinessID",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantID",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantID",
                table: "Dishes",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Spicinesses_SpicinessID",
                table: "Dishes",
                column: "SpicinessID",
                principalTable: "Spicinesses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantID",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Spicinesses_SpicinessID",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "SpicinessID",
                table: "Dishes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantID",
                table: "Dishes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantID",
                table: "Dishes",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Spicinesses_SpicinessID",
                table: "Dishes",
                column: "SpicinessID",
                principalTable: "Spicinesses",
                principalColumn: "ID");
        }
    }
}
