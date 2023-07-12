using Microsoft.AspNetCore.Mvc;

namespace VeterinariaAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
