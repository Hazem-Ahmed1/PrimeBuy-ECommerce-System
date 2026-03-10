using Microsoft.EntityFrameworkCore;
using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Domain.Models;
using PrimeBuy.Infrastructure.Data;

namespace PrimeBuy.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetSubCategoriesAsync()
        {
            return await _context.Categories
                .Where(c => c.ParentCategoryId != null)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetParentCategoriesAsync()
        {
            return await _context.Categories
                .Where(c => c.ParentCategoryId == null)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryWithRelatedDataAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.Products)
                .Include(c => c.ChildCategories)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> HasProductsAsync(int categoryId)
        {
            return await _context.Products.AnyAsync(p => p.CategoryId == categoryId);
        }

        public async Task<bool> HasChildCategoriesAsync(int categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.ParentCategoryId == categoryId);
        }

        public async Task<int> GetProductsCountAsync(int categoryId)
        {
            return await _context.Products.CountAsync(p => p.CategoryId == categoryId);
        }

        public async Task<int> GetChildCategoriesCountAsync(int categoryId)
        {
            return await _context.Categories.CountAsync(c => c.ParentCategoryId == categoryId);
        }
    }
}
