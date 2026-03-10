using PrimeBuy.Domain.Models;

namespace PrimeBuy.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsWithCategoryAsync();
        Task<Product?> GetProductByIdWithCategoryAsync(int id);
        Task<IEnumerable<Product>> GetHighRatedProductsAsync(int count);
        Task<IEnumerable<Product>> GetBestSellingProductsAsync(int count);
        Task<(IEnumerable<Product> products, int totalCount)> GetFilteredProductsAsync(
            int? categoryId, string? searchTerm, string sortBy, int page, int pageSize);
        Task<Dictionary<int, int>> GetCategoryProductCountsAsync();
    }
}
