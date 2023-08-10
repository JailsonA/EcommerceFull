using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceFull.Migrations
{
    /// <inheritdoc />
    public partial class tabelasAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoritesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavoritesID);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solds",
                columns: table => new
                {
                    SoldID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solds", x => x.SoldID);
                    table.ForeignKey(
                        name: "FK_Solds_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart_Prods",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_Prods", x => new { x.CartID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_Cart_Prods_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Prods_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fav_Prods",
                columns: table => new
                {
                    FavoritesID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fav_Prods", x => new { x.ProductID, x.FavoritesID });
                    table.ForeignKey(
                        name: "FK_Fav_Prods_Favorites_FavoritesID",
                        column: x => x.FavoritesID,
                        principalTable: "Favorites",
                        principalColumn: "FavoritesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fav_Prods_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sold_Prods",
                columns: table => new
                {
                    SoldID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sold_Prods", x => new { x.SoldID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_Sold_Prods_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sold_Prods_Solds_SoldID",
                        column: x => x.SoldID,
                        principalTable: "Solds",
                        principalColumn: "SoldID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Prods_CartID",
                table: "Cart_Prods",
                column: "CartID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Prods_ProductID",
                table: "Cart_Prods",
                column: "ProductID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserID",
                table: "Carts",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fav_Prods_FavoritesID",
                table: "Fav_Prods",
                column: "FavoritesID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fav_Prods_ProductID",
                table: "Fav_Prods",
                column: "ProductID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserID",
                table: "Favorites",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Sold_Prods_ProductID",
                table: "Sold_Prods",
                column: "ProductID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sold_Prods_SoldID",
                table: "Sold_Prods",
                column: "SoldID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solds_UserID",
                table: "Solds",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart_Prods");

            migrationBuilder.DropTable(
                name: "Fav_Prods");

            migrationBuilder.DropTable(
                name: "Sold_Prods");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Solds");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
