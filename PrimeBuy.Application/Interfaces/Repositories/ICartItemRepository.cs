using PrimeBuy.Domain.Models;

namespace PrimeBuy.Application.Interfaces.Repositories
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        void DeleteRange(IEnumerable<CartItem> items);
    }
}
