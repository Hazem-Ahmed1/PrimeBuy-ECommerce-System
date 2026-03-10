using PrimeBuy.Domain.Models;

namespace PrimeBuy.Application.Interfaces.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<Product> GetProductById(int id);
        public Task<Product?> GetProductByIdWithCategory(int id);
        public Task AddProduct(Product product);
        public Task UpdateProduct(Product product);
        public Task DeleteProduct(Product Entity);
        public Task<IEnumerable<Product>> getHighRateProductsAsync();
        public Task<IEnumerable<Product>> getBestSalesAsync();
        
        // Shop-specific methods
        public Task<IEnumerable<Product>> GetProductsWithCategoryAsync();
        public Task<(IEnumerable<Product> products, int totalCount)> GetFilteredProductsAsync(
            int? categoryId = null,
            string searchTerm = null,
            string sortBy = "default",
            int page = 1,
            int pageSize = 12);
        public Task<Dictionary<int, int>> GetCategoryProductCountsAsync();
    }
}
