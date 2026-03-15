using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Web.ViewModels;

namespace PrimeBuy.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrdersAsync();

            var vm = orders.Select(o => new OrderSummaryVM
            {
                OrderId = o.OrderId,
                OrderNumber = o.OrderNumber,
                OrderDate = o.OrderDate,
                ItemCount = o.OrderItems.Count,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                CustomerEmail = o.ApplicationUser?.Email
            }).ToList();

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null) return NotFound();

            var vm = new OrderDetailsVM
            {
                OrderId = order.OrderId,
                OrderNumber = order.OrderNumber,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                CustomerEmail = order.ApplicationUser?.Email,
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int orderId, int status)
        {
            await _orderService.UpdateOrderStatusAsync(orderId, status);
            TempData["Success"] = "Order status updated.";
            return RedirectToAction("Details", new { id = orderId });
        }
    }
}
