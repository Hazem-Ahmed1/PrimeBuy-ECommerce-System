using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeBuy.Application.Interfaces.Services;

namespace PrimeBuy.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public DashboardController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            var orders = await _orderService.GetAllOrdersAsync();

            ViewBag.TotalProducts = products.Count();
            ViewBag.TotalOrders = orders.Count();
            ViewBag.TotalRevenue = orders.Sum(o => o.TotalAmount);
            ViewBag.RecentOrders = orders.Take(5);

            return View();
        }
    }
}
