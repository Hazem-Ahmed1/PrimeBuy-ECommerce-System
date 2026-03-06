using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeBuy.Domain.Models
{
    public class Cart
    {
        public int Id { get; set; }
        
        [ForeignKey(nameof(ApplicationUser))]
        [Required]
        public string ApplicationUserId { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }
        
        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();

        public Cart()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public Cart(string applicationUserId)
        {
            ApplicationUserId = applicationUserId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}