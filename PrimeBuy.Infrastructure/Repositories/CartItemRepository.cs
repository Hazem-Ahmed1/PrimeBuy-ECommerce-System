using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Domain.Models;
using PrimeBuy.Infrastructure.Data;

namespace PrimeBuy.Infrastructure.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(AppDbContext context) : base(context) { }

        public void DeleteRange(IEnumerable<CartItem> items)
        {
            dbSet.RemoveRange(items);
        }
    }
}
