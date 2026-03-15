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
            // Get the product to check stock
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            // Check if product is out of stock
            if (product.StockQuantity <= 0)
            {
                throw new InvalidOperationException($"Sorry, '{product.Name}' is currently out of stock.");
            }

            var cart = await GetOrCreateCartAsync(userId);

            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (existingItem != null)
            {
                // Check if adding more quantity exceeds stock
                int newQuantity = existingItem.Quantity + quantity;
                if (newQuantity > product.StockQuantity)
                {
                    throw new InvalidOperationException($"Cannot add to cart. Only {product.StockQuantity} units available, but you already have {existingItem.Quantity} in your cart.");
                }

                existingItem.Quantity = newQuantity;
                existingItem.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.CartItems.Update(existingItem);
            }
            else
            {
                // Check if initial quantity exceeds stock
                if (quantity > product.StockQuantity)
                {
                    throw new InvalidOperationException($"Cannot add to cart. Only {product.StockQuantity} units available.");
                }

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
                    // Get the product to check stock
                    var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
                    if (product == null)
                    {
                        throw new InvalidOperationException("Product not found.");
                    }

                    // Check if quantity exceeds stock
                    if (quantity > product.StockQuantity)
                    {
                        throw new InvalidOperationException($"Cannot update quantity. Only {product.StockQuantity} units of '{product.Name}' are available in stock.");
                    }

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
