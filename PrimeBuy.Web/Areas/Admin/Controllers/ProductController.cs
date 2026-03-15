using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Web.ViewModels;

namespace PrimeBuy.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(string searchTerm, int? categoryId, string sortBy = "default")
        {
            // Get all products with category
            var allProducts = await _productService.GetProductsWithCategoryAsync();

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                allProducts = allProducts.Where(p =>
                    p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    p.SKU.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            // Apply category filter
            if (categoryId.HasValue)
            {
                allProducts = allProducts.Where(p => p.CategoryId == categoryId.Value);
            }

            // Apply sorting
            allProducts = sortBy switch
            {
                "name" => allProducts.OrderBy(p => p.Name),
                "price_low" => allProducts.OrderBy(p => p.Price),
                "price_high" => allProducts.OrderByDescending(p => p.Price),
                "stock" => allProducts.OrderBy(p => p.StockQuantity),
                "category" => allProducts.OrderBy(p => p.Category?.Name),
                _ => allProducts.OrderByDescending(p => p.Id)
            };

            // Pass filter values to view
            ViewBag.SearchTerm = searchTerm;
            ViewBag.SelectedCategoryId = categoryId;
            ViewBag.SortBy = sortBy;
            ViewBag.Categories = await _categoryService.GetAllAsync();

            return View(allProducts);
        }

        public async Task<IActionResult> Create()
        {
            await LoadCategories();
            return View(new ProductViewModel { IsActive = true, Name = "", SKU = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadCategories();
                return View(model);
            }

            try
            {
                await _productService.AddProduct(model.ToProduct());
                TempData["Success"] = "Product created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                // Handle database-specific errors
                if (ex.InnerException?.Message.Contains("UNIQUE") == true ||
                    ex.InnerException?.Message.Contains("duplicate") == true)
                {
                    if (ex.InnerException?.Message.Contains("SKU") == true)
                    {
                        TempData["Error"] = "A product with this SKU already exists.";
                        TempData["ErrorDetails"] = "Please choose a unique SKU for the product.";
                    }
                    else
                    {
                        TempData["Error"] = "A product with this information already exists.";
                        TempData["ErrorDetails"] = "Please check the product name and SKU for duplicates.";
                    }
                }
                else if (ex.InnerException?.Message.Contains("FOREIGN KEY") == true)
                {
                    TempData["Error"] = "Invalid category selected.";
                    TempData["ErrorDetails"] = "The selected category does not exist. Please refresh the page and select a valid category.";
                }
                else
                {
                    TempData["Error"] = "Failed to create product due to a database error.";
                    TempData["ErrorDetails"] = "Please check your input and try again. If the problem persists, contact support.";
                }

                await LoadCategories();
                return View(model);
            }
            catch (Exception ex)
            {
                // Handle any other unexpected errors
                TempData["Error"] = "An unexpected error occurred while creating the product.";
                TempData["ErrorDetails"] = "Please try again. If the problem persists, contact support.";

                await LoadCategories();
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();

            await LoadCategories();
            return View(ProductViewModel.FromProduct(product));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadCategories();
                return View(model);
            }

            await _productService.UpdateProduct(model.ToProduct());
            TempData["Success"] = "Product updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();

            try
            {
                await _productService.DeleteProduct(product);
                TempData["Success"] = "Product deleted successfully.";
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                TempData["Error"] = "Cannot delete this product because it is referenced by existing orders.";
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
        }
    }
}
