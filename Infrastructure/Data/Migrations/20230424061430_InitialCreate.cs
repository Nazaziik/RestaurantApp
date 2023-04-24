using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 400, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishProduct",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishProduct", x => new { x.DishesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_DishProduct_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Description", "Name", "PictureUrl", "Price", "Type" },
                values: new object[] { 1, "Some dish 0", "Sombrero", "zzz", 20.50m, 1 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Description", "Name", "PictureUrl", "Price", "Type" },
                values: new object[] { 2, "Some dish 1", "Mustangi", "xxx", 73.0m, 3 });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Description", "Name", "PictureUrl", "Price", "Type" },
                values: new object[] { 3, "Some dish 2", "Eleonore", "ccc", 2.0m, 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 1, "Fish", 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 2, "Milk", 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[] { 3, "Beef", 2 });

            migrationBuilder.InsertData(
                table: "DishProduct",
                columns: new[] { "DishesId", "ProductsId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "DishProduct",
                columns: new[] { "DishesId", "ProductsId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "DishProduct",
                columns: new[] { "DishesId", "ProductsId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "DishProduct",
                columns: new[] { "DishesId", "ProductsId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "DishProduct",
                columns: new[] { "DishesId", "ProductsId" },
                values: new object[] { 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_DishProduct_ProductsId",
                table: "DishProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishProduct");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
