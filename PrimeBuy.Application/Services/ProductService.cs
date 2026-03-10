using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Application.Interfaces.UnitOfWork;
using PrimeBuy.Domain.Models;

namespace PrimeBuy.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _unitOfWork.Products.GetAllAsync();

        public async Task<Product> GetProductById(int id)
            => await _unitOfWork.Products.GetByIdAsync(id);

        public async Task<Product?> GetProductByIdWithCategory(int id)
            => await _unitOfWork.Products.GetProductByIdWithCategoryAsync(id);

        public async Task AddProduct(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product entity)
        {
            _unitOfWork.Products.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> getHighRateProductsAsync()
            => await _unitOfWork.Products.GetHighRatedProductsAsync(5);

        public async Task<IEnumerable<Product>> getBestSalesAsync()
            => await _unitOfWork.Products.GetBestSellingProductsAsync(5);

        public async Task<IEnumerable<Product>> GetProductsWithCategoryAsync()
            => await _unitOfWork.Products.GetProductsWithCategoryAsync();

        public async Task<(IEnumerable<Product> products, int totalCount)> GetFilteredProductsAsync(
            int? categoryId = null, string searchTerm = null, string sortBy = "default",
            int page = 1, int pageSize = 12)
            => await _unitOfWork.Products.GetFilteredProductsAsync(categoryId, searchTerm, sortBy, page, pageSize);

        public async Task<Dictionary<int, int>> GetCategoryProductCountsAsync()
            => await _unitOfWork.Products.GetCategoryProductCountsAsync();
    }
}
