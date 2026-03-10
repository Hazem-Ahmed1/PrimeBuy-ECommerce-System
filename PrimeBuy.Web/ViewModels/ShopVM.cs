using PrimeBuy.Domain.Models;

namespace PrimeBuy.Web.ViewModels
{
    public class ShopVM
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<Category> ParentCategories { get; set; } = new List<Category>();
        public IEnumerable<Category> Subcategories { get; set; } = new List<Category>();

        // Pagination properties
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalProductsCount { get; set; } = 0;
        public int PageSize { get; set; } = 12;
        
        // Filter properties
        public int? CategoryId { get; set; }
        public string SearchTerm { get; set; } = string.Empty;
        public string SortBy { get; set; } = "default"; // default, price-low, price-high, newest, rating, popular
        
        // Display properties
        public string ViewMode { get; set; } = "grid"; // grid or list
        
        // Helper properties for UI
        public int StartItem => (CurrentPage - 1) * PageSize + 1;
        public int EndItem => Math.Min(CurrentPage * PageSize, TotalProductsCount);
        
        // Category with product counts for filters
        public Dictionary<int, int> CategoryProductCounts { get; set; } = new Dictionary<int, int>();
    }
}
