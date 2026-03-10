using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Domain.Models;
using PrimeBuy.Infrastructure.Data;

namespace PrimeBuy.Infrastructure.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context) : base(context) { }
    }
}
