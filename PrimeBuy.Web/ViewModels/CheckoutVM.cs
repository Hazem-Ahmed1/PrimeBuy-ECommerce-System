using System.ComponentModel.DataAnnotations;

namespace PrimeBuy.Web.ViewModels
{
    public class CheckoutVM
    {
        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Street { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string ZipCode { get; set; } = string.Empty;

        public List<CartItemVM> Items { get; set; } = new();
        public decimal Total { get; set; }
    }
}
