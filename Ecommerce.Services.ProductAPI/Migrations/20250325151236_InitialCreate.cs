using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Collection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hot = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    New = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.VariantId);
                    table.ForeignKey(
                        name: "FK_Variants_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Variants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "Category", "Collection", "Description", "Discount", "Hot", "New", "Price", "Rating", "Stock", "Tags", "Title" },
                values: new object[,]
                {
                    { 1, "Nike", "Shoes", "[\"SPORT\",\"NEW\"]", "Koşu için ideal, hafif ve rahat spor ayakkabı.", 10, true, true, 120.0, 4.7999999999999998, 15, "[\"running\",\"nike\",\"sport\",\"black\",\"white\"]", "Nike Air Zoom Pegasus 39" },
                    { 2, "Adidas", "Shoes", "[\"RUNNING\",\"NEW ARRIVALS\"]", "Boost taban teknolojisi ile ekstra konfor sunan ayakkabı.", 15, false, true, 180.0, 4.7000000000000002, 10, "[\"running\",\"adidas\",\"boost\",\"gray\",\"blue\"]", "Adidas Ultraboost 22" },
                    { 3, "Under Armour", "Clothing", "[\"TRAINING\",\"CASUAL\"]", "Günlük kullanım ve spor aktiviteleri için ideal tişört.", 0, false, false, 35.0, 4.5, 20, "[\"tshirt\",\"underarmour\",\"black\",\"blue\",\"s\",\"m\",\"l\"]", "Under Armour Sportstyle T-Shirt" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "Alt", "ProductId", "Src" },
                values: new object[,]
                {
                    { 1, "Black Nike Shoe", 1, "1.png" },
                    { 2, "White Nike Shoe", 1, "2.png" },
                    { 3, "Gray Adidas Shoe", 2, "3.png" },
                    { 4, "Blue Adidas Shoe", 2, "4.png" },
                    { 5, "Black T-Shirt", 3, "5.png" }
                });

            migrationBuilder.InsertData(
                table: "Variants",
                columns: new[] { "VariantId", "Color", "ImageId", "ProductId", "Size", "Sku" },
                values: new object[,]
                {
                    { 1, "Black", 1, 1, "42", "NK-PEG39-BLK" },
                    { 2, "White", 2, 1, "44", "NK-PEG39-WHT" },
                    { 3, "Gray", 3, 2, "40", "AD-UB22-GRY" },
                    { 4, "Blue", 4, 2, "42", "AD-UB22-BLU" },
                    { 5, "Black", 5, 3, "M", "UA-TSHRT-BLK" },
                    { 6, "Black", 5, 3, "L", "UA-TSHRT-BLK" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ImageId",
                table: "Variants",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductId",
                table: "Variants",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
