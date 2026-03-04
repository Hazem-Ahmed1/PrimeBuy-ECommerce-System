using Microsoft.AspNetCore.Mvc;
using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Web.Models;
using System.Diagnostics;

namespace PrimeBuy.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductRepository productRepository;
        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            var items = await productRepository.GetAllAsync();
            return View(items);
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
