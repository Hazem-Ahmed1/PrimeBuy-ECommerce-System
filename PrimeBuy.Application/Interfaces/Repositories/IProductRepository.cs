using PrimeBuy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeBuy.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsWithCategoryAsync();
    }
}
