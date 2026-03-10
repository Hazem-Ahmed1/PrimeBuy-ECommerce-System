using PrimeBuy.Application.Common;
using PrimeBuy.Domain.Models;

namespace PrimeBuy.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> getAllSubCategoriesAsync();
        public Task<IEnumerable<Category>> getAllParentCategoriesAsync();
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<Category> GetByIdAsync(int id);
        public Task AddAsync(Category category);
        public Task UpdateAsync(Category category);
        public Task<DeleteResult> DeleteAsync(Category category);
        public Task<bool> CanDeleteSafelyAsync(int categoryId);
        public Task<(bool hasProducts, bool hasChildren, int productsCount, int childrenCount)> CheckDependenciesAsync(int categoryId);
    }
}
