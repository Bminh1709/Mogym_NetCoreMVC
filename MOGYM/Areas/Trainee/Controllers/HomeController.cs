using Microsoft.AspNetCore.Mvc;

namespace MOGYM.Areas.Trainee.Controllers
{
    [Area("Trainee")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
