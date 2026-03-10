using Microsoft.EntityFrameworkCore;
using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Domain.Models;
using PrimeBuy.Infrastructure.Data;

namespace PrimeBuy.Infrastructure.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(AppDbContext context) : base(context) { }

        public async Task<Cart?> GetCartByUserIdAsync(string userId)
        {
            return await _context.Carts
                .Where(c => c.ApplicationUserId == userId)
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync();
        }
    }
}
