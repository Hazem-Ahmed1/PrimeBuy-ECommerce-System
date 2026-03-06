using PrimeBuy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeBuy.Application.Interfaces.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<Product> GetProductById(int id);
        public Task UpdateProduct(Product product);
        public Task DeleteProduct(Product Entity);
        public Task<IEnumerable<Product>> getHighRateProductsAsync();
        public Task<IEnumerable<Product>> getBestSalesAsync();

    }
}
