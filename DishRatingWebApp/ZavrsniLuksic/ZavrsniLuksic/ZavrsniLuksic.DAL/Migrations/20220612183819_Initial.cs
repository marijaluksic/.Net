using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZavrsniLuksic.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Spicinesses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spicinesses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CuisineID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Restaurants_Cuisines_CuisineID",
                        column: x => x.CuisineID,
                        principalTable: "Cuisines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: true),
                    SpicinessID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dishes_Restaurants_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurants",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Dishes_Spicinesses_SpicinessID",
                        column: x => x.SpicinessID,
                        principalTable: "Spicinesses",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Talijanska" },
                    { 2, "Meksička" },
                    { 3, "Francuska" },
                    { 4, "Japanska" },
                    { 5, "Kineska" },
                    { 6, "Španjolska" },
                    { 7, "Etiopska" }
                });

            migrationBuilder.InsertData(
                table: "Spicinesses",
                columns: new[] { "ID", "Level" },
                values: new object[,]
                {
                    { 1, "Nije ni posoljeno" },
                    { 2, "Prstohvat cimeta mi je doseg" },
                    { 3, "Pikantno" },
                    { 4, "Neki to vole vruće" },
                    { 5, "Eh, da je Dante samo znao za tebe..." }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "ID", "Address", "CuisineID", "Name", "PhoneNumber", "Url" },
                values: new object[] { 1, "Gajeva 9, Zagreb", 1, "Boban", "4811549", "http://www.boban.hr/home" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "ID", "Address", "CuisineID", "Name", "PhoneNumber", "Url" },
                values: new object[] { 2, "Savska cesta 154, Zagreb", 2, "Mex Cantina", "6192156", "https://mexcantina.eatbu.hr/?lang=hr" });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "ID", "Description", "Name", "Price", "RestaurantID", "SpicinessID" },
                values: new object[,]
                {
                    { 1, "Lazanje sa umakom od mljevenog mesa dinstanog na luku, češnjaku, rajčicama te maslinovom ulju sa začinima.", "Lasagne Bolognese", "78", 1, 1 },
                    { 2, "Šnite bifteka s pečenim krumpirom, rukolom, crvenim radičem i cherry rajčicama.", "Rustica", "158", 1, 2 },
                    { 3, "Zapečeni kaktus s grahom i Jalapeno paprikom.", "Nopalitos con frijoles", "55", 2, 4 },
                    { 4, "Piletina u umaku od kakaa, gljive i 20 vrsta začina.", "Pollo con mole poblano", "100", 2, 3 },
                    { 5, "Pileća krilca u marinadi od chilija.", "Alitas de pollo en chili", "80", 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RestaurantID",
                table: "Dishes",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_SpicinessID",
                table: "Dishes",
                column: "SpicinessID");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CuisineID",
                table: "Restaurants",
                column: "CuisineID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Spicinesses");

            migrationBuilder.DropTable(
                name: "Cuisines");
        }
    }
}
