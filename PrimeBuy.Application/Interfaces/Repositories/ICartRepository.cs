using PrimeBuy.Domain.Models;

namespace PrimeBuy.Application.Interfaces.Repositories
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart?> GetCartByUserIdAsync(string userId);
    }
}
