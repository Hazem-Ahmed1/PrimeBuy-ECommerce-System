using PrimeBuy.Domain.Models;

namespace PrimeBuy.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Order> PlaceOrderAsync(string userId, string country, string city, string street, string zipCode);
        Task<IEnumerable<Order>> GetUserOrdersAsync(string userId);
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task UpdateOrderStatusAsync(int orderId, int status);
    }
}
