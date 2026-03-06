using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeBuy.Domain.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        
        [ForeignKey(nameof(Cart))]
        [Required]
        public int CartId { get; set; }
        
        public Cart Cart { get; set; }
        
        [ForeignKey(nameof(Product))]
        [Required]
        public int ProductId { get; set; }
        
        public Product Product { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }

        public CartItem()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public CartItem(int cartId, int productId, int quantity)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
            CreatedAt = DateTime.UtcNow;
        }
    }
}