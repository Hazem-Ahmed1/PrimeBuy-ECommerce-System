using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Application.Interfaces.UnitOfWork;
using PrimeBuy.Domain.Models;

namespace PrimeBuy.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cart> GetOrCreateCartAsync(string userId)
        {
            var cart = await _unitOfWork.Carts.GetCartByUserIdAsync(userId);

            if (cart == null)
            {
                cart = new Cart(userId);
                await _unitOfWork.Carts.AddAsync(cart);
                await _unitOfWork.SaveChangesAsync();
            }

            return cart;
        }

        public async Task AddToCartAsync(string userId, int productId, int quantity = 1)
        {
            var cart = await GetOrCreateCartAsync(userId);

            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                existingItem.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.CartItems.Update(existingItem);
            }
            else
            {
                var cartItem = new CartItem(cart.Id, productId, quantity);
                await _unitOfWork.CartItems.AddAsync(cartItem);
            }

            cart.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(string userId, int cartItemId)
        {
            var cart = await GetOrCreateCartAsync(userId);
            var item = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);
            if (item != null)
            {
                _unitOfWork.CartItems.Delete(item);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task UpdateQuantityAsync(string userId, int cartItemId, int quantity)
        {
            var cart = await GetOrCreateCartAsync(userId);
            var item = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);
            if (item != null)
            {
                if (quantity <= 0)
                {
                    _unitOfWork.CartItems.Delete(item);
                }
                else
                {
                    item.Quantity = quantity;
                    item.UpdatedAt = DateTime.UtcNow;
                    _unitOfWork.CartItems.Update(item);
                }
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync(string userId)
        {
            var cart = await GetOrCreateCartAsync(userId);
            _unitOfWork.CartItems.DeleteRange(cart.CartItems);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
