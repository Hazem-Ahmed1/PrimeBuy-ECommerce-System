using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrimeBuy.Domain.Models;

namespace PrimeBuy.Infrastructure.Data
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new { Id = 1,  Name = "Electronics",     CategoryImage = "https://images.unsplash.com/photo-1498049794561-7780e7231661?w=300&h=200&fit=crop",     ParentCategoryId = (int?)null },
                new { Id = 2,  Name = "Clothing",        CategoryImage = "https://images.unsplash.com/photo-1445205170230-053b83016050?w=300&h=200&fit=crop",        ParentCategoryId = (int?)null },
                new { Id = 3,  Name = "Home & Kitchen",  CategoryImage = "https://images.unsplash.com/photo-1556185781-a47769abb7aa?w=300&h=200&fit=crop",    ParentCategoryId = (int?)null },
                new { Id = 4,  Name = "Books",           CategoryImage = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=300&h=200&fit=crop",           ParentCategoryId = (int?)null },
                new { Id = 5,  Name = "Sports",          CategoryImage = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?w=300&h=200&fit=crop",          ParentCategoryId = (int?)null },
                new { Id = 6,  Name = "Beauty",          CategoryImage = "https://images.unsplash.com/photo-1596462502278-27bfdc403348?w=300&h=200&fit=crop",          ParentCategoryId = (int?)null },
                new { Id = 7,  Name = "Toys & Games",    CategoryImage = "https://images.unsplash.com/photo-1596461404969-9ae70f2830c1?w=300&h=200&fit=crop",            ParentCategoryId = (int?)null },
                new { Id = 8,  Name = "Automotive",      CategoryImage = "https://images.unsplash.com/photo-1449965408869-eaa3f722e40d?w=300&h=200&fit=crop",      ParentCategoryId = (int?)null },
                new { Id = 9,  Name = "Garden",          CategoryImage = "https://images.unsplash.com/photo-1416879595882-3373a0480b5b?w=300&h=200&fit=crop",          ParentCategoryId = (int?)null },
                new { Id = 10, Name = "Health",          CategoryImage = "https://images.unsplash.com/photo-1559757175-0eb30cd8c063?w=300&h=200&fit=crop",          ParentCategoryId = (int?)null },

                new { Id = 11, Name = "Smartphones",     CategoryImage = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?w=300&h=200&fit=crop",     ParentCategoryId = (int?)1 },
                new { Id = 12, Name = "Laptops",         CategoryImage = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=300&h=200&fit=crop",         ParentCategoryId = (int?)1 },
                new { Id = 13, Name = "Men's Clothing",  CategoryImage = "https://images.unsplash.com/photo-1503341504253-dff4815485f1?w=300&h=200&fit=crop",   ParentCategoryId = (int?)2 },
                new { Id = 14, Name = "Women's Clothing",CategoryImage = "https://images.unsplash.com/photo-1566479179817-c0cf9a5d7d1f?w=300&h=200&fit=crop", ParentCategoryId = (int?)2 },
                new { Id = 15, Name = "Cookware",        CategoryImage = "https://images.unsplash.com/photo-1556909114-f6e7ad7d3136?w=300&h=200&fit=crop",        ParentCategoryId = (int?)3 },
                new { Id = 16, Name = "Fiction",         CategoryImage = "https://images.unsplash.com/photo-1544947950-fa07a98d237f?w=300&h=200&fit=crop",         ParentCategoryId = (int?)4 },
                new { Id = 17, Name = "Running",         CategoryImage = "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=300&h=200&fit=crop",         ParentCategoryId = (int?)5 },
                new { Id = 18, Name = "Skincare",        CategoryImage = "https://images.unsplash.com/photo-1556228453-efd6c1ff04f6?w=300&h=200&fit=crop",        ParentCategoryId = (int?)6 },
                new { Id = 19, Name = "Action Figures",  CategoryImage = "https://images.unsplash.com/photo-1608889825103-eb5ed706fc64?w=300&h=200&fit=crop",  ParentCategoryId = (int?)7 },
                new { Id = 20, Name = "Car Accessories", CategoryImage = "https://images.unsplash.com/photo-1483653364400-eedcfb9f1f88?w=300&h=200&fit=crop", ParentCategoryId = (int?)8 }
            );

            var now = new DateTime(2026, 1, 15, 10, 0, 0, DateTimeKind.Utc);

            builder.Entity<Product>().HasData(
                new { Id = 1,  Name = "Samsung Galaxy S25 Ultra",       SKU = "ELC-1001", Price = 1299.99m, StockQuantity = 50,  IsActive = true, Rating = 4.5, CreatedAt = now, CategoryId = 11, ProductImageUrl = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?w=400&h=400&fit=crop" },
                new { Id = 2,  Name = "Apple iPhone 16 Pro",            SKU = "ELC-1002", Price = 1199.00m, StockQuantity = 75,  IsActive = true, Rating = 4.8, CreatedAt = now, CategoryId = 11, ProductImageUrl = "https://images.unsplash.com/photo-1592899677977-9c10ca588bbd?w=400&h=400&fit=crop" },
                new { Id = 3,  Name = "Dell XPS 15 Laptop",             SKU = "ELC-2001", Price = 1549.99m, StockQuantity = 30,  IsActive = true, Rating = 4.6, CreatedAt = now, CategoryId = 12, ProductImageUrl = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=400&h=400&fit=crop" },
                new { Id = 4,  Name = "MacBook Air M4",                 SKU = "ELC-2002", Price = 1299.00m, StockQuantity = 40,  IsActive = true, Rating = 4.9, CreatedAt = now, CategoryId = 12, ProductImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=400&h=400&fit=crop" },
                new { Id = 5,  Name = "Levi's 501 Original Jeans",      SKU = "CLT-3001", Price = 69.50m,   StockQuantity = 200, IsActive = true, Rating = 4.2, CreatedAt = now, CategoryId = 13, ProductImageUrl = "https://images.unsplash.com/photo-1551698618-1dfe5d97d256?w=400&h=400&fit=crop" },
                new { Id = 6,  Name = "Nike Dri-FIT Running Shirt",     SKU = "CLT-3002", Price = 35.00m,   StockQuantity = 150, IsActive = true, Rating = 4.3, CreatedAt = now, CategoryId = 13, ProductImageUrl = "https://images.unsplash.com/photo-1503341504253-dff4815485f1?w=400&h=400&fit=crop" },
                new { Id = 7,  Name = "Zara Midi Satin Dress",          SKU = "CLT-4001", Price = 89.90m,   StockQuantity = 80,  IsActive = true, Rating = 4.1, CreatedAt = now, CategoryId = 14, ProductImageUrl = "https://images.unsplash.com/photo-1566479179817-c0cf9a5d7d1f?w=400&h=400&fit=crop" },
                new { Id = 8,  Name = "Adidas Ultraboost Light",        SKU = "SPR-5001", Price = 190.00m,  StockQuantity = 120, IsActive = true, Rating = 4.4, CreatedAt = now, CategoryId = 17, ProductImageUrl = "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=400&h=400&fit=crop" },
                new { Id = 9,  Name = "Lodge Cast Iron Skillet 12\"",    SKU = "HMK-6001", Price = 44.90m,   StockQuantity = 90,  IsActive = true, Rating = 4.7, CreatedAt = now, CategoryId = 15, ProductImageUrl = "https://images.unsplash.com/photo-1556909114-f6e7ad7d3136?w=400&h=400&fit=crop" },
                new { Id = 10, Name = "Instant Pot Duo 7-in-1",         SKU = "HMK-6002", Price = 89.99m,   StockQuantity = 60,  IsActive = true, Rating = 4.5, CreatedAt = now, CategoryId = 15, ProductImageUrl = "https://images.unsplash.com/photo-1574781330855-d0db0775562a?w=400&h=400&fit=crop" },
                new { Id = 11, Name = "Atomic Habits by James Clear",   SKU = "BOK-7001", Price = 18.99m,   StockQuantity = 300, IsActive = true, Rating = 4.8, CreatedAt = now, CategoryId = 16, ProductImageUrl = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=400&h=400&fit=crop" },
                new { Id = 12, Name = "The Great Gatsby",               SKU = "BOK-7002", Price = 12.49m,   StockQuantity = 250, IsActive = true, Rating = 4.0, CreatedAt = now, CategoryId = 16, ProductImageUrl = "https://images.unsplash.com/photo-1544947950-fa07a98d237f?w=400&h=400&fit=crop" },
                new { Id = 13, Name = "CeraVe Moisturizing Cream",      SKU = "BTY-8001", Price = 16.99m,   StockQuantity = 400, IsActive = true, Rating = 4.6, CreatedAt = now, CategoryId = 18, ProductImageUrl = "https://images.unsplash.com/photo-1556228453-efd6c1ff04f6?w=400&h=400&fit=crop" },
                new { Id = 14, Name = "The Ordinary Niacinamide Serum",  SKU = "BTY-8002", Price = 11.90m,   StockQuantity = 350, IsActive = true, Rating = 4.3, CreatedAt = now, CategoryId = 18, ProductImageUrl = "https://images.unsplash.com/photo-1620916566398-39f1143ab7be?w=400&h=400&fit=crop" },
                new { Id = 15, Name = "LEGO Star Wars Millennium Falcon",SKU = "TOY-9001", Price = 169.99m,  StockQuantity = 45,  IsActive = true, Rating = 4.9, CreatedAt = now, CategoryId = 19, ProductImageUrl = "https://images.unsplash.com/photo-1587654780291-39c9404d746b?w=400&h=400&fit=crop" },
                new { Id = 16, Name = "Marvel Legends Spider-Man",       SKU = "TOY-9002", Price = 24.99m,   StockQuantity = 180, IsActive = true, Rating = 4.4, CreatedAt = now, CategoryId = 19, ProductImageUrl = "https://images.unsplash.com/photo-1608889825103-eb5ed706fc64?w=400&h=400&fit=crop" },
                new { Id = 17, Name = "Armor All Car Cleaning Kit",      SKU = "AUT-1101", Price = 29.99m,   StockQuantity = 100, IsActive = true, Rating = 4.2, CreatedAt = now, CategoryId = 20, ProductImageUrl = "https://images.unsplash.com/photo-1449965408869-eaa3f722e40d?w=400&h=400&fit=crop" },
                new { Id = 18, Name = "Garmin Forerunner 265 Watch",     SKU = "SPR-5002", Price = 349.99m,  StockQuantity = 55,  IsActive = true, Rating = 4.7, CreatedAt = now, CategoryId = 17, ProductImageUrl = "https://images.unsplash.com/photo-1508685096489-7aacd43bd3b1?w=400&h=400&fit=crop" },
                new { Id = 19, Name = "Fiskars Garden Tool Set",         SKU = "GRD-1201", Price = 34.99m,   StockQuantity = 70,  IsActive = true, Rating = 4.0, CreatedAt = now, CategoryId = 9,  ProductImageUrl = "https://images.unsplash.com/photo-1416879595882-3373a0480b5b?w=400&h=400&fit=crop" },
                new { Id = 20, Name = "Vitamin D3 5000 IU Supplement",   SKU = "HLT-1301", Price = 14.99m,   StockQuantity = 500, IsActive = true, Rating = 4.1, CreatedAt = now, CategoryId = 10, ProductImageUrl = "https://images.unsplash.com/photo-1559757175-0eb30cd8c063?w=400&h=400&fit=crop" }
            );
        }
    }
}
