using Microsoft.AspNetCore.Mvc;
using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Web.ViewModels;

namespace PrimeBuy.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdWithCategory(id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductDetailViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                SKU = product.SKU,
                StockQuantity = product.StockQuantity,
                Rating = product.Rating,
                ProductImageUrl = product.ProductImageUrl,
                CategoryName = product.Category?.Name ?? "Uncategorized",
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt
            };

            return View(viewModel);
        }
    }
}
