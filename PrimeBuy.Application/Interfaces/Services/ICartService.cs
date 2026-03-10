using PrimeBuy.Domain.Models;

namespace PrimeBuy.Application.Interfaces.Services
{
    public interface ICartService
    {
        Task<Cart> GetOrCreateCartAsync(string userId);
        Task AddToCartAsync(string userId, int productId, int quantity = 1);
        Task RemoveFromCartAsync(string userId, int cartItemId);
        Task UpdateQuantityAsync(string userId, int cartItemId, int quantity);
        Task ClearCartAsync(string userId);
    }
}
