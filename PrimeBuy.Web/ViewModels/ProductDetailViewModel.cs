using System.ComponentModel.DataAnnotations;

namespace PrimeBuy.Web.ViewModels
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public required string Name { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "SKU")]
        public required string SKU { get; set; }

        [Display(Name = "Stock Quantity")]
        public int StockQuantity { get; set; }

        public double Rating { get; set; }

        [Display(Name = "Product Image")]
        public required string ProductImageUrl { get; set; }

        [Display(Name = "Category")]
        public required string CategoryName { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedAt { get; set; }

        public bool IsInStock => StockQuantity > 0;
        public string StockStatus => IsInStock ? "In Stock" : "Out of Stock";
        
        // Generate star rating display
        public string GetStarRating()
        {
            var fullStars = (int)Rating;
            var hasHalfStar = Rating - fullStars >= 0.5;
            var emptyStars = 5 - fullStars - (hasHalfStar ? 1 : 0);

            var stars = "";
            for (int i = 0; i < fullStars; i++)
                stars += "<i class=\"bi bi-star-fill\"></i>";
            
            if (hasHalfStar)
                stars += "<i class=\"bi bi-star-half\"></i>";
            
            for (int i = 0; i < emptyStars; i++)
                stars += "<i class=\"bi bi-star\"></i>";

            return stars;
        }

        public int GetReviewCount()
        {
            // Mock review count based on rating - in real app this would come from database
            return (int)(Rating * 30 + Id % 50);
        }
    }
}