using PrimeBuy.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace PrimeBuy.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Product name is required")]
        [Display(Name = "Product Name")]
        public required string Name { get; set; }
        
        [Required(ErrorMessage = "SKU is required")]
        [RegularExpression(@"^[A-Za-z]{3}-\d{4}", ErrorMessage = "SKU format should be ABC-1234")]
        public required string SKU { get; set; }
        
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Stock quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
        [Display(Name = "Stock Quantity")]
        public int StockQuantity { get; set; }
        
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        
        [Required(ErrorMessage = "Category is required")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        
        [Display(Name = "Category Name")]
        public string? CategoryName { get; set; }
        
        [Display(Name = "Product Image")]
        public string? ProductImageUrl { get; set; }
        
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public double Rating { get; set; }
        
        [Display(Name = "Created Date")]
        public DateTime CreatedAt { get; set; }

        public static ProductViewModel FromProduct(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                SKU = product.SKU,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                IsActive = product.IsActive,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name,
                ProductImageUrl = product.ProductImageUrl,
                Rating = product.Rating,
                CreatedAt = product.CreatedAt
            };
        }

        public Product ToProduct()
        {
            return new Product(Name, SKU, Price, StockQuantity, CategoryId)
            {
                Id = Id,
                IsActive = IsActive,
                ProductImageUrl = ProductImageUrl ?? "",
                Rating = Rating,
                CreatedAt = CreatedAt == default ? DateTime.UtcNow : CreatedAt
            };
        }
    }
}