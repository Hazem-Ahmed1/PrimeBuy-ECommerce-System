using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Domain.Models;

namespace PrimeBuy.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            await LoadParentCategories();
            return View(new Category("", null));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                ModelState.AddModelError("Name", "Name is required.");
                await LoadParentCategories();
                return View(model);
            }

            await _categoryService.AddAsync(model);
            TempData["Success"] = "Category created successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();

            await LoadParentCategories(id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                ModelState.AddModelError("Name", "Name is required.");
                await LoadParentCategories(model.Id);
                return View(model);
            }

            await _categoryService.UpdateAsync(model);
            TempData["Success"] = "Category updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) 
            {
                TempData["Error"] = "Category not found.";
                return RedirectToAction(nameof(Index));
            }

            // Check what's preventing deletion before attempting
            var dependencies = await _categoryService.CheckDependenciesAsync(id);
            
            var deleteResult = await _categoryService.DeleteAsync(category);
            
            if (deleteResult.Success)
            {
                TempData["Success"] = deleteResult.Message;
            }
            else
            {
                TempData["Error"] = deleteResult.Message;
                
                // Add specific information about what needs to be done
                switch (deleteResult.FailureReason)
                {
                    case PrimeBuy.Application.Common.DeleteFailureReason.HasProducts:
                        TempData["ErrorDetails"] = $"Move the {deleteResult.RelatedItemsCount} products to another category before deleting this one.";
                        break;
                    case PrimeBuy.Application.Common.DeleteFailureReason.HasChildCategories:
                        TempData["ErrorDetails"] = $"Delete or move the {deleteResult.RelatedItemsCount} child categories before deleting this parent category.";
                        break;
                    case PrimeBuy.Application.Common.DeleteFailureReason.HasBothProductsAndChildren:
                        TempData["ErrorDetails"] = "You need to handle both products and child categories before deletion.";
                        break;
                    case PrimeBuy.Application.Common.DeleteFailureReason.DatabaseConstraintViolation:
                        TempData["ErrorDetails"] = "This category has database references that need to be handled by a system administrator.";
                        break;
                }
            }
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> CheckDeletion(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) 
            {
                return Json(new { canDelete = false, message = "Category not found." });
            }

            var dependencies = await _categoryService.CheckDependenciesAsync(id);
            var canDelete = await _categoryService.CanDeleteSafelyAsync(id);
            
            var response = new
            {
                canDelete = canDelete,
                categoryName = category.Name,
                hasProducts = dependencies.hasProducts,
                hasChildren = dependencies.hasChildren,
                productsCount = dependencies.productsCount,
                childrenCount = dependencies.childrenCount,
                message = canDelete 
                    ? $"Category '{category.Name}' can be safely deleted." 
                    : $"Category '{category.Name}' cannot be deleted due to existing dependencies."
            };
            
            return Json(response);
        }

        private async Task LoadParentCategories(int? excludeId = null)
        {
            var parents = await _categoryService.getAllParentCategoriesAsync();
            if (excludeId.HasValue)
                parents = parents.Where(c => c.Id != excludeId.Value);
            ViewBag.ParentCategories = new SelectList(parents, "Id", "Name");
        }
    }
}
