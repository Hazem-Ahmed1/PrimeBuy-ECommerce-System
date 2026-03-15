using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Web.ViewModels;
using System.Security.Claims;

namespace PrimeBuy.Web.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var orders = await _orderService.GetUserOrdersAsync(userId);

            var vm = orders.Select(o => new OrderSummaryVM
            {
                OrderId = o.OrderId,
                OrderNumber = o.OrderNumber,
                OrderDate = o.OrderDate,
                ItemCount = o.OrderItems.Count,
                TotalAmount = o.TotalAmount,
                Status = o.Status
            }).ToList();

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null || order.ApplicationUserId != userId)
                return NotFound();

            var vm = new OrderDetailsVM
            {
                OrderId = order.OrderId,
                OrderNumber = order.OrderNumber,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                Items = order.OrderItems.Select(oi => new OrderItemVM
                {
                    ProductName = oi.Product.Name,
                    ProductImageUrl = oi.Product.ProductImageUrl,
                    UnitPrice = oi.UnitPrice,
                    Quantity = oi.Quantity
                }).ToList(),
                Street = order.Address?.Street,
                City = order.Address?.City,
                ZipCode = order.Address?.ZipCode,
                Country = order.Address?.Country
            };

            return View(vm);
        }
    }
}
