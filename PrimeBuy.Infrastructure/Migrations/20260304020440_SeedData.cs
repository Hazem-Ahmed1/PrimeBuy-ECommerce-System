using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrimeBuy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "u1", 0, "u1", "john.doe@email.com", true, "John", "Doe", true, null, "Michael", "JOHN.DOE@EMAIL.COM", "JOHN.DOE@EMAIL.COM", "AQAAAAIAAYagAAAAELPKE2rRSojBxPzOOWBBBPczaOLosox3P4A2XNpNTCbU5hbPO3QHfbAKwXzaFTBRwA==", null, false, "u1", false, "john.doe@email.com" },
                    { "u10", 0, "u10", "sophia.martinez@email.com", true, "Sophia", "Martinez", true, null, "Anne", "SOPHIA.MARTINEZ@EMAIL.COM", "SOPHIA.MARTINEZ@EMAIL.COM", "AQAAAAIAAYagAAAAELPKE2rRSojBxPzOOWBBBPczaOLosox3P4A2XNpNTCbU5hbPO3QHfbAKwXzaFTBRwA==", null, false, "u10", false, "sophia.martinez@email.com" },
                    { "u2", 0, "u2", "jane.smith@email.com", true, "Jane", "Smith", true, null, "Marie", "JANE.SMITH@EMAIL.COM", "JANE.SMITH@EMAIL.COM", "AQAAAAIAAYagAAAAELPKE2rRSojBxPzOOWBBBPczaOLosox3P4A2XNpNTCbU5hbPO3QHfbAKwXzaFTBRwA==", null, false, "u2", false, "jane.smith@email.com" },
                    { "u3", 0, "u3", "ahmed.hassan@email.com", true, "Ahmed", "Hassan", true, null, "Ali", "AHMED.HASSAN@EMAIL.COM", "AHMED.HASSAN@EMAIL.COM", "AQAAAAIAAYagAAAAELPKE2rRSojBxPzOOWBBBPczaOLosox3P4A2XNpNTCbU5hbPO3QHfbAKwXzaFTBRwA==", null, false, "u3", false, "ahmed.hassan@email.com" },
                    { "u4", 0, "u4", "maria.garcia@email.com", true, "Maria", "Garcia", true, null, "Elena", "MARIA.GARCIA@EMAIL.COM", "MARIA.GARCIA@EMAIL.COM", "AQAAAAIAAYagAAAAELPKE2rRSojBxPzOOWBBBPczaOLosox3P4A2XNpNTCbU5hbPO3QHfbAKwXzaFTBRwA==", null, false, "u4", false, "maria.garcia@email.com" },
                    { "u5", 0, "u5", "james.wilson@email.com", true, "James", "Wilson", true, null, "Robert", "JAMES.WILSON@EMAIL.COM", "JAMES.WILSON@EMAIL.COM", "AQAAAAIAAYagAAAAELPKE2rRSojBxPzOOWBBBPczaOLosox3P4A2XNpNTCbU5hbPO3QHfbAKwXzaFTBRwA==", null, false, "u5", false, "james.wilson@email.com" },
                    { "u6", 0, "u6", "sara.johnson@email.com", true, "Sara", "Johnson", true, null, "Lynn", "SARA.JOHNSON@EMAIL.COM", "SARA.JOHNSON@EMAIL.COM", "AQAAAAIAAYagAAAAELPKE2rRSojBxPzOOWBBBPczaOLosox3P4A2XNpNTCbU5hbPO3QHfbAKwXzaFTBRwA==", null, false, "u6", false, "sara.johnson@email.com" },
                    { "u7", 0, "u7", "omar.khaled@email.com", true, "Omar", "Ibrahim", true, null, "Khaled", "OMAR.KHALED@EMAIL.COM", "OMAR.KHALED@EMAIL.COM", "AQAAAAIAAYagAAAAELPKE2rRSojBxPzOOWBBBPczaOLosox3P4A2XNpNTCbU5hbPO3QHfbAKwXzaFTBRwA==", null, false, "u7", false, "omar.khaled@email.com" },
                    { "u8", 0, "u8", "emily.brown@email.com", true, "Emily", "Brown", true, null, "Rose", "EMILY.BROWN@EMAIL.COM", "EMILY.BROWN@EMAIL.COM", "AQAAAAIAAYagAAAAELPKE2rRSojBxPzOOWBBBPczaOLosox3P4A2XNpNTCbU5hbPO3QHfbAKwXzaFTBRwA==", null, false, "u8", false, "emily.brown@email.com" },
                    { "u9", 0, "u9", "david.lee@email.com", true, "David", "Lee", true, null, "James", "DAVID.LEE@EMAIL.COM", "DAVID.LEE@EMAIL.COM", "AQAAAAIAAYagAAAAELPKE2rRSojBxPzOOWBBBPczaOLosox3P4A2XNpNTCbU5hbPO3QHfbAKwXzaFTBRwA==", null, false, "u9", false, "david.lee@email.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryImage", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "/images/categories/electronics.jpg", "Electronics", null },
                    { 2, "/images/categories/clothing.jpg", "Clothing", null },
                    { 3, "/images/categories/home-kitchen.jpg", "Home & Kitchen", null },
                    { 4, "/images/categories/books.jpg", "Books", null },
                    { 5, "/images/categories/sports.jpg", "Sports", null },
                    { 6, "/images/categories/beauty.jpg", "Beauty", null },
                    { 7, "/images/categories/toys.jpg", "Toys & Games", null },
                    { 8, "/images/categories/automotive.jpg", "Automotive", null },
                    { 9, "/images/categories/garden.jpg", "Garden", null },
                    { 10, "/images/categories/health.jpg", "Health", null }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "ApplicationUserId", "City", "Country", "IsDefault", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "u1", "New York", "United States", true, "350 Fifth Avenue", "10118" },
                    { 2, "u1", "Brooklyn", "United States", false, "123 Atlantic Avenue", "11201" },
                    { 3, "u2", "Los Angeles", "United States", true, "6801 Hollywood Blvd", "90028" },
                    { 4, "u2", "Santa Monica", "United States", false, "401 Wilshire Blvd", "90401" },
                    { 5, "u3", "Cairo", "Egypt", true, "12 Tahrir Square", "11511" },
                    { 6, "u3", "Alexandria", "Egypt", false, "45 Corniche Road", "21599" },
                    { 7, "u4", "Madrid", "Spain", true, "Gran Vía 28", "28013" },
                    { 8, "u4", "Barcelona", "Spain", false, "La Rambla 91", "08001" },
                    { 9, "u5", "London", "United Kingdom", true, "221B Baker Street", "NW16XE" },
                    { 10, "u5", "Manchester", "United Kingdom", false, "10 Deansgate", "M32BQ" },
                    { 11, "u6", "Chicago", "United States", true, "875 N Michigan Avenue", "60611" },
                    { 12, "u6", "Evanston", "United States", false, "1600 Sherman Avenue", "60201" },
                    { 13, "u7", "Dubai", "UAE", true, "Sheikh Zayed Road Tower 3", "00000" },
                    { 14, "u7", "Abu Dhabi", "UAE", false, "Corniche Road West 15", "00000" },
                    { 15, "u8", "Toronto", "Canada", true, "290 Bremner Blvd", "M5V3L9" },
                    { 16, "u8", "Vancouver", "Canada", false, "1055 Canada Place", "V6C0C3" },
                    { 17, "u9", "Sydney", "Australia", true, "1 Macquarie Street", "2000" },
                    { 18, "u9", "Melbourne", "Australia", false, "100 St Kilda Road", "3004" },
                    { 19, "u10", "Berlin", "Germany", true, "Friedrichstraße 43", "10117" },
                    { 20, "u10", "Munich", "Germany", false, "Marienplatz 8", "80331" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryImage", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 11, "/images/categories/smartphones.jpg", "Smartphones", 1 },
                    { 12, "/images/categories/laptops.jpg", "Laptops", 1 },
                    { 13, "/images/categories/mens-clothing.jpg", "Men's Clothing", 2 },
                    { 14, "/images/categories/womens-clothing.jpg", "Women's Clothing", 2 },
                    { 15, "/images/categories/cookware.jpg", "Cookware", 3 },
                    { 16, "/images/categories/fiction.jpg", "Fiction", 4 },
                    { 17, "/images/categories/running.jpg", "Running", 5 },
                    { 18, "/images/categories/skincare.jpg", "Skincare", 6 },
                    { 19, "/images/categories/action-figures.jpg", "Action Figures", 7 },
                    { 20, "/images/categories/car-accessories.jpg", "Car Accessories", 8 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsActive", "Name", "Price", "ProductImage", "SKU", "StockQuantity" },
                values: new object[,]
                {
                    { 19, 9, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Fiskars Garden Tool Set", 34.99m, "/images/products/fiskars-tools.jpg", "GRD-1201", 70 },
                    { 20, 10, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Vitamin D3 5000 IU Supplement", 14.99m, "/images/products/vitamin-d3.jpg", "HLT-1301", 500 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "ApplicationUserId", "OrderDate", "OrderNumber", "ShippingAddressId", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, "u1", new DateTime(2026, 1, 20, 14, 30, 0, 0, DateTimeKind.Utc), "ABCDEFGH", 1, 4, 1369.49m },
                    { 2, "u1", new DateTime(2026, 1, 22, 9, 15, 0, 0, DateTimeKind.Utc), "BCDEFGHI", 2, 4, 1234.50m },
                    { 3, "u2", new DateTime(2026, 1, 25, 16, 0, 0, 0, DateTimeKind.Utc), "CDEFGHIJ", 3, 3, 1549.99m },
                    { 4, "u2", new DateTime(2026, 1, 28, 11, 45, 0, 0, DateTimeKind.Utc), "DEFGHIJK", 4, 2, 225.40m },
                    { 5, "u3", new DateTime(2026, 2, 1, 8, 30, 0, 0, DateTimeKind.Utc), "EFGHIJKL", 5, 4, 1199.00m },
                    { 6, "u3", new DateTime(2026, 2, 3, 13, 20, 0, 0, DateTimeKind.Utc), "FGHIJKLM", 6, 3, 104.89m },
                    { 7, "u4", new DateTime(2026, 2, 5, 17, 10, 0, 0, DateTimeKind.Utc), "GHIJKLMN", 7, 1, 379.98m },
                    { 8, "u4", new DateTime(2026, 2, 7, 10, 0, 0, 0, DateTimeKind.Utc), "HIJKLMNO", 8, 4, 539.98m },
                    { 9, "u5", new DateTime(2026, 2, 10, 15, 30, 0, 0, DateTimeKind.Utc), "IJKLMNOP", 9, 2, 31.48m },
                    { 10, "u5", new DateTime(2026, 2, 12, 9, 45, 0, 0, DateTimeKind.Utc), "JKLMNOPQ", 10, 3, 349.99m },
                    { 11, "u6", new DateTime(2026, 2, 14, 12, 0, 0, 0, DateTimeKind.Utc), "KLMNOPQR", 11, 4, 134.89m },
                    { 12, "u6", new DateTime(2026, 2, 15, 8, 10, 0, 0, DateTimeKind.Utc), "LMNOPQRS", 12, 5, 169.99m },
                    { 13, "u7", new DateTime(2026, 2, 18, 14, 20, 0, 0, DateTimeKind.Utc), "MNOPQRST", 13, 1, 1299.99m },
                    { 14, "u7", new DateTime(2026, 2, 20, 16, 30, 0, 0, DateTimeKind.Utc), "NOPQRSTU", 14, 2, 59.98m },
                    { 15, "u8", new DateTime(2026, 2, 22, 11, 0, 0, 0, DateTimeKind.Utc), "OPQRSTUV", 15, 4, 1299.00m },
                    { 16, "u8", new DateTime(2026, 2, 24, 10, 15, 0, 0, DateTimeKind.Utc), "PQRSTUVW", 16, 3, 69.98m },
                    { 17, "u9", new DateTime(2026, 2, 26, 9, 0, 0, 0, DateTimeKind.Utc), "QRSTUVWX", 17, 1, 190.00m },
                    { 18, "u9", new DateTime(2026, 2, 28, 13, 45, 0, 0, DateTimeKind.Utc), "RSTUVWXY", 18, 4, 64.98m },
                    { 19, "u10", new DateTime(2026, 3, 1, 15, 30, 0, 0, DateTimeKind.Utc), "STUVWXYZ", 19, 2, 194.98m },
                    { 20, "u10", new DateTime(2026, 3, 3, 8, 0, 0, 0, DateTimeKind.Utc), "TUVWXYZA", 20, 3, 29.99m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsActive", "Name", "Price", "ProductImage", "SKU", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 11, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Samsung Galaxy S25 Ultra", 1299.99m, "/images/products/galaxy-s25.jpg", "ELC-1001", 50 },
                    { 2, 11, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Apple iPhone 16 Pro", 1199.00m, "/images/products/iphone-16-pro.jpg", "ELC-1002", 75 },
                    { 3, 12, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Dell XPS 15 Laptop", 1549.99m, "/images/products/dell-xps-15.jpg", "ELC-2001", 30 },
                    { 4, 12, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "MacBook Air M4", 1299.00m, "/images/products/macbook-air-m4.jpg", "ELC-2002", 40 },
                    { 5, 13, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Levi's 501 Original Jeans", 69.50m, "/images/products/levis-501.jpg", "CLT-3001", 200 },
                    { 6, 13, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Nike Dri-FIT Running Shirt", 35.00m, "/images/products/nike-drifit.jpg", "CLT-3002", 150 },
                    { 7, 14, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Zara Midi Satin Dress", 89.90m, "/images/products/zara-satin-dress.jpg", "CLT-4001", 80 },
                    { 8, 17, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Adidas Ultraboost Light", 190.00m, "/images/products/adidas-ultraboost.jpg", "SPR-5001", 120 },
                    { 9, 15, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Lodge Cast Iron Skillet 12\"", 44.90m, "/images/products/lodge-skillet.jpg", "HMK-6001", 90 },
                    { 10, 15, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Instant Pot Duo 7-in-1", 89.99m, "/images/products/instant-pot.jpg", "HMK-6002", 60 },
                    { 11, 16, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Atomic Habits by James Clear", 18.99m, "/images/products/atomic-habits.jpg", "BOK-7001", 300 },
                    { 12, 16, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "The Great Gatsby", 12.49m, "/images/products/great-gatsby.jpg", "BOK-7002", 250 },
                    { 13, 18, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "CeraVe Moisturizing Cream", 16.99m, "/images/products/cerave-cream.jpg", "BTY-8001", 400 },
                    { 14, 18, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "The Ordinary Niacinamide Serum", 11.90m, "/images/products/ordinary-serum.jpg", "BTY-8002", 350 },
                    { 15, 19, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "LEGO Star Wars Millennium Falcon", 169.99m, "/images/products/lego-falcon.jpg", "TOY-9001", 45 },
                    { 16, 19, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Marvel Legends Spider-Man", 24.99m, "/images/products/marvel-spiderman.jpg", "TOY-9002", 180 },
                    { 17, 20, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Armor All Car Cleaning Kit", 29.99m, "/images/products/armorall-kit.jpg", "AUT-1101", 100 },
                    { 18, 17, new DateTime(2026, 1, 15, 10, 0, 0, 0, DateTimeKind.Utc), true, "Garmin Forerunner 265 Watch", 349.99m, "/images/products/garmin-265.jpg", "SPR-5002", 55 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1299.99m },
                    { 2, 1, 5, 1, 69.50m },
                    { 3, 2, 6, 5, 35.00m },
                    { 4, 2, 9, 1, 44.90m },
                    { 5, 3, 3, 1, 1549.99m },
                    { 6, 3, 20, 0, 14.99m },
                    { 7, 4, 7, 1, 89.90m },
                    { 8, 4, 6, 2, 35.00m },
                    { 9, 5, 2, 1, 1199.00m },
                    { 10, 5, 14, 0, 11.90m },
                    { 11, 6, 10, 1, 89.99m },
                    { 12, 6, 20, 1, 14.99m },
                    { 13, 7, 8, 2, 190.00m },
                    { 14, 7, 13, 0, 16.99m },
                    { 15, 8, 18, 1, 349.99m },
                    { 16, 8, 8, 1, 190.00m },
                    { 17, 9, 11, 1, 18.99m },
                    { 18, 9, 12, 1, 12.49m },
                    { 19, 10, 18, 1, 349.99m },
                    { 20, 10, 20, 0, 14.99m },
                    { 21, 11, 13, 3, 16.99m },
                    { 22, 11, 14, 3, 11.90m },
                    { 23, 12, 15, 1, 169.99m },
                    { 24, 12, 16, 0, 24.99m },
                    { 25, 13, 1, 1, 1299.99m },
                    { 26, 13, 13, 0, 16.99m },
                    { 27, 14, 19, 1, 34.99m },
                    { 28, 14, 16, 1, 24.99m },
                    { 29, 15, 4, 1, 1299.00m },
                    { 30, 15, 11, 0, 18.99m },
                    { 31, 16, 5, 1, 69.50m },
                    { 32, 16, 6, 1, 35.00m },
                    { 33, 17, 8, 1, 190.00m },
                    { 34, 17, 12, 0, 12.49m },
                    { 35, 18, 19, 1, 34.99m },
                    { 36, 18, 17, 1, 29.99m },
                    { 37, 19, 15, 1, 169.99m },
                    { 38, 19, 16, 1, 24.99m },
                    { 39, 20, 17, 1, 29.99m },
                    { 40, 20, 14, 0, 11.90m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u10");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "u9");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
