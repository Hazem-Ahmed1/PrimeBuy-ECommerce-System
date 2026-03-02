using Microsoft.AspNetCore.Mvc;

namespace PrimeBuy.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
