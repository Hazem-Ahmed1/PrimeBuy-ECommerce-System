using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Web.ViewModels;
using System.Security.Claims;

namespace PrimeBuy.Web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var cart = await _cartService.GetOrCreateCartAsync(userId);
            var vm = new CartVM
            {
                Items = cart.CartItems.Select(ci => new CartItemVM
                {
                    CartItemId = ci.Id,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    ProductImageUrl = ci.Product.ProductImageUrl,
                    Price = ci.Product.Price,
                    Quantity = ci.Quantity
                }).ToList()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _cartService.AddToCartAsync(userId, productId, quantity);

            if (Request.Headers.XRequestedWith == "XMLHttpRequest")
                return Json(new { success = true, message = "Product added to cart!" });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int cartItemId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _cartService.RemoveFromCartAsync(userId, cartItemId);

            if (Request.Headers.XRequestedWith == "XMLHttpRequest")
            {
                var cart = await _cartService.GetOrCreateCartAsync(userId);
                var subtotal = cart.CartItems.Sum(ci => ci.Product.Price * ci.Quantity);
                return Json(new { success = true, cartTotal = subtotal });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int cartItemId, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _cartService.UpdateQuantityAsync(userId, cartItemId, quantity);

            var cart = await _cartService.GetOrCreateCartAsync(userId);
            var item = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);
            var cartTotal = cart.CartItems.Sum(ci => ci.Product.Price * ci.Quantity);

            return Json(new
            {
                success = true,
                itemSubtotal = item != null ? (item.Product.Price * item.Quantity) : 0,
                cartSubtotal = cartTotal,
                cartTotal = cartTotal
            });
        }
    }
}
