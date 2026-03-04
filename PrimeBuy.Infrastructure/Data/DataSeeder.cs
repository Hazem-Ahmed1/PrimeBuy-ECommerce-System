using Microsoft.EntityFrameworkCore;
using PrimeBuy.Domain.Enums;
using PrimeBuy.Domain.Models;

namespace PrimeBuy.Infrastructure.Data
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder builder)
        {

            // Password123!
            const string passwordHash = "AQAAAAIAAYagAAAAELPKE2rRSojBxPzOOWBBBPczaOLosox3P4A2XNpNTCbU5hbPO3QHfbAKwXzaFTBRwA==";

            var users = new ApplicationUser[]
            {
                CreateUser("u1", "john.doe@email.com",      "John",    "Michael",  "Doe",      passwordHash),
                CreateUser("u2", "jane.smith@email.com",     "Jane",    "Marie",    "Smith",    passwordHash),
                CreateUser("u3", "ahmed.hassan@email.com",   "Ahmed",   "Ali",      "Hassan",   passwordHash),
                CreateUser("u4", "maria.garcia@email.com",   "Maria",   "Elena",    "Garcia",   passwordHash),
                CreateUser("u5", "james.wilson@email.com",   "James",   "Robert",   "Wilson",   passwordHash),
                CreateUser("u6", "sara.johnson@email.com",   "Sara",    "Lynn",     "Johnson",  passwordHash),
                CreateUser("u7", "omar.khaled@email.com",    "Omar",    "Khaled",   "Ibrahim",  passwordHash),
                CreateUser("u8", "emily.brown@email.com",    "Emily",   "Rose",     "Brown",    passwordHash),
                CreateUser("u9", "david.lee@email.com",      "David",   "James",    "Lee",      passwordHash),
                CreateUser("u10","sophia.martinez@email.com","Sophia",  "Anne",     "Martinez", passwordHash),
            };

            builder.Entity<ApplicationUser>().HasData(users);


            builder.Entity<Category>().HasData(
                new { Id = 1,  Name = "Electronics",     CategoryImage = "/images/categories/electronics.jpg",     ParentCategoryId = (int?)null },
                new { Id = 2,  Name = "Clothing",        CategoryImage = "/images/categories/clothing.jpg",        ParentCategoryId = (int?)null },
                new { Id = 3,  Name = "Home & Kitchen",  CategoryImage = "/images/categories/home-kitchen.jpg",    ParentCategoryId = (int?)null },
                new { Id = 4,  Name = "Books",           CategoryImage = "/images/categories/books.jpg",           ParentCategoryId = (int?)null },
                new { Id = 5,  Name = "Sports",          CategoryImage = "/images/categories/sports.jpg",          ParentCategoryId = (int?)null },
                new { Id = 6,  Name = "Beauty",          CategoryImage = "/images/categories/beauty.jpg",          ParentCategoryId = (int?)null },
                new { Id = 7,  Name = "Toys & Games",    CategoryImage = "/images/categories/toys.jpg",            ParentCategoryId = (int?)null },
                new { Id = 8,  Name = "Automotive",      CategoryImage = "/images/categories/automotive.jpg",      ParentCategoryId = (int?)null },
                new { Id = 9,  Name = "Garden",          CategoryImage = "/images/categories/garden.jpg",          ParentCategoryId = (int?)null },
                new { Id = 10, Name = "Health",          CategoryImage = "/images/categories/health.jpg",          ParentCategoryId = (int?)null },

                new { Id = 11, Name = "Smartphones",     CategoryImage = "/images/categories/smartphones.jpg",     ParentCategoryId = (int?)1 },
                new { Id = 12, Name = "Laptops",         CategoryImage = "/images/categories/laptops.jpg",         ParentCategoryId = (int?)1 },
                new { Id = 13, Name = "Men's Clothing",  CategoryImage = "/images/categories/mens-clothing.jpg",   ParentCategoryId = (int?)2 },
                new { Id = 14, Name = "Women's Clothing",CategoryImage = "/images/categories/womens-clothing.jpg", ParentCategoryId = (int?)2 },
                new { Id = 15, Name = "Cookware",        CategoryImage = "/images/categories/cookware.jpg",        ParentCategoryId = (int?)3 },
                new { Id = 16, Name = "Fiction",         CategoryImage = "/images/categories/fiction.jpg",         ParentCategoryId = (int?)4 },
                new { Id = 17, Name = "Running",         CategoryImage = "/images/categories/running.jpg",         ParentCategoryId = (int?)5 },
                new { Id = 18, Name = "Skincare",        CategoryImage = "/images/categories/skincare.jpg",        ParentCategoryId = (int?)6 },
                new { Id = 19, Name = "Action Figures",  CategoryImage = "/images/categories/action-figures.jpg",  ParentCategoryId = (int?)7 },
                new { Id = 20, Name = "Car Accessories", CategoryImage = "/images/categories/car-accessories.jpg", ParentCategoryId = (int?)8 }
            );


            var now = new DateTime(2026, 1, 15, 10, 0, 0, DateTimeKind.Utc);

            builder.Entity<Product>().HasData(
                new { Id = 1,  Name = "Samsung Galaxy S25 Ultra",       SKU = "ELC-1001", Price = 1299.99m, StockQuantity = 50,  IsActive = true, CreatedAt = now, CategoryId = 11, ProductImage = "/images/products/galaxy-s25.jpg" },
                new { Id = 2,  Name = "Apple iPhone 16 Pro",            SKU = "ELC-1002", Price = 1199.00m, StockQuantity = 75,  IsActive = true, CreatedAt = now, CategoryId = 11, ProductImage = "/images/products/iphone-16-pro.jpg" },
                new { Id = 3,  Name = "Dell XPS 15 Laptop",             SKU = "ELC-2001", Price = 1549.99m, StockQuantity = 30,  IsActive = true, CreatedAt = now, CategoryId = 12, ProductImage = "/images/products/dell-xps-15.jpg" },
                new { Id = 4,  Name = "MacBook Air M4",                 SKU = "ELC-2002", Price = 1299.00m, StockQuantity = 40,  IsActive = true, CreatedAt = now, CategoryId = 12, ProductImage = "/images/products/macbook-air-m4.jpg" },
                new { Id = 5,  Name = "Levi's 501 Original Jeans",      SKU = "CLT-3001", Price = 69.50m,   StockQuantity = 200, IsActive = true, CreatedAt = now, CategoryId = 13, ProductImage = "/images/products/levis-501.jpg" },
                new { Id = 6,  Name = "Nike Dri-FIT Running Shirt",     SKU = "CLT-3002", Price = 35.00m,   StockQuantity = 150, IsActive = true, CreatedAt = now, CategoryId = 13, ProductImage = "/images/products/nike-drifit.jpg" },
                new { Id = 7,  Name = "Zara Midi Satin Dress",          SKU = "CLT-4001", Price = 89.90m,   StockQuantity = 80,  IsActive = true, CreatedAt = now, CategoryId = 14, ProductImage = "/images/products/zara-satin-dress.jpg" },
                new { Id = 8,  Name = "Adidas Ultraboost Light",        SKU = "SPR-5001", Price = 190.00m,  StockQuantity = 120, IsActive = true, CreatedAt = now, CategoryId = 17, ProductImage = "/images/products/adidas-ultraboost.jpg" },
                new { Id = 9,  Name = "Lodge Cast Iron Skillet 12\"",    SKU = "HMK-6001", Price = 44.90m,   StockQuantity = 90,  IsActive = true, CreatedAt = now, CategoryId = 15, ProductImage = "/images/products/lodge-skillet.jpg" },
                new { Id = 10, Name = "Instant Pot Duo 7-in-1",         SKU = "HMK-6002", Price = 89.99m,   StockQuantity = 60,  IsActive = true, CreatedAt = now, CategoryId = 15, ProductImage = "/images/products/instant-pot.jpg" },
                new { Id = 11, Name = "Atomic Habits by James Clear",   SKU = "BOK-7001", Price = 18.99m,   StockQuantity = 300, IsActive = true, CreatedAt = now, CategoryId = 16, ProductImage = "/images/products/atomic-habits.jpg" },
                new { Id = 12, Name = "The Great Gatsby",               SKU = "BOK-7002", Price = 12.49m,   StockQuantity = 250, IsActive = true, CreatedAt = now, CategoryId = 16, ProductImage = "/images/products/great-gatsby.jpg" },
                new { Id = 13, Name = "CeraVe Moisturizing Cream",      SKU = "BTY-8001", Price = 16.99m,   StockQuantity = 400, IsActive = true, CreatedAt = now, CategoryId = 18, ProductImage = "/images/products/cerave-cream.jpg" },
                new { Id = 14, Name = "The Ordinary Niacinamide Serum",  SKU = "BTY-8002", Price = 11.90m,   StockQuantity = 350, IsActive = true, CreatedAt = now, CategoryId = 18, ProductImage = "/images/products/ordinary-serum.jpg" },
                new { Id = 15, Name = "LEGO Star Wars Millennium Falcon",SKU = "TOY-9001", Price = 169.99m,  StockQuantity = 45,  IsActive = true, CreatedAt = now, CategoryId = 19, ProductImage = "/images/products/lego-falcon.jpg" },
                new { Id = 16, Name = "Marvel Legends Spider-Man",       SKU = "TOY-9002", Price = 24.99m,   StockQuantity = 180, IsActive = true, CreatedAt = now, CategoryId = 19, ProductImage = "/images/products/marvel-spiderman.jpg" },
                new { Id = 17, Name = "Armor All Car Cleaning Kit",      SKU = "AUT-1101", Price = 29.99m,   StockQuantity = 100, IsActive = true, CreatedAt = now, CategoryId = 20, ProductImage = "/images/products/armorall-kit.jpg" },
                new { Id = 18, Name = "Garmin Forerunner 265 Watch",     SKU = "SPR-5002", Price = 349.99m,  StockQuantity = 55,  IsActive = true, CreatedAt = now, CategoryId = 17, ProductImage = "/images/products/garmin-265.jpg" },
                new { Id = 19, Name = "Fiskars Garden Tool Set",         SKU = "GRD-1201", Price = 34.99m,   StockQuantity = 70,  IsActive = true, CreatedAt = now, CategoryId = 9,  ProductImage = "/images/products/fiskars-tools.jpg" },
                new { Id = 20, Name = "Vitamin D3 5000 IU Supplement",   SKU = "HLT-1301", Price = 14.99m,   StockQuantity = 500, IsActive = true, CreatedAt = now, CategoryId = 10, ProductImage = "/images/products/vitamin-d3.jpg" }
            );

            
            // Addresses (20 — 2 per user)
            builder.Entity<Address>().HasData(
                new { Id = 1,  ApplicationUserId = "u1",  Country = "United States", City = "New York",      Street = "350 Fifth Avenue",           ZipCode = "10118", IsDefault = true  },
                new { Id = 2,  ApplicationUserId = "u1",  Country = "United States", City = "Brooklyn",      Street = "123 Atlantic Avenue",        ZipCode = "11201", IsDefault = false },
                new { Id = 3,  ApplicationUserId = "u2",  Country = "United States", City = "Los Angeles",   Street = "6801 Hollywood Blvd",        ZipCode = "90028", IsDefault = true  },
                new { Id = 4,  ApplicationUserId = "u2",  Country = "United States", City = "Santa Monica",  Street = "401 Wilshire Blvd",          ZipCode = "90401", IsDefault = false },
                new { Id = 5,  ApplicationUserId = "u3",  Country = "Egypt",         City = "Cairo",         Street = "12 Tahrir Square",           ZipCode = "11511", IsDefault = true  },
                new { Id = 6,  ApplicationUserId = "u3",  Country = "Egypt",         City = "Alexandria",    Street = "45 Corniche Road",           ZipCode = "21599", IsDefault = false },
                new { Id = 7,  ApplicationUserId = "u4",  Country = "Spain",         City = "Madrid",        Street = "Gran Vía 28",                ZipCode = "28013", IsDefault = true  },
                new { Id = 8,  ApplicationUserId = "u4",  Country = "Spain",         City = "Barcelona",     Street = "La Rambla 91",               ZipCode = "08001", IsDefault = false },
                new { Id = 9,  ApplicationUserId = "u5",  Country = "United Kingdom",City = "London",        Street = "221B Baker Street",          ZipCode = "NW16XE",IsDefault = true  },
                new { Id = 10, ApplicationUserId = "u5",  Country = "United Kingdom",City = "Manchester",    Street = "10 Deansgate",               ZipCode = "M32BQ", IsDefault = false },
                new { Id = 11, ApplicationUserId = "u6",  Country = "United States", City = "Chicago",       Street = "875 N Michigan Avenue",      ZipCode = "60611", IsDefault = true  },
                new { Id = 12, ApplicationUserId = "u6",  Country = "United States", City = "Evanston",      Street = "1600 Sherman Avenue",        ZipCode = "60201", IsDefault = false },
                new { Id = 13, ApplicationUserId = "u7",  Country = "UAE",           City = "Dubai",         Street = "Sheikh Zayed Road Tower 3",  ZipCode = "00000", IsDefault = true  },
                new { Id = 14, ApplicationUserId = "u7",  Country = "UAE",           City = "Abu Dhabi",     Street = "Corniche Road West 15",      ZipCode = "00000", IsDefault = false },
                new { Id = 15, ApplicationUserId = "u8",  Country = "Canada",        City = "Toronto",       Street = "290 Bremner Blvd",           ZipCode = "M5V3L9",IsDefault = true  },
                new { Id = 16, ApplicationUserId = "u8",  Country = "Canada",        City = "Vancouver",     Street = "1055 Canada Place",          ZipCode = "V6C0C3",IsDefault = false },
                new { Id = 17, ApplicationUserId = "u9",  Country = "Australia",     City = "Sydney",        Street = "1 Macquarie Street",         ZipCode = "2000",  IsDefault = true  },
                new { Id = 18, ApplicationUserId = "u9",  Country = "Australia",     City = "Melbourne",     Street = "100 St Kilda Road",          ZipCode = "3004",  IsDefault = false },
                new { Id = 19, ApplicationUserId = "u10", Country = "Germany",       City = "Berlin",        Street = "Friedrichstraße 43",         ZipCode = "10117", IsDefault = true  },
                new { Id = 20, ApplicationUserId = "u10", Country = "Germany",       City = "Munich",        Street = "Marienplatz 8",              ZipCode = "80331", IsDefault = false }
            );


            builder.Entity<Order>().HasData(
                new { OrderId = 1,  OrderNumber = "ABCDEFGH", Status = OrderStatus.Completed, OrderDate = new DateTime(2026, 1, 20, 14, 30, 0, DateTimeKind.Utc), TotalAmount = 1369.49m, ApplicationUserId = "u1",  ShippingAddressId = 1  },
                new { OrderId = 2,  OrderNumber = "BCDEFGHI", Status = OrderStatus.Completed, OrderDate = new DateTime(2026, 1, 22, 9, 15, 0, DateTimeKind.Utc),  TotalAmount = 1234.50m, ApplicationUserId = "u1",  ShippingAddressId = 2  },
                new { OrderId = 3,  OrderNumber = "CDEFGHIJ", Status = OrderStatus.Shipped,   OrderDate = new DateTime(2026, 1, 25, 16, 0, 0, DateTimeKind.Utc),  TotalAmount = 1549.99m, ApplicationUserId = "u2",  ShippingAddressId = 3  },
                new { OrderId = 4,  OrderNumber = "DEFGHIJK", Status = OrderStatus.Paid,      OrderDate = new DateTime(2026, 1, 28, 11, 45, 0, DateTimeKind.Utc), TotalAmount = 225.40m,  ApplicationUserId = "u2",  ShippingAddressId = 4  },
                new { OrderId = 5,  OrderNumber = "EFGHIJKL", Status = OrderStatus.Completed, OrderDate = new DateTime(2026, 2, 1, 8, 30, 0, DateTimeKind.Utc),   TotalAmount = 1199.00m, ApplicationUserId = "u3",  ShippingAddressId = 5  },
                new { OrderId = 6,  OrderNumber = "FGHIJKLM", Status = OrderStatus.Shipped,   OrderDate = new DateTime(2026, 2, 3, 13, 20, 0, DateTimeKind.Utc),  TotalAmount = 104.89m,  ApplicationUserId = "u3",  ShippingAddressId = 6  },
                new { OrderId = 7,  OrderNumber = "GHIJKLMN", Status = OrderStatus.Pending,   OrderDate = new DateTime(2026, 2, 5, 17, 10, 0, DateTimeKind.Utc),  TotalAmount = 379.98m,  ApplicationUserId = "u4",  ShippingAddressId = 7  },
                new { OrderId = 8,  OrderNumber = "HIJKLMNO", Status = OrderStatus.Completed, OrderDate = new DateTime(2026, 2, 7, 10, 0, 0, DateTimeKind.Utc),   TotalAmount = 539.98m,  ApplicationUserId = "u4",  ShippingAddressId = 8  },
                new { OrderId = 9,  OrderNumber = "IJKLMNOP", Status = OrderStatus.Paid,      OrderDate = new DateTime(2026, 2, 10, 15, 30, 0, DateTimeKind.Utc), TotalAmount = 31.48m,   ApplicationUserId = "u5",  ShippingAddressId = 9  },
                new { OrderId = 10, OrderNumber = "JKLMNOPQ", Status = OrderStatus.Shipped,   OrderDate = new DateTime(2026, 2, 12, 9, 45, 0, DateTimeKind.Utc),  TotalAmount = 349.99m,  ApplicationUserId = "u5",  ShippingAddressId = 10 },
                new { OrderId = 11, OrderNumber = "KLMNOPQR", Status = OrderStatus.Completed, OrderDate = new DateTime(2026, 2, 14, 12, 0, 0, DateTimeKind.Utc),  TotalAmount = 134.89m,  ApplicationUserId = "u6",  ShippingAddressId = 11 },
                new { OrderId = 12, OrderNumber = "LMNOPQRS", Status = OrderStatus.Cancelled, OrderDate = new DateTime(2026, 2, 15, 8, 10, 0, DateTimeKind.Utc),  TotalAmount = 169.99m,  ApplicationUserId = "u6",  ShippingAddressId = 12 },
                new { OrderId = 13, OrderNumber = "MNOPQRST", Status = OrderStatus.Pending,   OrderDate = new DateTime(2026, 2, 18, 14, 20, 0, DateTimeKind.Utc), TotalAmount = 1299.99m, ApplicationUserId = "u7",  ShippingAddressId = 13 },
                new { OrderId = 14, OrderNumber = "NOPQRSTU", Status = OrderStatus.Paid,      OrderDate = new DateTime(2026, 2, 20, 16, 30, 0, DateTimeKind.Utc), TotalAmount = 59.98m,   ApplicationUserId = "u7",  ShippingAddressId = 14 },
                new { OrderId = 15, OrderNumber = "OPQRSTUV", Status = OrderStatus.Completed, OrderDate = new DateTime(2026, 2, 22, 11, 0, 0, DateTimeKind.Utc),  TotalAmount = 1299.00m, ApplicationUserId = "u8",  ShippingAddressId = 15 },
                new { OrderId = 16, OrderNumber = "PQRSTUVW", Status = OrderStatus.Shipped,   OrderDate = new DateTime(2026, 2, 24, 10, 15, 0, DateTimeKind.Utc), TotalAmount = 69.98m,   ApplicationUserId = "u8",  ShippingAddressId = 16 },
                new { OrderId = 17, OrderNumber = "QRSTUVWX", Status = OrderStatus.Pending,   OrderDate = new DateTime(2026, 2, 26, 9, 0, 0, DateTimeKind.Utc),   TotalAmount = 190.00m,  ApplicationUserId = "u9",  ShippingAddressId = 17 },
                new { OrderId = 18, OrderNumber = "RSTUVWXY", Status = OrderStatus.Completed, OrderDate = new DateTime(2026, 2, 28, 13, 45, 0, DateTimeKind.Utc), TotalAmount = 64.98m,   ApplicationUserId = "u9",  ShippingAddressId = 18 },
                new { OrderId = 19, OrderNumber = "STUVWXYZ", Status = OrderStatus.Paid,      OrderDate = new DateTime(2026, 3, 1, 15, 30, 0, DateTimeKind.Utc),  TotalAmount = 194.98m,  ApplicationUserId = "u10", ShippingAddressId = 19 },
                new { OrderId = 20, OrderNumber = "TUVWXYZA", Status = OrderStatus.Shipped,   OrderDate = new DateTime(2026, 3, 3, 8, 0, 0, DateTimeKind.Utc),    TotalAmount = 29.99m,   ApplicationUserId = "u10", ShippingAddressId = 20 }
            );


            builder.Entity<OrderItem>().HasData(
                // Order 1  →  Galaxy S25 + Levi's Jeans
                new { Id = 1,  OrderId = 1,  ProductId = 1,  UnitPrice = 1299.99m, Quantity = 1 },
                new { Id = 2,  OrderId = 1,  ProductId = 5,  UnitPrice = 69.50m,   Quantity = 1 },
                // Order 2  →  Nike Shirt (x5) + Lodge Skillet
                new { Id = 3,  OrderId = 2,  ProductId = 6,  UnitPrice = 35.00m,   Quantity = 5 },
                new { Id = 4,  OrderId = 2,  ProductId = 9,  UnitPrice = 44.90m,   Quantity = 1 },
                // Order 3  →  Dell XPS 15
                new { Id = 5,  OrderId = 3,  ProductId = 3,  UnitPrice = 1549.99m, Quantity = 1 },
                new { Id = 6,  OrderId = 3,  ProductId = 20, UnitPrice = 14.99m,   Quantity = 0 },  // free sample placeholder (qty part of total)
                // Order 4  →  Zara Dress + Nike Shirt (x2) + Instant Pot
                new { Id = 7,  OrderId = 4,  ProductId = 7,  UnitPrice = 89.90m,   Quantity = 1 },
                new { Id = 8,  OrderId = 4,  ProductId = 6,  UnitPrice = 35.00m,   Quantity = 2 },
                // Order 5  →  iPhone 16 Pro
                new { Id = 9,  OrderId = 5,  ProductId = 2,  UnitPrice = 1199.00m, Quantity = 1 },
                new { Id = 10, OrderId = 5,  ProductId = 14, UnitPrice = 11.90m,   Quantity = 0 },
                // Order 6  →  Instant Pot + Vitamin D3
                new { Id = 11, OrderId = 6,  ProductId = 10, UnitPrice = 89.99m,   Quantity = 1 },
                new { Id = 12, OrderId = 6,  ProductId = 20, UnitPrice = 14.99m,   Quantity = 1 },
                // Order 7  →  Adidas Ultraboost (x2)
                new { Id = 13, OrderId = 7,  ProductId = 8,  UnitPrice = 190.00m,  Quantity = 2 },
                new { Id = 14, OrderId = 7,  ProductId = 13, UnitPrice = 16.99m,   Quantity = 0 },
                // Order 8  →  Garmin Watch + Adidas Ultraboost
                new { Id = 15, OrderId = 8,  ProductId = 18, UnitPrice = 349.99m,  Quantity = 1 },
                new { Id = 16, OrderId = 8,  ProductId = 8,  UnitPrice = 190.00m,  Quantity = 1 },
                // Order 9  →  Atomic Habits + Great Gatsby
                new { Id = 17, OrderId = 9,  ProductId = 11, UnitPrice = 18.99m,   Quantity = 1 },
                new { Id = 18, OrderId = 9,  ProductId = 12, UnitPrice = 12.49m,   Quantity = 1 },
                // Order 10 →  Garmin Watch
                new { Id = 19, OrderId = 10, ProductId = 18, UnitPrice = 349.99m,  Quantity = 1 },
                new { Id = 20, OrderId = 10, ProductId = 20, UnitPrice = 14.99m,   Quantity = 0 },
                // Order 11 →  CeraVe Cream (x3) + Ordinary Serum (x3) + Fiskars Tools
                new { Id = 21, OrderId = 11, ProductId = 13, UnitPrice = 16.99m,   Quantity = 3 },
                new { Id = 22, OrderId = 11, ProductId = 14, UnitPrice = 11.90m,   Quantity = 3 },
                // Order 12 →  LEGO Millennium Falcon
                new { Id = 23, OrderId = 12, ProductId = 15, UnitPrice = 169.99m,  Quantity = 1 },
                new { Id = 24, OrderId = 12, ProductId = 16, UnitPrice = 24.99m,   Quantity = 0 },
                // Order 13 →  Galaxy S25 Ultra
                new { Id = 25, OrderId = 13, ProductId = 1,  UnitPrice = 1299.99m, Quantity = 1 },
                new { Id = 26, OrderId = 13, ProductId = 13, UnitPrice = 16.99m,   Quantity = 0 },
                // Order 14 →  Fiskars Tools + Marvel Spider-Man
                new { Id = 27, OrderId = 14, ProductId = 19, UnitPrice = 34.99m,   Quantity = 1 },
                new { Id = 28, OrderId = 14, ProductId = 16, UnitPrice = 24.99m,   Quantity = 1 },
                // Order 15 →  MacBook Air M4
                new { Id = 29, OrderId = 15, ProductId = 4,  UnitPrice = 1299.00m, Quantity = 1 },
                new { Id = 30, OrderId = 15, ProductId = 11, UnitPrice = 18.99m,   Quantity = 0 },
                // Order 16 →  Levi's Jeans + Nike Shirt
                new { Id = 31, OrderId = 16, ProductId = 5,  UnitPrice = 69.50m,   Quantity = 1 },
                new { Id = 32, OrderId = 16, ProductId = 6,  UnitPrice = 35.00m,   Quantity = 1 },
                // Order 17 →  Adidas Ultraboost
                new { Id = 33, OrderId = 17, ProductId = 8,  UnitPrice = 190.00m,  Quantity = 1 },
                new { Id = 34, OrderId = 17, ProductId = 12, UnitPrice = 12.49m,   Quantity = 0 },
                // Order 18 →  Fiskars Tools + Armor All Kit
                new { Id = 35, OrderId = 18, ProductId = 19, UnitPrice = 34.99m,   Quantity = 1 },
                new { Id = 36, OrderId = 18, ProductId = 17, UnitPrice = 29.99m,   Quantity = 1 },
                // Order 19 →  LEGO Falcon + Marvel Spider-Man
                new { Id = 37, OrderId = 19, ProductId = 15, UnitPrice = 169.99m,  Quantity = 1 },
                new { Id = 38, OrderId = 19, ProductId = 16, UnitPrice = 24.99m,   Quantity = 1 },
                // Order 20 →  Armor All Kit
                new { Id = 39, OrderId = 20, ProductId = 17, UnitPrice = 29.99m,   Quantity = 1 },
                new { Id = 40, OrderId = 20, ProductId = 14, UnitPrice = 11.90m,   Quantity = 0 }
            );
        }

        private static ApplicationUser CreateUser(string id, string email, string first, string middle, string last, string passwordHash)
        {
            return new ApplicationUser
            {
                Id = id,
                UserName = email,
                NormalizedUserName = email.ToUpperInvariant(),
                Email = email,
                NormalizedEmail = email.ToUpperInvariant(),
                EmailConfirmed = true,
                FirstName = first,
                MiddleName = middle,
                LastName = last,
                PasswordHash = passwordHash,
                SecurityStamp = id,
                ConcurrencyStamp = id,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
        }
    }
}
