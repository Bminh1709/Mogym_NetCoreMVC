using Microsoft.AspNetCore.Mvc;

namespace MOGYM.Areas.Trainer.Controllers
{
    [Area("Trainer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
