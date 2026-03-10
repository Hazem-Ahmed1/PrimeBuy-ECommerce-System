using PrimeBuy.Application.Common;
using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Application.Interfaces.UnitOfWork;
using PrimeBuy.Domain.Models;

namespace PrimeBuy.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> getAllSubCategoriesAsync()
            => await _unitOfWork.Categories.GetSubCategoriesAsync();

        public async Task<IEnumerable<Category>> getAllParentCategoriesAsync()
            => await _unitOfWork.Categories.GetParentCategoriesAsync();

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await _unitOfWork.Categories.GetAllAsync();

        public async Task<Category> GetByIdAsync(int id)
            => await _unitOfWork.Categories.GetByIdAsync(id);

        public async Task AddAsync(Category category)
        {
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _unitOfWork.Categories.Update(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<DeleteResult> DeleteAsync(Category category)
        {
            try
            {
                // Check if category can be safely deleted
                var dependencies = await CheckDependenciesAsync(category.Id);
                
                if (dependencies.hasProducts && dependencies.hasChildren)
                {
                    return DeleteResult.Failed(
                        $"Cannot delete category '{category.Name}' because it has {dependencies.productsCount} products and {dependencies.childrenCount} child categories. Please move or delete these items first.",
                        DeleteFailureReason.HasBothProductsAndChildren,
                        dependencies.productsCount + dependencies.childrenCount
                    );
                }
                
                if (dependencies.hasProducts)
                {
                    return DeleteResult.Failed(
                        $"Cannot delete category '{category.Name}' because it has {dependencies.productsCount} products. Please move or delete these products first.",
                        DeleteFailureReason.HasProducts,
                        dependencies.productsCount
                    );
                }
                
                if (dependencies.hasChildren)
                {
                    return DeleteResult.Failed(
                        $"Cannot delete category '{category.Name}' because it has {dependencies.childrenCount} child categories. Please move or delete these categories first.",
                        DeleteFailureReason.HasChildCategories,
                        dependencies.childrenCount
                    );
                }

                // Safe to delete
                _unitOfWork.Categories.Delete(category);
                await _unitOfWork.SaveChangesAsync();
                
                return DeleteResult.Successful($"Category '{category.Name}' deleted successfully.");
            }
            catch (Exception ex) when (ex.InnerException?.Message.Contains("REFERENCE constraint") == true)
            {
                return DeleteResult.Failed(
                    $"Cannot delete category '{category.Name}' due to database constraints. This category is being referenced by other data.",
                    DeleteFailureReason.DatabaseConstraintViolation
                );
            }
            catch (Exception ex)
            {
                return DeleteResult.Failed(
                    $"An error occurred while deleting category '{category.Name}': {ex.Message}",
                    DeleteFailureReason.UnknownError
                );
            }
        }

        public async Task<bool> CanDeleteSafelyAsync(int categoryId)
        {
            var hasProducts = await _unitOfWork.Categories.HasProductsAsync(categoryId);
            var hasChildren = await _unitOfWork.Categories.HasChildCategoriesAsync(categoryId);
            
            return !hasProducts && !hasChildren;
        }

        public async Task<(bool hasProducts, bool hasChildren, int productsCount, int childrenCount)> CheckDependenciesAsync(int categoryId)
        {
            var productsCount = await _unitOfWork.Categories.GetProductsCountAsync(categoryId);
            var childrenCount = await _unitOfWork.Categories.GetChildCategoriesCountAsync(categoryId);
            
            return (
                hasProducts: productsCount > 0,
                hasChildren: childrenCount > 0,
                productsCount: productsCount,
                childrenCount: childrenCount
            );
        }
    }
}
