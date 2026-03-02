using Microsoft.AspNetCore.Mvc;

namespace PrimeBuy.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
