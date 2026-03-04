using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PrimeBuy.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide the name of the Product")]
        public string Name { get; set; }
        [RegularExpression(@"^[A-Za-z]{3}-\d{4}",
            ErrorMessage ="SKU of the Product " +
            "Should have the format " +
            "of 3 Letter - 4 Numbers For Example : ABC-1234")]

        [Required]
        public string SKU { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ProductImage { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

        public Product(string name, string sku, decimal price, int stockQuantity, int categoryId)
        {
            Name = name;
            SKU = sku;
            Price = price;
            StockQuantity = stockQuantity;
            CategoryId = categoryId;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }
        private Product()
        {

        }


    }
}
