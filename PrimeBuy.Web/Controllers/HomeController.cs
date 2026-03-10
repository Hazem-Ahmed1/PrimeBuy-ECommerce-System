using Microsoft.AspNetCore.Mvc;
using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Web.Models;
using PrimeBuy.Web.ViewModels;
using System.Diagnostics;

namespace PrimeBuy.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 8;
            var products = await _productService.GetAllAsync();
            var totalCount = products.Count();

            var homeVM = new HomeVM()
            {
                HighestRateProducts = await _productService.getHighRateProductsAsync(),
                ParentCategories = await _categoryService.getAllParentCategoriesAsync(),
                BestSales = await _productService.getBestSalesAsync(),
            };

            ViewBag.PageNumber = page;
            ViewBag.TotalPages = Math.Ceiling((double)totalCount / pageSize);

            return View(homeVM);
        }

        public async Task<IActionResult> LoadMoreProducts(int page = 1)
        {
            int pageSize = 4;
            var products = await _productService.GetAllAsync();
            var pagedProducts = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return PartialView("_ProductPartialView", pagedProducts);
        }

        public new IActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
