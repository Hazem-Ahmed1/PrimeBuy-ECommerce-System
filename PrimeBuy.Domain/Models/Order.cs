using PrimeBuy.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PrimeBuy.Domain.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z]{8}$",
            ErrorMessage = "OrderNumber Must have 8 Letters")]
        public string OrderNumber { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int ShippingAddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<OrderItem> OrderItems { get; set;  } = new HashSet<OrderItem>();
        private Order() { }

        public Order(string userId, int shippingAddressId, string orderNumber)
        {
            ApplicationUserId = userId;
            ShippingAddressId = shippingAddressId;
            OrderNumber = orderNumber;
            Status = OrderStatus.Pending;
            OrderDate = DateTime.UtcNow;
            TotalAmount = 0;
        }
    }
}
