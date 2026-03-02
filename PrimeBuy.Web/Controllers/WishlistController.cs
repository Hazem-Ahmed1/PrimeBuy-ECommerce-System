using Microsoft.AspNetCore.Mvc;

namespace PrimeBuy.Web.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
