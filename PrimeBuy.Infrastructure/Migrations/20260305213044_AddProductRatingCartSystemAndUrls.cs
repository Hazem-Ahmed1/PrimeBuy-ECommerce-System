using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrimeBuy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProductRatingCartSystemAndUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductImage",
                table: "Products",
                newName: "ProductImageUrl");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "u1", new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), null },
                    { 2, "u2", new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), null },
                    { 3, "u3", new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), null },
                    { 4, "u4", new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), null },
                    { 5, "u5", new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), null },
                    { 6, "u6", new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), null },
                    { 7, "u7", new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), null },
                    { 8, "u8", new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), null },
                    { 9, "u9", new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), null },
                    { 10, "u10", new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1498049794561-7780e7231661?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1445205170230-053b83016050?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1556185781-a47769abb7aa?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1596462502278-27bfdc403348?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1596461404969-9ae70f2830c1?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1449965408869-eaa3f722e40d?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1416879595882-3373a0480b5b?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1559757175-0eb30cd8c063?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1503341504253-dff4815485f1?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1566479179817-c0cf9a5d7d1f?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1556909114-f6e7ad7d3136?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1544947950-fa07a98d237f?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1556228453-efd6c1ff04f6?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1608889825103-eb5ed706fc64?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CategoryImage",
                value: "https://images.unsplash.com/photo-1483653364400-eedcfb9f1f88?w=300&h=200&fit=crop");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?w=400&h=400&fit=crop", 4.5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1592899677977-9c10ca588bbd?w=400&h=400&fit=crop", 4.7999999999999998 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=400&h=400&fit=crop", 4.5999999999999996 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=400&h=400&fit=crop", 4.9000000000000004 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1551698618-1dfe5d97d256?w=400&h=400&fit=crop", 4.2000000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1503341504253-dff4815485f1?w=400&h=400&fit=crop", 4.2999999999999998 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1566479179817-c0cf9a5d7d1f?w=400&h=400&fit=crop", 4.0999999999999996 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=400&h=400&fit=crop", 4.4000000000000004 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1556909114-f6e7ad7d3136?w=400&h=400&fit=crop", 4.7000000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1574781330855-d0db0775562a?w=400&h=400&fit=crop", 4.5 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=400&h=400&fit=crop", 4.7999999999999998 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1544947950-fa07a98d237f?w=400&h=400&fit=crop", 4.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1556228453-efd6c1ff04f6?w=400&h=400&fit=crop", 4.5999999999999996 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1620916566398-39f1143ab7be?w=400&h=400&fit=crop", 4.2999999999999998 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1587654780291-39c9404d746b?w=400&h=400&fit=crop", 4.9000000000000004 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1608889825103-eb5ed706fc64?w=400&h=400&fit=crop", 4.4000000000000004 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1449965408869-eaa3f722e40d?w=400&h=400&fit=crop", 4.2000000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1508685096489-7aacd43bd3b1?w=400&h=400&fit=crop", 4.7000000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1416879595882-3373a0480b5b?w=400&h=400&fit=crop", 4.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ProductImageUrl", "Rating" },
                values: new object[] { "https://images.unsplash.com/photo-1559757175-0eb30cd8c063?w=400&h=400&fit=crop", 4.0999999999999996 });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "CreatedAt", "ProductId", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), 2, 1, null },
                    { 2, 1, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), 6, 2, null },
                    { 3, 2, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), 4, 1, null },
                    { 4, 3, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), 8, 1, null },
                    { 5, 3, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), 11, 1, null },
                    { 6, 5, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), 5, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ApplicationUserId",
                table: "Carts",
                column: "ApplicationUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductImageUrl",
                table: "Products",
                newName: "ProductImage");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryImage",
                value: "/images/categories/electronics.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryImage",
                value: "/images/categories/clothing.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryImage",
                value: "/images/categories/home-kitchen.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CategoryImage",
                value: "/images/categories/books.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CategoryImage",
                value: "/images/categories/sports.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CategoryImage",
                value: "/images/categories/beauty.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CategoryImage",
                value: "/images/categories/toys.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CategoryImage",
                value: "/images/categories/automotive.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CategoryImage",
                value: "/images/categories/garden.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CategoryImage",
                value: "/images/categories/health.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "CategoryImage",
                value: "/images/categories/smartphones.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "CategoryImage",
                value: "/images/categories/laptops.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                column: "CategoryImage",
                value: "/images/categories/mens-clothing.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                column: "CategoryImage",
                value: "/images/categories/womens-clothing.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                column: "CategoryImage",
                value: "/images/categories/cookware.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                column: "CategoryImage",
                value: "/images/categories/fiction.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                column: "CategoryImage",
                value: "/images/categories/running.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                column: "CategoryImage",
                value: "/images/categories/skincare.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                column: "CategoryImage",
                value: "/images/categories/action-figures.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                column: "CategoryImage",
                value: "/images/categories/car-accessories.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductImage",
                value: "/images/products/galaxy-s25.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductImage",
                value: "/images/products/iphone-16-pro.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductImage",
                value: "/images/products/dell-xps-15.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductImage",
                value: "/images/products/macbook-air-m4.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProductImage",
                value: "/images/products/levis-501.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductImage",
                value: "/images/products/nike-drifit.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProductImage",
                value: "/images/products/zara-satin-dress.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProductImage",
                value: "/images/products/adidas-ultraboost.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProductImage",
                value: "/images/products/lodge-skillet.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProductImage",
                value: "/images/products/instant-pot.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProductImage",
                value: "/images/products/atomic-habits.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProductImage",
                value: "/images/products/great-gatsby.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ProductImage",
                value: "/images/products/cerave-cream.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ProductImage",
                value: "/images/products/ordinary-serum.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ProductImage",
                value: "/images/products/lego-falcon.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "ProductImage",
                value: "/images/products/marvel-spiderman.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "ProductImage",
                value: "/images/products/armorall-kit.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "ProductImage",
                value: "/images/products/garmin-265.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "ProductImage",
                value: "/images/products/fiskars-tools.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "ProductImage",
                value: "/images/products/vitamin-d3.jpg");
        }
    }
}
