using Microsoft.AspNetCore.Mvc;

namespace PrimeBuy.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
