using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeBuy.Application.Services
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;
        IOrderItemRepository orderItemRepository;
        public ProductService(IProductRepository productRepository,IOrderItemRepository orderItemRepository)
        {
            this.productRepository = productRepository;
            this.orderItemRepository = orderItemRepository;
        }
        public async Task DeleteProduct(Product entity)
        {
            productRepository.Delete(entity);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await productRepository.GetAllAsync();
        }

        public  async Task<IEnumerable<Product>> getHighRateProductsAsync()
        {
            var products = await productRepository.GetAllAsync();
            return products.Where(p => p.Rating >= 4).Take(5);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await productRepository.GetByIdAsync(id);
        }

        public async Task UpdateProduct(Product product)
        {
             productRepository.Update(product);
        }
        public async Task<IEnumerable<Product>> getBestSalesAsync()
        {
            var products = await productRepository.GetAllAsync();
            var orderItems = await orderItemRepository.GetAllAsync();

            var bestSales = orderItems
                .GroupBy(oi => oi.ProductId)
                .Select(g => new { ProductId = g.Key, TotalSold = g.Sum(e => e.Quantity) })
                .OrderByDescending(o => o.TotalSold)
                .Take(5)
                .Join(products,
                      g => g.ProductId,
                      p => p.Id,
                      (g, p) => p);

            return bestSales;
        }


    }
}
