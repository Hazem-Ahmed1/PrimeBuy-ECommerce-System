using Microsoft.AspNetCore.Mvc;

namespace PrimeBuy.Web.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
