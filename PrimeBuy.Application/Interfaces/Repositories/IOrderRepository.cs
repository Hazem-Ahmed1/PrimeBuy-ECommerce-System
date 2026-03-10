using PrimeBuy.Domain.Models;

namespace PrimeBuy.Application.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetUserOrdersAsync(string userId);
        Task<Order?> GetOrderByIdWithDetailsAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersWithDetailsAsync();
    }
}
