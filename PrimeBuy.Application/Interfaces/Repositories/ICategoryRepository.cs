using PrimeBuy.Domain.Models;

namespace PrimeBuy.Application.Interfaces.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetSubCategoriesAsync();
        Task<IEnumerable<Category>> GetParentCategoriesAsync();
        Task<Category?> GetCategoryWithRelatedDataAsync(int id);
        Task<bool> HasProductsAsync(int categoryId);
        Task<bool> HasChildCategoriesAsync(int categoryId);
        Task<int> GetProductsCountAsync(int categoryId);
        Task<int> GetChildCategoriesCountAsync(int categoryId);
    }
}
