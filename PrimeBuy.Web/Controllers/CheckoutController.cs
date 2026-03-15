using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Web.ViewModels;
using System.Security.Claims;

namespace PrimeBuy.Web.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public CheckoutController(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var cart = await _cartService.GetOrCreateCartAsync(userId);

            // Validate stock before allowing checkout
            foreach (var cartItem in cart.CartItems)
            {
                if (cartItem.Product.StockQuantity <= 0)
                {
                    TempData["Error"] = $"The product '{cartItem.Product.Name}' is out of stock. Please remove it from your cart to continue.";
                    return RedirectToAction("Index", "Cart");
                }

                if (cartItem.Quantity > cartItem.Product.StockQuantity)
                {
                    TempData["Error"] = $"The quantity for '{cartItem.Product.Name}' exceeds available stock. Available: {cartItem.Product.StockQuantity}, In cart: {cartItem.Quantity}. Please update your cart to continue.";
                    return RedirectToAction("Index", "Cart");
                }
            }

            var vm = new CheckoutVM
            {
                Items = cart.CartItems.Select(ci => new CartItemVM
                {
                    CartItemId = ci.Id,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    ProductImageUrl = ci.Product.ProductImageUrl,
                    Price = ci.Product.Price,
                    Quantity = ci.Quantity
                }).ToList(),
                Total = cart.CartItems.Sum(ci => ci.Product.Price * ci.Quantity)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceOrder(CheckoutVM model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            if (!ModelState.IsValid)
            {
                var cart = await _cartService.GetOrCreateCartAsync(userId);
                model.Items = cart.CartItems.Select(ci => new CartItemVM
                {
                    CartItemId = ci.Id,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    ProductImageUrl = ci.Product.ProductImageUrl,
                    Price = ci.Product.Price,
                    Quantity = ci.Quantity
                }).ToList();
                model.Total = cart.CartItems.Sum(ci => ci.Product.Price * ci.Quantity);
                return View("Index", model);
            }

            try
            {
                var order = await _orderService.PlaceOrderAsync(userId, model.Country, model.City, model.Street, model.ZipCode);
                return RedirectToAction("Confirmation", new { orderId = order.OrderId });
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index", "Cart");
            }
        }

        public IActionResult Confirmation(int orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
        }
    }
}
