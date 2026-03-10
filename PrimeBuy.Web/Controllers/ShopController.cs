using Microsoft.AspNetCore.Mvc;
using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Web.ViewModels;

namespace PrimeBuy.Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ShopController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(
            int? categoryId = null,
            string searchTerm = null,
            string sortBy = "default",
            int page = 1,
            int pageSize = 12,
            string viewMode = "grid")
        {
            // Get filtered products with pagination
            var (filteredProducts, totalCount) = await _productService.GetFilteredProductsAsync(categoryId, searchTerm, sortBy, page, pageSize);

            var parentCategories = await _categoryService.getAllParentCategoriesAsync();
            var subcategories = await _categoryService.getAllSubCategoriesAsync();
            var categoryProductCounts = await _productService.GetCategoryProductCountsAsync();

            // Calculate pagination
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var shopVM = new ShopVM
            {
                Products = filteredProducts,
                ParentCategories = parentCategories,
                Subcategories = subcategories,
                CurrentPage = page,
                TotalPages = totalPages,
                TotalProductsCount = totalCount,
                PageSize = pageSize,

                // Filter parameters
                CategoryId = categoryId,
                SearchTerm = searchTerm ?? string.Empty,
                SortBy = sortBy,
                ViewMode = viewMode,
                CategoryProductCounts = categoryProductCounts
            };

            return View(shopVM);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm, int page = 1)
        {
            return RedirectToAction("Index", new { searchTerm, page });
        }

        [HttpGet]
        public async Task<IActionResult> Category(int categoryId, int page = 1)
        {
            return RedirectToAction("Index", new { categoryId, page });
        }

        [HttpPost]
        public async Task<IActionResult> ApplyFilters(ShopVM model)
        {
            return RedirectToAction("Index", new
            {
                categoryId = model.CategoryId,
                searchTerm = model.SearchTerm,
                sortBy = model.SortBy,
                page = 1 // Reset to first page when applying filters
            });
        }

        // AJAX endpoint for loading products without page refresh
        [HttpGet]
        public async Task<IActionResult> LoadProducts(
            int? categoryId = null,
            string searchTerm = null,
            string sortBy = "default",
            int page = 1,
            int pageSize = 12)
        {
            var (filteredProducts, totalCount) = await _productService.GetFilteredProductsAsync(
                categoryId, searchTerm, sortBy, page, pageSize);

            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var shopVM = new ShopVM
            {
                Products = filteredProducts,
                CurrentPage = page,
                TotalPages = totalPages,
                TotalProductsCount = totalCount,
                PageSize = pageSize,
                CategoryId = categoryId,
                SearchTerm = searchTerm ?? string.Empty,
                SortBy = sortBy
            };

            if (Request.Headers.XRequestedWith == "XMLHttpRequest")
            {
                return PartialView("_ProductsListPartial", shopVM);
            }

            return RedirectToAction("Index", new { categoryId, searchTerm, sortBy, page });
        }
    }
}
