using Microsoft.EntityFrameworkCore;
using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Domain.Models;
using PrimeBuy.Infrastructure.Data;

namespace PrimeBuy.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsWithCategoryAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product?> GetProductByIdWithCategoryAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetHighRatedProductsAsync(int count)
        {
            return await _context.Products
                .Where(p => p.Rating >= 4)
                .OrderByDescending(p => p.Rating)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetBestSellingProductsAsync(int count)
        {
            return await _context.OrderItems
                .GroupBy(oi => oi.ProductId)
                .Select(g => new { ProductId = g.Key, TotalSold = g.Sum(oi => oi.Quantity) })
                .OrderByDescending(x => x.TotalSold)
                .Take(count)
                .Join(
                    _context.Products,
                    x => x.ProductId,
                    p => p.Id,
                    (x, p) => p)
                .ToListAsync();
        }

        public async Task<(IEnumerable<Product> products, int totalCount)> GetFilteredProductsAsync(
            int? categoryId, string? searchTerm, string sortBy, int page, int pageSize)
        {
            var query = _context.Products.AsQueryable();

            if (categoryId.HasValue)
            {
                var childCategoryIds = await _context.Categories
                    .Where(c => c.ParentCategoryId == categoryId.Value)
                    .Select(c => c.Id)
                    .ToListAsync();

                query = query.Where(p =>
                    p.CategoryId == categoryId.Value ||
                    childCategoryIds.Contains(p.CategoryId));
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var matchingCategoryIds = await _context.Categories
                    .Where(c => c.Name.Contains(searchTerm))
                    .Select(c => c.Id)
                    .ToListAsync();

                query = query.Where(p =>
                    p.Name.Contains(searchTerm) ||
                    matchingCategoryIds.Contains(p.CategoryId));
            }

            var totalCount = await query.CountAsync();

            query = sortBy?.ToLower() switch
            {
                "price-low" => query.OrderBy(p => p.Price),
                "price-high" => query.OrderByDescending(p => p.Price),
                "newest" => query.OrderByDescending(p => p.CreatedAt),
                "rating" => query.OrderByDescending(p => p.Rating),
                "popular" => query.OrderByDescending(p => p.StockQuantity),
                _ => query.OrderBy(p => p.Name)
            };

            var products = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(p => p.Category)
                .ToListAsync();

            return (products, totalCount);
        }

        public async Task<Dictionary<int, int>> GetCategoryProductCountsAsync()
        {
            var directCounts = await _context.Products
                .GroupBy(p => p.CategoryId)
                .Select(g => new { CategoryId = g.Key, Count = g.Count() })
                .ToListAsync();

            var parentCounts = await _context.Products
                .Join(
                    _context.Categories.Where(c => c.ParentCategoryId != null),
                    p => p.CategoryId,
                    c => c.Id,
                    (p, c) => new { c.ParentCategoryId })
                .GroupBy(x => x.ParentCategoryId!.Value)
                .Select(g => new { CategoryId = g.Key, Count = g.Count() })
                .ToListAsync();

            var counts = new Dictionary<int, int>();

            foreach (var item in directCounts)
                counts[item.CategoryId] = item.Count;

            foreach (var item in parentCounts)
            {
                if (counts.ContainsKey(item.CategoryId))
                    counts[item.CategoryId] += item.Count;
                else
                    counts[item.CategoryId] = item.Count;
            }

            return counts;
        }
    }
}
