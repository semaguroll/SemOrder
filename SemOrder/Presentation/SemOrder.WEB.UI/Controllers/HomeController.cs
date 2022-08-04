using Microsoft.AspNetCore.Mvc;

namespace SemOrder.WEB.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
