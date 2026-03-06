using Microsoft.AspNetCore.Mvc;
using PrimeBuy.Application.Interfaces;
using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Application.Interfaces.Services;
using PrimeBuy.Application.Services;
using PrimeBuy.Web.Models;
using PrimeBuy.Web.ViewModels;
using System.Diagnostics;

namespace PrimeBuy.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductService productService;
        ICategoryService categoryService;
        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 8;
            var products = await productService.GetAllAsync();
            var pagedProducts = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var HomeVM = new HomeVM()
            {
                HighestRateProducts = await productService.getHighRateProductsAsync(),
                ParentCategories = await categoryService.getAllParentCategoriesAsync(),
                BestSales = await productService.getBestSalesAsync(),
            };

            ViewBag.PageNumber = page;
            ViewBag.TotalPages = Math.Ceiling((double)products.Count() / pageSize);

            return View(HomeVM);
        }

        public async Task<IActionResult> LoadMoreProducts(int page = 1)
        {
            int pageSize = 4;
            var products = await productService.GetAllAsync();
            var pagedProduct = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return PartialView("_ProductPartialView", pagedProduct);
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
